using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Contacts.Models
{
    public class Contact
    {

        public Contact()
        {
            Id = ObjectId.GenerateNewId().ToString();
            FirstName = "";
            LastName = "";
            PhoneNumber = "";
            Email = "";
            StatusIsActive = false;
            LastModified = DateTime.UtcNow;
        }
                    

        [BsonId]
        public string Id { get; set; }
        
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool StatusIsActive { get; set; }
        public DateTime LastModified { get; set; }
    }
    
}
