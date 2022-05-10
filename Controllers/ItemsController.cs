using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using System.Collections.Generic;
using Catalog.Entities;
using System;
using System.Linq;
using Catalog.Dtos;
<<<<<<< HEAD
using System.Threading.Tasks;
=======
>>>>>>> origin/new-branch

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository rep)
        {
            repository = rep;
        }

        [HttpGet]
<<<<<<< HEAD
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            var items = (await repository.GetItemsAsync())
                        .Select(i => i.AsDto());
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
<<<<<<< HEAD
        public async Task<ActionResult<ItemDto>> CreateItem(CreateItemDto itemDto)
=======
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
>>>>>>> origin/new-branch
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
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
            
            Item updatedItem = existingItem with {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

<<<<<<< HEAD
            await repository.UpdateItemAsync(updatedItem);
=======
            repository.UpdateItem(updatedItem);
>>>>>>> origin/new-branch

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