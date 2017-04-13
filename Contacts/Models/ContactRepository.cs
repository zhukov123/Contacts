using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;

namespace Contacts.Models
{
    public class ContactRepository : IContactRepository
    {
        
        private MongoClient _client;
        private IMongoDatabase _database;
        IMongoCollection<Contact> _collection;
        
        
        /// <summary>
        /// Initialize Contact repo with connection string, database and collection for MongoDB.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="database"></param>
        /// <param name="collection"></param>
        public ContactRepository(string connectionString, string database, string collection)
        {
                             
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(database);

            _collection = _database.GetCollection<Contact>(collection);

            if (_collection.Find(_ => true).ToList().Count == 0)
                Add(new Contact { FirstName = "Darth", LastName = "Vader", Email = "vader@empire.com", PhoneNumber = "123-22VADER" });

        }

        /// <summary>
        /// Return all contacts in collection
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contact> GetAll()
        {
            return _collection.Find(_ => true).ToList();

        }
        /// <summary>
        /// Add one contact to collection
        /// </summary>
        /// <param name="item"></param>
        public void Add(Contact item)
        {
            _collection.InsertOne(item);
        }

        /// <summary>
        /// Find and return one contact from collection, by Id, if found
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Contact Find(string key)
        {
            var filter = Builders<Contact>.Filter.Eq("Id", key);
            return _collection.Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// Remove one item from collection by Id, if it exists
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            
            var filter = Builders<Contact>.Filter.Eq("Id", key);
            _collection.DeleteOne(filter);
        }

        /// <summary>
        /// Replace one item in collection by Id (Update)
        /// </summary>
        /// <param name="item"></param>
        public void Update(Contact item)
        {
            
            var filter = Builders<Contact>.Filter.Eq("Id", item.Id);
            _collection.ReplaceOne(filter, item);
        }
       
    }
}
