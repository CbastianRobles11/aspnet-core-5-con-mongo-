using Catalog.Entities;
using System;
using System.Collections.Generic;

namespace Catalog.Repositories
{
    public interface IInMemItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();

        void CreateItem(Item item);

        void UpdateItem(Item item);

        void DelteItem(Guid id);
    }
}