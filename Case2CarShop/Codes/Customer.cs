using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case2CarShop.Codes
{
    internal sealed class Customer : Person 
    {
        public Vehicle? Vehicle { get; set; }
        public List<Customer>? Customers { get; set; }
        public Customer () { }
        public Customer(string? firstName, string? lastName, int? phoneNumber, Vehicle vehicle) : base(firstName, lastName, phoneNumber)
        {
            Vehicle = vehicle;
        }

        public void AddCustomer(Customer customer)
        {
            if (Customers == null)
            {
                Customers = new();
            }
            Customers.Add(customer);
        }

        public override Customer? Search(string fullNameOfCustomer)
        {
            return Customers?.Find(c => (c.FirstName + " " + c.LastName) == fullNameOfCustomer);
        }
    }
}
