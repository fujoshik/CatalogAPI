using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Controllers;
using Catalog.API.Dtos;
using Catalog.API.Entities;
using Catalog.API.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Catalog.UnitTests
{
    public class ItemsControllerTests
    {
        private readonly Mock<IItemsRepository> repositoryStub = new();
        private readonly Mock<ILogger<ItemsController>> loggerStub = new();
        private readonly Random rand = new();

        [Fact]
        public async Task GetItemAsync_WithUnexistingItem_ReturnsNotFound()
        {
            //Arrange
            repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Item)null);

            var controller = new ItemsController(repositoryStub.Object, loggerStub.Object);

            //Act
            var result = await controller.GetItemAsync(Guid.NewGuid());

            //Assert
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetItemAsync_WithExistingItem_ReturnsExpectedItem()
        {
            //Arrange
            var expectedItem = CreateRandomItem();

            repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
                .ReturnsAsync(expectedItem);

            var controller = new ItemsController(repositoryStub.Object, loggerStub.Object);

            //Act
            var result = await controller.GetItemAsync(expectedItem);

            //Assert
            result.Value.Should().BeEquivalentTo(expectedItem);
        }

        [Fact]
        public async Task GetItemsAsync_WithExistingItems_ReturnsAllItems()
        {
            //Arrange
            var expectedItems = new[] { CreateRandomItem(), CreateRandomItem(), CreateRandomItem()};

            repositoryStub.Setup(repo => repo.GetItemsAsync())
                .ReturnsAsync(expectedItems);

            var controller = new ItemsController(repositoryStub.Object, loggerStub.Object);

            //Act
            var actualItems = await controller.GetItemsAsync();

            //Assert
            actualItems.Should().BeEquivalentTo(expectedItems);
        }

        [Fact]
        public async Task GetItemsAsync_WithMatchingItems_ReturnsMatchingItems()
        {
            //Arrange
            var allItems = new[] 
            { 
                new Item() {Name = "Blouse"},
                new Item() {Name = "Sweater"},
                new Item() {Name = "Long-Blouse"}
            };

            var nameToMatch = "Blouse";

            repositoryStub.Setup(repo => repo.GetItemsAsync())
                .ReturnsAsync(allItems);

            var controller = new ItemsController(repositoryStub.Object, loggerStub.Object);

            //Act
            IEnumerable<ItemDto> foundItems = await controller.GetItemsAsync(nameToMatch);

            //Assert
            foundItems.Should().OnlyContain(
                i => i.Name == allItems[0].Name || i.Name == allItems[2].Name
            );
        }

        [Fact]
        public async Task CreateItemAsync_WithItemToCreate_ReturnsCreatedItem()
        {
            //Arrange
            var itemToCreate = new CreateItemDto(
                Guid.NewGuid().ToString(), 
                Guid.NewGuid().ToString(), 
                rand.Next(1000));

            var controller = new ItemsController(repositoryStub.Object, loggerStub.Object);

            //Act
            var result = await controller.CreateItemAsync(itemToCreate);

            //Assert
            var createdItem = (result.Result as CreatedAtActionResult).Value as ItemDto;
            itemToCreate.Should().BeEquivalentTo(
                createdItem,
                options => options.ComparingByMembers<ItemDto>().ExcludingMissingMembers()
                );
                createdItem.id.Should().NotBeEmpty();
                createdItem.CreateDate.Should().BeCloseTo(DateTimeOffset.UtcNow, TimeSpan.FromMilliseconds(1000));
        }

        [Fact]
        public async Task UpdateItemAsync_WithExistingItem_ReturnsNoContent()
        {
            //Arrange
            var existingItem = CreateRandomItem();
            repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
                .ReturnsAsync(existingItem);

            var itemId = existingItem.Id;
            var itemToUpdate = new UpdateItemDto(
                Guid.NewGuid().ToString(), 
                Guid.NewGuid().ToString(), 
                rand.Next(1000) + 3
            );

            var controller = new ItemsController(repositoryStub.Object, loggerStub.Object);

            //Act
            var result = await controller.UpdateItemAsync(itemId, itemToUpdate);

            //Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task DeleteItemAsync_WithExistingItem_ReturnsNoContent()
        {
            //Arrange
            var existingItem = CreateRandomItem();
            repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
                .ReturnsAsync(existingItem);

            var controller = new ItemsController(repositoryStub.Object, loggerStub.Object);

            //Act
            var result = await controller.DeleteItemAsync(existingItem.Id);

            //Assert
            result.Should().BeOfType<NoContentResult>();
        }

        private Item CreateRandomItem()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Price = rand.Next(1000),
                CreateDate = DateTimeOffset.UtcNow
            };
        }

    }
}
