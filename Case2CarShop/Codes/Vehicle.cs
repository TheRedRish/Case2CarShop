using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case2CarShop.Codes
{

    internal class Vehicle
    {
        public string? LicensePlate { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public DateOnly? RegistrationYear { get; set; }

        private EnumVehicle? _VehicleType;
        public EnumVehicle? VehicleType
        {
            get
            {
                return _VehicleType;
            }
            set
            {
                _VehicleType = value;
                if (_VehicleType == EnumVehicle.Car)
                {
                    Mechanic = Mechanic.mechanicCar;
                }
                else if (_VehicleType == EnumVehicle.MotorBike)
                {
                    Mechanic = Mechanic.mechanicMotorBike;
                }
                else if (_VehicleType == EnumVehicle.Truck)
                {
                    Mechanic = Mechanic.mechanicTruck;
                }
            }
        }
        public Mechanic? Mechanic { get; set; }
        public List<Vehicle>? Vehicles { get; set; }
        public Vehicle() { }
        public Vehicle(string? licensePlate, string? make, string? model, DateOnly? registrationYear, EnumVehicle? vehicleType)
        {
            LicensePlate = licensePlate;
            Make = make;
            Model = model;
            RegistrationYear = registrationYear;
            VehicleType = vehicleType;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles == null)
            {
                Vehicles = new();
            }
            Vehicles?.Add(vehicle);
        }
    }
}
