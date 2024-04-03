using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OOP
{
    internal class Transmission
    {
        private string type;
        private string number_of_gears;
        private string manufacturer;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Number_of_gears
        {
            get { return number_of_gears; }
            set { number_of_gears = value; }
        }
        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public Transmission(string type, string num_of_grs, string mnfctr)
        {
            Type = type;
            Number_of_gears = num_of_grs;
            Manufacturer = mnfctr;
        }
    }
}
