using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exceptions
{
    internal class TaskXml
    {
        public static XElement XmlLiters(List<Vehicle> vehicles)
        {
            var XML_Liters = new XElement("Root",
                    from vehicle in vehicles
                    where Convert.ToDouble(vehicle.engine.Volume) > 1.5
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
                           new XElement("Manufacturer", vehicle.transmission.Manufacturer))
                        )
                    );

            Console.WriteLine("\n" + "An Xml file has been created!");
            return XML_Liters;
        }

        public static XElement XmlTruckBus(List<Vehicle> vehicles)
        {
            var XML_TruckBus = new XElement("Root",
                    from vehicle in vehicles
                    where vehicle.Type == "Bus" || vehicle.Type == "Truck"
                    select new XElement("vehicle",
                           new XAttribute("Id", vehicle.Id),
                           new XAttribute("Type", vehicle.Type),
                           new XAttribute("Model", vehicle.Model),
                           new XElement("EnginePower", vehicle.engine.Power),
                           new XElement("EngineType", vehicle.engine.Type),
                           new XElement("EngineSerialNumber", vehicle.engine.Serial_Number)
                            )
                        );

            Console.WriteLine("\n" + "An Xml file has been created!");
            return XML_TruckBus;
        }

        public static XElement XmlGroupedByTransmission(List<Vehicle> vehicles)
        {
            var XML_Grouped = new XElement("Root",
                from vehicle in vehicles
                group vehicle by vehicle.transmission.Type into groupedData
                select new XElement("Group",
                       new XAttribute("TransmissionType", groupedData.Key),
                       from gr_vehicle in groupedData
                       select new XElement("vehicle",
                            new XAttribute("Id", gr_vehicle.Id),
                            new XAttribute("Type", gr_vehicle.Type),
                            new XAttribute("Model", gr_vehicle.Model),
                            new XElement("Engine",
                            new XElement("EnginePower", gr_vehicle.engine.Power),
                            new XElement("EngineVolume", gr_vehicle.engine.Volume),
                            new XElement("EngineType", gr_vehicle.engine.Type),
                            new XElement("EngineSerialNumber", gr_vehicle.engine.Serial_Number)),
                            new XElement("Chassis",
                            new XElement("ChassisWheelsNumber", gr_vehicle.chassis.Wheels_Number),
                            new XElement("ChassisNumber", gr_vehicle.chassis.Number),
                            new XElement("ChassisPermissableLoad", gr_vehicle.chassis.Permissible_Load)),
                            new XElement("Transmission",
                            new XElement("TransmissionType", gr_vehicle.transmission.Type),
                            new XElement("NumberOfGears", gr_vehicle.transmission.Number_of_Gears),
                            new XElement("Manufacturer", gr_vehicle.transmission.Manufacturer))
                                          )
                                   )
                );

            Console.WriteLine("\n" + "An Xml file has been created!");
            return XML_Grouped;
        }
    }
}
