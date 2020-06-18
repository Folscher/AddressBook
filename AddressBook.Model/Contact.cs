using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Model
{
    public class Contact
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string TelephoneNumber { get; set; }

        public string CellPhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
