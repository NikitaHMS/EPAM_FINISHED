using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_Collections
{
    internal class Engine
    {
        public string Power
        { get; set; }
        public string Volume
        { get; set; }
        public string Type
        { get; set; }
        public string Serial_Number
        { get; set; }

        public Engine(string e_power, string e_volume, string e_type, string e_ser_num)
        {
            Power = e_power;
            Volume = e_volume;
            Type = e_type;
            Serial_Number = e_ser_num;
        }
    }
}
