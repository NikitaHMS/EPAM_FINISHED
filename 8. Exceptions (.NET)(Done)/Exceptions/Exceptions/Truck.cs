using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Truck : Vehicle
    {
        public Truck(string vehicle_model,
            string engine_power, string engine_volume, string engine_type, string engine_serial_num,
            string chassis_wheels_num, string chassis_num, string chassis_prmsbl_load,
            string transmission_type, string transmission_num_of_gears, string transmission_manufacturer)
        {
            Type = "Truck";

            Create(vehicle_model,
                engine_power, engine_volume, engine_type, engine_serial_num,
                chassis_wheels_num, chassis_num, chassis_prmsbl_load,
                transmission_type, transmission_num_of_gears, transmission_manufacturer);
        }
    }
}
