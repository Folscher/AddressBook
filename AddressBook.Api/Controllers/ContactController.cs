using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Api.Infrastructure;
using AddressBook.Api.Service;
using AddressBook.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AddressBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactService contactService;

        public ContactController(ContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet]
        public IQueryable<Contact> Get(int currentPage = 1, int perPage = 10, string search = null)
        {
            return contactService.GetAll()
                .Where(_ => (string.IsNullOrEmpty(search) 
                || ( _.FirstName.ToUpper().Contains(search.ToUpper()))
                || (_.Surname.ToUpper().Contains(search.ToUpper()))
                || (_.TelephoneNumber.Contains(search))
                || (_.CellPhoneNumber.Contains(search))))
                .OrderBy(_ => _.FirstName).ThenBy(_ => _.Surname)
                .Skip((currentPage - 1) * perPage)
                .Take(perPage);
        }

        [HttpGet("{contactId}")]
        public Contact Get(int contactId)
        {
            return this.contactService.Get(contactId);
        }

        [HttpPost]
        public Task<Contact> Post([FromBody] Contact contact)
        {
            return this.contactService.AddAsync(contact);
        }

        [HttpPut]
        public Task<Contact> Put([FromBody] Contact contact)
        {
            return this.contactService.UpdateAsync(contact);
        }

        [HttpDelete("{contactId}")]
        public void Delete(int contactId)
        {
            this.contactService.DeleteAsync(this.contactService.Get(contactId));
        }
    }
}
