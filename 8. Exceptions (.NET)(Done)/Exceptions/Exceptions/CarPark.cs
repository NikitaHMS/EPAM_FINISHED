using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace Exceptions
{
    internal class CarPark
    {
        private List<Vehicle> vehicles = [];

        public List<Vehicle> Vehicles
        {
            get { return vehicles; }
        }

        public void AddToPark(Vehicle vehicle)
        {
            vehicle.Id = vehicles.Count();
            vehicles.Add(vehicle);
        }

        public void GetAutoByParameter(string parameter, string value)
        {
            List<XElement> results = new();

            var allVehicles = from vehicle in vehicles
                select new XElement("vehicle",
                       new XAttribute("Id", vehicle.Id),
                       new XAttribute("Type", vehicle.Type),
                       new XAttribute("Model", vehicle.Model),
                       new XElement("Engine",
                       new XElement("EnginePower", vehicle.engine.Power),
                       new XElement("EngineVolume", vehicle.engine.Volume),
                       new XElement("EngineType", vehicle.engine.Type),
                       new XElement("EngineSerialNumber", vehicle.engine.Serial_Number)),
                       new XElement("Chassis",
                       new XElement("ChassisWheelsNumber", vehicle.chassis.Wheels_Number),
                       new XElement("ChassisNumber", vehicle.chassis.Number),
                       new XElement("ChassisPermissableLoad", vehicle.chassis.Permissible_Load)),
                       new XElement("Transmission",
                       new XElement("TransmissionType", vehicle.transmission.Type),
                       new XElement("NumberOfGears", vehicle.transmission.Number_of_Gears),
                       new XElement("Manufacturer", vehicle.transmission.Manufacturer)
                   )
               );

            foreach (var vehicle in allVehicles)
            {
                var elem = vehicle.XPathSelectElement($"//{parameter}");
                var attr = vehicle.Attribute(parameter);


                if (elem?.Value == null && attr?.Value == null)
                {
                    throw new TaskExceptions.GetAutoByParameterException("An attempt to find a car by a nonexistent parameter.");
                }
                else if (elem?.Value == value || attr?.Value == value)
                {
                    results.Add(vehicle);
                }
                
            }

            Console.WriteLine($"Found {results.Count} vehicle(s):\n");

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        public void UpdateAuto(int id, Vehicle newVehicle)
        {
            if (id >= vehicles.Count)
            {
                throw new TaskExceptions.UpdateAutoException("An attempt to replace the car with a non-existent identifier.");
            }

            for (int i = 0; i < vehicles.Count; i++)
            {
                if (vehicles[i].Id == id)
                {
                    newVehicle.Id = vehicles[i].Id;
                    vehicles[i] = newVehicle;
                    Console.WriteLine("The car has been replaced!");
                    return;
                }
            }                      
        }

        public void RemoveAuto(int id)
        {
            if (id >= vehicles.Count)
            {
                throw new TaskExceptions.RemoveAutoException("An attempt to remove the car with a non-existent identifier.");
            }

            for (int i = 0; i < vehicles.Count; i++)
            {
                if (vehicles[i].Id == id)
                {
                    vehicles.Remove(vehicles[i]);

                    for (int j = id; j < vehicles.Count; j++ )
                    {
                        vehicles[j].Id--; 
                    }
                }
            }
        }
    }
}
