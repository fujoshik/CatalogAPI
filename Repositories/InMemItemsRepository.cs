using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
using System.Threading.Tasks;
=======
>>>>>>> origin/new-branch
using Catalog.Entities;

namespace Catalog.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item {Id = Guid.NewGuid(), Name = "T-shirt", Price = 21, CreateDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "Trousers", Price = 30, CreateDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "Dress", Price = 15, CreateDate = DateTimeOffset.UtcNow}
        };

<<<<<<< HEAD
        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var item = items.Where(i => i.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task CreateItemAsync(Item item)
        {
            items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index = items.FindIndex(i => i.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(i => i.Id == id);
            items.RemoveAt(index);
            await Task.CompletedTask;
=======
        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.Where(i => i.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(i => i.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(i => i.Id == id);
            items.RemoveAt(index);
>>>>>>> origin/new-branch
        }
    }
}