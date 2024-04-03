using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Engine
    {
        private string power;
        private string volume;
        private string type;
        private string serial_number;

        public string Power
        {
            get { return power; }
            set { power = value; }
        }
        public string Volume
        {
            get { return volume; }
            set { volume = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Serial_number
        {
            get { return serial_number; }
            set { serial_number = value; }
        }

        public Engine(string e_power, string e_volume, string e_type, string e_ser_num)
        {
            Power = e_power;
            Volume = e_volume;
            Type = e_type;
            Serial_number = e_ser_num;
        }
    }
}
