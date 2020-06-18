using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Common
{
    public class AddressBookException : InvalidOperationException
    {
        public AddressBookException(string key, string message)
            : base($"Valitation Error Thrown")
        {
            this.Errors.Add(key, new List<string>() { message });
        }

        public AddressBookException(Dictionary<string, List<string>> errors)
            : base("Valitation Errors Thrown")
        {
            this.Errors = errors;
        }

        public Dictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();
    }
}
