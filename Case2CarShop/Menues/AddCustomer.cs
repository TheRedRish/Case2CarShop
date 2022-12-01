using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Case2CarShop.Menues
{
    internal static class AddCustomer
    {
        public static void Run(Customer customer, Vehicle vehicle)
        {
            string? customerFirstName = null;
            string? customerLastName = null;
            int? customerPhoneNumber = null;

            string? vehicleLicensePlate = null;
            string? vehicleMake = null;
            string? vehicleModel = null;
            DateOnly? vehicleRegistrationYear = null;
            do
            {
                Console.Clear();

                // Section for adding user input, if its not already stored. Makes it possible to dynamically add breakpoints for user input and start the session
                // without the user has to type in the data again.
                Console.Write("First name of customer: ");
                if (customerFirstName != null)
                {
                    Console.WriteLine(customerFirstName);
                }
                else
                {
                    customerFirstName = Console.ReadLine();
                }
                // ------------------------------------------ //
                Console.Write("Last name of customer: ");
                if (customerLastName != null)
                {
                    Console.WriteLine(customerLastName);
                }
                else
                {
                    customerLastName = Console.ReadLine();
                }
                Console.Write("Phonenumber of customer: ");
                if (customerPhoneNumber != null)
                {
                    Console.WriteLine(customerPhoneNumber);
                }
                else
                {
                    string phoneNumberUserInput = Console.ReadLine();
                    bool isPhoneNumberUserInput = CheckUserInput.IsPhoneNumber(phoneNumberUserInput);
                    if (!isPhoneNumberUserInput || phoneNumberUserInput == null)
                    {
                        Console.WriteLine("Input is not a number, try again!");
                        Console.ReadKey();
                        continue;
                    }
                    // Remove whitespace and only take the last 8 digits as there might be landcode in the number
                    string phoneNumberTrimmed = String.Concat(phoneNumberUserInput.Where(c => !Char.IsWhiteSpace(c)));
                    string phoneNumber = "";
                    for (int i = phoneNumberTrimmed.Length - 8; i < phoneNumberTrimmed.Length; i++)
                    {
                        phoneNumber += phoneNumberTrimmed[i];
                    }

                    customerPhoneNumber = Int32.Parse(phoneNumber);
                }

                Console.Write("Car licenseplate: ");
                if (vehicleLicensePlate != null)
                {
                    Console.WriteLine(vehicleLicensePlate);
                }
                else
                {
                    vehicleLicensePlate = Console.ReadLine();
                }
                Console.Write("Car make: ");
                if (vehicleMake != null)
                {
                    Console.WriteLine(vehicleMake);
                }
                else
                {
                    vehicleMake = Console.ReadLine();
                }
                Console.Write("Car model: ");
                if (vehicleModel != null)
                {
                    Console.WriteLine(vehicleModel);
                }
                else
                {
                    vehicleModel = Console.ReadLine();
                }
                Console.Write("Car registration year: ");
                if (vehicleRegistrationYear != null)
                {
                    Console.WriteLine(vehicleRegistrationYear);
                }
                else
                {
                    bool isDateTime = DateOnly.TryParse(Console.ReadLine(), out DateOnly vehicleRegistrationYearUserInput);
                    if (isDateTime)
                    {
                        vehicleRegistrationYear = vehicleRegistrationYearUserInput;
                    }
                    else
                    {
                        Console.WriteLine("Forkert dato format!");
                        Console.ReadKey();
                        continue;
                    }
                }


                Console.WriteLine("---------------------");
                Console.WriteLine("These are your options:");
                foreach (var enumVehicles in Enum.GetValues(typeof(EnumVehicle)))
                {
                    Console.WriteLine(enumVehicles.ToString());
                }
                Console.WriteLine("---------------------");
                Console.Write("Car type: ");
                string? vehicleTypeUserInput = Console.ReadLine();
                EnumVehicle? vehicleType;
                if (EnumVehicle.Car.ToString().ToLower() == vehicleTypeUserInput?.ToLower())
                {
                    vehicleType = EnumVehicle.Car;
                }
                else if (EnumVehicle.MotorBike.ToString().ToLower() == vehicleTypeUserInput?.ToLower())
                {
                    vehicleType = EnumVehicle.MotorBike;
                }
                else if (EnumVehicle.Truck.ToString().ToLower() == vehicleTypeUserInput?.ToLower())
                {
                    vehicleType = EnumVehicle.Truck;
                }
                else
                {
                    Console.WriteLine("None of the selected options choosen, try again.");
                    Console.ReadKey();
                    continue;
                }
                Vehicle tempvehicle = new(vehicleLicensePlate, vehicleMake, vehicleModel, vehicleRegistrationYear, vehicleType);
                Customer tempcustomer = new(customerFirstName, customerLastName, customerPhoneNumber, tempvehicle);
                Console.WriteLine("Vehicle succesfully created");
                customer.AddCustomer(tempcustomer);
                vehicle.AddVehicle(tempvehicle);
                PrintVehicleList(vehicle);
                Console.ReadKey();
                break;

            } while (true);
        }
        private static void PrintVehicleList(Vehicle vehicle)
        {
            Console.WriteLine("All Vehicles in the system:");
            vehicle.Vehicles?.ForEach(v =>
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Make: " + v.Make);
                Console.WriteLine("Model: " + v.Model);
                Console.WriteLine("Licenseplate: " + v.LicensePlate);
                Console.WriteLine("RegistrationYear: " + v.RegistrationYear.ToString());
                Console.WriteLine("Type: " + v.VehicleType.ToString());
            });
        }
    }
}
