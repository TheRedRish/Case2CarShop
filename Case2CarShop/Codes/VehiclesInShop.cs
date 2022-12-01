using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case2CarShop.Codes
{
    internal class VehiclesInShop
    {
        public Person? Person { get; set; }
        public Vehicle? Vehicle { get; set; }
        public List<VehiclesInShop>? VehiclesInShopList { get; set; }
        public VehiclesInShop(Person? person, Vehicle? vehicle)
        {
            Person = person;
            Vehicle = vehicle;
        }
        public VehiclesInShop() { }
        public void AddVehiclesInShop(VehiclesInShop vehiclesInShop)
        {
            VehiclesInShopList?.Add(vehiclesInShop);
            VehiclesInShopList?.Sort();
        }
    }
}
