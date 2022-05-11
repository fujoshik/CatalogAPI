using Microsoft.AspNetCore.Mvc;
using Catalog.API.Repositories;
using System.Collections.Generic;
using Catalog.API.Entities;
using System;
using System.Linq;
<<<<<<< HEAD:Catalog.API/Controllers/ItemsController.cs
using Catalog.API.Dtos;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
=======
using Catalog.Dtos;
<<<<<<< HEAD
using System.Threading.Tasks;
=======
>>>>>>> origin/new-branch
>>>>>>> 880b17481dfaa08133a77fd560b5b1f7b0dc67e5:Controllers/ItemsController.cs

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;
        ILogger<ItemsController> logger;

        public ItemsController(IItemsRepository rep, ILogger<ItemsController> logger)
        {
            repository = rep;
            this.logger = logger;
        }

        [HttpGet]
<<<<<<< HEAD:Catalog.API/Controllers/ItemsController.cs
        public async Task<IEnumerable<ItemDto>> GetItemsAsync(string name=null)
=======
<<<<<<< HEAD
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
>>>>>>> 880b17481dfaa08133a77fd560b5b1f7b0dc67e5:Controllers/ItemsController.cs
        {
            var items = (await repository.GetItemsAsync())
                        .Select(i => i.AsDto());

            if (!string.IsNullOrWhiteSpace(name))
            {
                items = items.Where(item => item.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")}: Retrieved {items.Count()} items");

            return items;
        }
        
        // GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            var item = await repository.GetItemAsync(id);
=======
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(i => i.AsDto());
            return items;
        }
        
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);
>>>>>>> origin/new-branch

            if(item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        // POST /items
        [HttpPost]
<<<<<<< HEAD:Catalog.API/Controllers/ItemsController.cs
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
=======
<<<<<<< HEAD
        public async Task<ActionResult<ItemDto>> CreateItem(CreateItemDto itemDto)
=======
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
>>>>>>> origin/new-branch
>>>>>>> 880b17481dfaa08133a77fd560b5b1f7b0dc67e5:Controllers/ItemsController.cs
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Description = itemDto.Description,
                Price = itemDto.Price,
                CreateDate = DateTimeOffset.UtcNow
            };

<<<<<<< HEAD
            await repository.CreateItemAsync(item);
            return CreatedAtAction(nameof(GetItemAsync), new {Id = item.Id}, item.AsDto());
=======
            repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new {Id = item.Id}, item.AsDto());
>>>>>>> origin/new-branch
        }

        //PUT /items/{id}
        [HttpPut("{id}")]
<<<<<<< HEAD
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = await repository.GetItemAsync(id);
=======
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItem(id);
>>>>>>> origin/new-branch

            if(existingItem is null)
            {
                return NotFound();
            }

<<<<<<< HEAD:Catalog.API/Controllers/ItemsController.cs
            existingItem.Name = itemDto.Name;
            existingItem.Price = itemDto.Price;

            await repository.UpdateItemAsync(existingItem);
=======
<<<<<<< HEAD
            await repository.UpdateItemAsync(updatedItem);
=======
            repository.UpdateItem(updatedItem);
>>>>>>> origin/new-branch
>>>>>>> 880b17481dfaa08133a77fd560b5b1f7b0dc67e5:Controllers/ItemsController.cs

            return NoContent();
        }

        //DELETE /items/{id}
        [HttpDelete("{id}")]
<<<<<<< HEAD
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var existingItem = await repository.GetItemAsync(id);
=======
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);
>>>>>>> origin/new-branch

            if(existingItem is null)
            {
                return NotFound();
            }

<<<<<<< HEAD
            await repository.DeleteItemAsync(id);
=======
            repository.DeleteItem(id);
>>>>>>> origin/new-branch

            return NoContent();
        }
    }
}