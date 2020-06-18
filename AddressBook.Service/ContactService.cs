using AddressBook.Data.Infrastructure;
using AddressBook.Service.Infrastructure;
using AddressBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AddressBook.Common;

namespace AddressBook.Api.Service
{
    public class ContactService : GenericService<Contact>
    {
        public ContactService(IGenericRepository<Contact> repository)
            :base(repository)
        { 
        }

        public Contact Get(int contactId)
        {
            if (!this.GetAll().Any(_ => _.ContactId == contactId))
            {
                throw new AddressBookException("NotFound", "Contact not found");
            }

            return this.GetAll().SingleOrDefault(_ => _.ContactId == contactId);
        }

        public override Task<Contact> AddAsync(Contact entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Contact entity not set");
            }

            if (string.IsNullOrEmpty(entity.FirstName))
            {
                throw new AddressBookException("NotValid", "First name must be entered");
            }

            if (string.IsNullOrEmpty(entity.Surname))
            {
                throw new AddressBookException("NotValid", "Surname must be entered");
            }

            if (this.GetAll().Any(_ => _.Email.ToUpper() == entity.Email.ToUpper()))
            {
                throw new AddressBookException("NotValid", "A contact with this email address has already been entered");
            }

            this.ValidateEmail(entity.Email);
            this.ValidateCellNumber(entity.CellPhoneNumber);

            entity.DateCreated = DateTime.Now;
            entity.DateUpdated = DateTime.Now;

            return base.AddAsync(entity);
        }

        public override Task<Contact> UpdateAsync(Contact entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Contact entity not set");
            }

            if (string.IsNullOrEmpty(entity.FirstName))
            {
                throw new AddressBookException("NotValid", "First name must be entered");
            }

            if (string.IsNullOrEmpty(entity.Surname))
            {
                throw new AddressBookException("NotValid", "Surname must be entered");
            }

            this.ValidateEmail(entity.Email);
            this.ValidateCellNumber(entity.CellPhoneNumber);


            entity.DateUpdated = DateTime.Now;

            return base.UpdateAsync(entity);
        }

        private void ValidateCellNumber(string cellNumber)
        {
            if (!Regex.IsMatch(cellNumber, @"^(\d{10}|\d{12})$"))
            {
                throw new AddressBookException("NotValid", "Contact cell number is invalid");
            }
        }

        private void ValidateEmail(string email)
        {
            if (!Regex.IsMatch(email, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"))
            {
                throw new AddressBookException("NotValid", "Contact email is invalid");
            }
        }
    }
}
