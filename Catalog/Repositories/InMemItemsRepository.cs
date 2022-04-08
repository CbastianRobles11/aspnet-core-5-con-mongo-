using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Repositories
{
    public class InMemItemsRepository : IInMemItemsRepository
    {

        //traemos el cotrolador que creamos
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 8, CreatedDate = System.DateTimeOffset.Now },
            new Item { Id = Guid.NewGuid(), Name = "Potion2", Price = 9, CreatedDate = System.DateTimeOffset.Now },
            new Item { Id = Guid.NewGuid(), Name = "Potion3", Price = 10, CreatedDate = System.DateTimeOffset.Now }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            // si no le encutra devuelve nullo
            return items.Where(item => item.Id == id).SingleOrDefault();
            //return items.FindIndex(id);
        }

        public void CreateItem(Item item)
        {

            //anadimos a items un elemento de tipo item

            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existItem => existItem.Id == item.Id);

            items[index] = item; 

        }

        public void DelteItem(Guid id)
        {
            var index = items.FindIndex(existItem => existItem.Id == id);

            //eliminamos
            items.RemoveAt(index);
        }
    }
}
