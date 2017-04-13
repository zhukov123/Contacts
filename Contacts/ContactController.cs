using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contacts.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contacts
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public IEnumerable<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetContact")]
        public IActionResult GetById(string id)
        {
            var item = _contactRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contact item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            
            _contactRepository.Add(item);

            return CreatedAtRoute("GetContact", new { id = item.Id }, item);

        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Contact item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var contact = _contactRepository.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            /*contact.FirstName = item.FirstName;
            contact.LastName = item.LastName;
            contact.Email = item.Email;
            contact.PhoneNumber = item.PhoneNumber;
            contact.StatusIsActive = item.StatusIsActive;

            _contactRepository.Update(contact);
            return new NoContentResult();*/
            item.LastModified = DateTime.UtcNow;
            _contactRepository.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var contact = _contactRepository.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            _contactRepository.Remove(id);
            return new NoContentResult();
        }
                


    }
}
