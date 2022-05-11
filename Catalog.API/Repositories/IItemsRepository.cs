using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Threading.Tasks;
<<<<<<< HEAD:Catalog.API/Repositories/IItemsRepository.cs
using Catalog.API.Entities;
=======
=======
>>>>>>> origin/new-branch
using Catalog.Entities;
>>>>>>> 880b17481dfaa08133a77fd560b5b1f7b0dc67e5:Repositories/IItemsRepository.cs

namespace Catalog.API.Repositories
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