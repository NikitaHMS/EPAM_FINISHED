using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Transmission
    {
        public string Type
        { get; set; }
        public string Number_of_Gears
        { get; set; }
        public string Manufacturer
        { get; set; }

        public Transmission(string type, string num_of_grs, string mnfctr)
        {
            Type = type;
            Number_of_Gears = num_of_grs;
            Manufacturer = mnfctr;
        }
    }
}
