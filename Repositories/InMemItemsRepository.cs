using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public class InMemItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item {Id = Guid.NewGuid(), Name = "T-shirt", Price = 21, CreateDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "Trousers", Price = 30, CreateDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "Dress", Price = 15, CreateDate = DateTimeOffset.UtcNow}
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.Where(i => i.Id == id).SingleOrDefault();
        }
    }
}