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

        public ContactRepository(string connectionString, string database, string collection)
        {
                             
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(database);

            _collection = _database.GetCollection<Contact>(collection);

            if (_collection.Find(_ => true).ToList().Count == 0)
                Add(new Contact { FirstName = "Vishwa", LastName = "Kapoor", Email = "vishwa.kapoor@gmail.com", PhoneNumber = "936-666-1024" });

        }

        public IEnumerable<Contact> GetAll()
        {
            return _collection.Find(_ => true).ToList();

        }

        public void Add(Contact item)
        {
            _collection.InsertOne(item);
        }

        public Contact Find(string key)
        {
            var filter = Builders<Contact>.Filter.Eq("Id", key);
            return _collection.Find(filter).First();
        }

        public void Remove(string key)
        {
            
            var filter = Builders<Contact>.Filter.Eq("Id", key);
            _collection.DeleteOne(filter);
        }

        public void Update(Contact item)
        {
            
            var filter = Builders<Contact>.Filter.Eq("Id", item.Id);
            _collection.ReplaceOne(filter, item);
        }
       
    }
}
