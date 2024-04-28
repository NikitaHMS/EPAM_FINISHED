using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Oriented_Design_Principles
{
    internal class TheProgram
    {
        public static void Start(CarInfo car)
        {
            CommandInvoker invoker = new();
            bool isOn = true;
            int choice;

            List<string> brands = new List<string>();
            List<int> quantities = new List<int>();
            List<double> prices = new List<double>();
            List<string> models = new List<string>();

            while (isOn)
            {
                Console.WriteLine("\nВыберите команду ----------------------");
                Console.WriteLine("\n1 Добавить автомобиль");
                Console.WriteLine("\n2 Посчитать кол-во брендов");
                Console.WriteLine("\n3 Посчитать кол-во автомобилей");
                Console.WriteLine("\n4 Средняя цена за автомобиль");
                Console.WriteLine("\n5 Средняя цена автомобиля конкретного бренда");
                Console.WriteLine("\n6 Завершить работу");

                Console.Write("\n>");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Console.Write("\nВведите бренд автомобиля: ");
                        brands.Add(car.Brand = Console.ReadLine());

                        Console.Write("Введите количество автомобилей: ");
                        quantities.Add(car.Quantity = Convert.ToInt32(Console.ReadLine()));

                        Console.Write("Введите цену за один автомобиль: ");
                        prices.Add(car.Price = Convert.ToDouble(Console.ReadLine().Replace(".", ",")));
                        
                        Console.Write("Введите модель автомобиля: ");
                        models.Add(car.Model = Console.ReadLine());

                        break;

                    case 2:

                        invoker.SetCommand(new CountAllBrands(brands));
                        invoker.Invoke();

                        break;

                    case 3:

                        invoker.SetCommand(new CountAllCars(quantities));
                        invoker.Invoke();

                        break;

                    case 4:

                        invoker.SetCommand(new AveragePriceCar(prices));
                        invoker.Invoke();
                        
                        break;

                    case 5:

                        invoker.SetCommand(new AveragePriceBrand(brands, prices));
                        invoker.Invoke();

                        break;

                    case 6:

                        isOn = false;

                        break;
                }             
            }
        }
    }
}
