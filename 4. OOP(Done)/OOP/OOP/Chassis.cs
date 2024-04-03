using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Chassis
    {
        private string wheels_number;
        private string number;
        private string permissible_load;

        public string Wheels_number
        {
            get { return wheels_number; }
            set { wheels_number = value; }
        }
        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        public string Permissible_load
        {
            get { return permissible_load; }
            set { permissible_load = value; }
        }

        public Chassis(string whls_num, string num, string prmsbl_load)
        {
            Wheels_number = whls_num;
            Number = num;
            Permissible_load = prmsbl_load;
        }
    }
}
