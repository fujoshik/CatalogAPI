using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Threading.Tasks;
=======
>>>>>>> origin/new-branch
using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IItemsRepository
    {
<<<<<<< HEAD
        Task<Item> GetItemAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsAsync();
        Task CreateItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(Guid id);
=======
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid id);
>>>>>>> origin/new-branch
    }
}