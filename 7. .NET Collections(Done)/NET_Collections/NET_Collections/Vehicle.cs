using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NET_Collections
{
    internal class Vehicle
    {
        public string Model
        { get; set; }
        public string Type
        { get; set; }

        internal Engine engine;
        internal Chassis chassis;
        internal Transmission transmission;

        public void Create(string v_model,
            string e_power, string e_volume, string e_type, string e_ser_num, 
            string ch_whls_num, string ch_num, string ch_prmsbl_load, 
            string tr_type, string tr_num_of_grs, string tr_mnfctr)
        {
            Model = v_model;
            engine = new(e_power, e_volume, e_type, e_ser_num);
            chassis = new(ch_whls_num, ch_num, ch_prmsbl_load);
            transmission = new(tr_type, tr_num_of_grs, tr_mnfctr);
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{Type} \"{Model}\" characteristics ----------------------------------------- " +
                $"\n\nEngine: \nPower - {engine.Power} " + 
                $"\nVolume - {engine.Volume} " +
                $"\nType - {engine.Type} " +
                $"\nSerial number - {engine.Serial_Number} " +
                $"\n\nChassis: \nNumber of wheels - {chassis.Wheels_Number} " +
                $"\nNumber - {chassis.Number} " +
                $"\nPermissible load - {chassis.Permissible_Load} " +
                $"\n\nTransmission: \nType - {transmission.Type} " +
                $"\nNumber of gears - {transmission.Number_of_Gears} " +
                $"\nManufacturer - {transmission.Manufacturer}\n\n");
        }
    }
}
