using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Oriented_Design_Principles
{
    internal class AveragePriceBrand : Command
    {

        private List<string> brands;
        private List<double> prices;

        public AveragePriceBrand(List<string> brands, List<double> prices)
        {
            this.brands = brands;
            this.prices = prices;
        }

        public override void Execute()
        {
            Console.WriteLine("\n\nУкажите бренд");
            Console.Write("\n>");
            string brand = Console.ReadLine();

            var brandPricePairs = from zip in brands.Zip(prices)
                             where zip.First == brand
                             select zip;            
            
            double prices_sum = 0;
            int prices_count = 0;

            foreach (var pair in brandPricePairs)
            {
                prices_sum += pair.Second;
                prices_count++;
            }

            Console.WriteLine("\n\nСредняя стоимость автомобиля марки {0}: {1}\n", brand, Math.Round((prices_sum /= prices_count), 2));          
        }
    }
}
