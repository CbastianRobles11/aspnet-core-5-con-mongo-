using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Catalog.Repositories
{
    /// <summary>
    /// para usar mondo db necesitamos descargar MongoDbClient
    /// en la consola poner dotnet add package MongoDB.Driver
    /// </summary>
    public class MongoDbItemsRepository : IInMemItemsRepository
    {
        // datos de la bbd
        private const string DatabaseName = "catalog";
        private const string CollectionName = "items";

        ///==================
        ///lo hacemos a los filtros como variable de clase
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        private readonly IMongoCollection<Item> itemCollection;
        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            //creamos una instancia de la bbd esta nos dara referencia con la coleccion
            IMongoDatabase database=mongoClient.GetDatabase(DatabaseName);

            itemCollection=database.GetCollection<Item>(CollectionName);



        }

        public void CreateItem(Item item)
        {
            
            itemCollection.InsertOne(item);

        }

        public void DelteItem(Guid id)
        {
            var filter = filterBuilder.Eq(existItem => existItem.Id, id);
            itemCollection.DeleteOne(filter);
        }

        public Item GetItem(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);

            //encontramos solo uno
            return itemCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Item> GetItems()
        {
            return itemCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateItem(Item item)
        {
            var filter = filterBuilder.Eq(existItem => existItem.Id, item.Id);


            itemCollection.ReplaceOne(filter, item);
        }
    }
}
