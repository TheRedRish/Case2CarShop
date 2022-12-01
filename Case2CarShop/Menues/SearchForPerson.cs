using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case2CarShop.Menues
{
    internal class SearchForPerson
    {
        public static void Run(Customer customer)
        {
            Console.Clear();
            if (customer.Customers == null)
            {
                Console.WriteLine("No Customers added yet");
                Console.ReadKey();
                return;
            }
            foreach (Customer customer1 in customer.Customers)
            {
                Console.WriteLine($"{customer1.FirstName} {customer1.LastName}");
            }
            Console.WriteLine("The name of the person you want to find: ");
            string userSearch = Console.ReadLine() ?? "";

            Mechanic mechanic = new();

            Mechanic? mechanicFound = mechanic.Search(userSearch);
            Customer? customerFound = customer.Search(userSearch);
            if (mechanicFound == null && customerFound == null)
            {
                Console.WriteLine("No customer or mechanic found");
            }

            if (mechanicFound != null)
            {
                List<Customer>? customersWithMechanicFound = PrintMechnic(mechanicFound, customer);
                if (customersWithMechanicFound == null)
                {
                    Console.WriteLine("Mechanic has no customers");
                    Console.ReadKey();
                    return;
                }
                foreach (Customer customerWithMechanicFound in customersWithMechanicFound)
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("Make: " + customerWithMechanicFound.Vehicle?.Make);
                    Console.WriteLine("Model: " + customerWithMechanicFound.Vehicle?.Model);
                    Console.WriteLine("Customer phonenumber: " + customerWithMechanicFound.Phonenumber);
                }
            }

            if (customerFound != null)
            {
                Mechanic? mechanicOfCustomer = mechanic.Search(customerFound.Vehicle?.Mechanic);
                
                Console.WriteLine($"Customer: {customerFound.FirstName} {customerFound.LastName}");
                if (mechanicOfCustomer == null)
                {
                    Console.WriteLine("No mechanic for that customer");
                    Console.ReadKey();
                    return;
                }
                List<Customer>? customersWithMechanicFound = PrintMechnic(mechanicOfCustomer, customer);
                if (customersWithMechanicFound == null)
                {
                    Console.WriteLine("Mechanic has no customers");
                    Console.ReadKey();
                    return;
                }
                foreach (Customer customerWithMechanicFound in customersWithMechanicFound)
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("Licenseplate: " + customerWithMechanicFound.Vehicle?.LicensePlate);
                }
            }
            Console.ReadKey();
        }

        private static List<Customer>? PrintMechnic(Mechanic mechanicFound, Customer customer)
        {
            Console.WriteLine($"Mechanic: {mechanicFound.FirstName} {mechanicFound.LastName} with role: {mechanicFound.Assignment}");
            List<Customer>? customersWithMechanicFound = customer.Customers?.FindAll(c => c.Vehicle?.Mechanic == mechanicFound);
            if (customersWithMechanicFound == null)
            {
                return null;
            }
            return customersWithMechanicFound;
        }
    }
}
