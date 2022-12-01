using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case2CarShop.Codes
{
    internal abstract class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Phonenumber { get; set; }        
        public Person() { }
        public Person(string? firstName, string? lastName, int? phonenumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Phonenumber = phonenumber;
        }

        public abstract object? Search(string searchString);
    }
}
