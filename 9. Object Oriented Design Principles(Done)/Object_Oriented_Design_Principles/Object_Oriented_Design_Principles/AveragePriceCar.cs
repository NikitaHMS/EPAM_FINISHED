using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Oriented_Design_Principles
{
    internal class AveragePriceCar : Command
    {
        List<double> list;

        public AveragePriceCar(List<double> list)
        {
            this.list = list;
        }

        public override void Execute()
        {
            int count = 0;
            double price = 0;

            foreach (double i in list)
            {
                count++;
                price += i;
            }

            Console.WriteLine("\n\nСредняя стоимость автомобиля: {0}\n", Math.Round(price /= count, 2));
        }
    }
}
