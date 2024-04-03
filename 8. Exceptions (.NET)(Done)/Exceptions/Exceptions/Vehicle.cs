using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Vehicle
    {
        private string model;     
        public string Model
        { 
            get { return model; } 
            set 
            {
                if (model != null)
                {
                    throw new TaskExceptions.AddException("It is impossible to change the existing model.");
                }
                model = value;
            } 
        }
        public string Type
        { get; set; }
        public int Id
        { get; set; }

        internal Engine engine;
        internal Chassis chassis;
        internal Transmission transmission;


        public void Create(string v_model,
            string e_power, string e_volume, string e_type, string e_ser_num, 
            string ch_whls_num, string ch_num, string ch_prmsbl_load, 
            string tr_type, string tr_num_of_grs, string tr_mnfctr)
        {
            if (String.IsNullOrEmpty(v_model))
            {
                throw new TaskExceptions.InitializationException("It is impossible to initialize a model of the vehicle.");
            }

            Model = v_model;
            engine = new(e_power, e_volume, e_type, e_ser_num);
            chassis = new(ch_whls_num, ch_num, ch_prmsbl_load);
            transmission = new(tr_type, tr_num_of_grs, tr_mnfctr);
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Id{Id}: {Type} \"{Model}\" characteristics ----------------------------------------- " +
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
