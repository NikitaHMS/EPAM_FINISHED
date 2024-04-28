using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Object_Oriented_Design_Principles
{
    internal class CountAllBrands : Command
    {
        List<string> brands;

        public CountAllBrands(List<string> brands)
        {
            this.brands = brands;
        }

        public override void Execute()
        {

            int count = 0;

            for (int i = 0; i < brands.Count - 1; i++)
            {
                for (int j = i + 1; j <= brands.Count - 1; j++) 
                {
                    if (brands[i] == brands[j])
                    {
                        count++;
                        break;
                    }
                }
            }
            
            Console.WriteLine("\n\nСуммарное кол-во брендов: {0}\n", brands.Count - count);
        }
    }
}
