using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Oriented_Design_Principles
{
    internal class CountAllCars : Command
    {        
        List<int> quantities;

        public CountAllCars(List<int> quantities)
        {
            this.quantities = quantities;
        }

        public override void Execute()
        {
            int total = 0;

            foreach (int i in quantities)
            {
                total += i;
            }

            Console.WriteLine("\n\nСуммарное кол-во машин: {0}\n", total);
        }
    }
}
