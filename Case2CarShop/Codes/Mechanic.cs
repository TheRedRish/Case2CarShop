using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case2CarShop.Codes
{
    internal sealed class Mechanic : Person
    {
        public string? Assignment { get; set; }
        public Mechanic() { }
        public Mechanic(string firstName, string lastName, int phoneNumber, string assignement) : base(firstName, lastName, phoneNumber)
        {
            Assignment = assignement;
        }

        public List<Mechanic> Mechanics { get { return _mechanics; } set { value.ForEach(v => _mechanics.Add(v)); } }

        public static readonly Mechanic mechanicCar = new("Martin", "Jensen", 11111111, "Bilmekaniker");
        public static readonly Mechanic mechanicMotorBike = new("Thomas", "Hansen", 22222222, "Motorcykelmekaniker");
        public static readonly Mechanic mechanicTruck = new("Henrik", "Nielsen", 33333333, "Lastbilmekaniker");

        private List<Mechanic> _mechanics = new()
        {
            mechanicCar,
            mechanicMotorBike,
            mechanicTruck
        };

        public override Mechanic? Search(string fullNameOfMechanic)
        {
            return Mechanics.Find(m => (m.FirstName + " " + m.LastName) == fullNameOfMechanic);
        }
        public Mechanic? Search(Mechanic? mechanic)
        {
            return Mechanics.Find(m => m == mechanic);
        }
    }
}
