using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_Collections
{
    internal class CarPark
    {
        private List<Vehicle> vehicles = new();

        public List<Vehicle> Vehicles
        {
            get { return vehicles; }
        }

        public void AddToPark(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }
    }
}
