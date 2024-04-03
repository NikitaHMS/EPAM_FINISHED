using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Chassis
    {
        public string Wheels_Number
        { get; set; }
        public string Number
        { get; set; }
        public string Permissible_Load
        { get; set; }

        public Chassis(string whls_num, string num, string prmsbl_load)
        {
            Wheels_Number = whls_num;
            Number = num;
            Permissible_Load = prmsbl_load;
        }
    }
}
