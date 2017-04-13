using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Models
{
    public interface IContactRepository
    {

        void Add(Contact item);
        IEnumerable<Contact> GetAll();
        Contact Find(string key);
        void Remove(string key);
        void Update(Contact item);


    }
}
