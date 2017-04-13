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

        /// <summary>
        /// Init controller with repository
        /// </summary>
        /// <param name="contactRepository"></param>
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        /// <summary>
        /// Get All Records
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }

        /// <summary>
        /// Get Single Record (By Id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Create record (complete record with Id and LastModified time will be returned)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Update Single Record (By Id)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
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

            item.LastModified = DateTime.UtcNow;
            _contactRepository.Update(item);
            //return new NoContentResult();
            return CreatedAtRoute("GetContact", new { id = item.Id }, item);
        }


        /// <summary>
        /// Remove Record (By Id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
