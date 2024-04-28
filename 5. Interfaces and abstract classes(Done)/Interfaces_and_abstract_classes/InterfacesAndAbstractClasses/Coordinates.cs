using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_and_abstract_classes
{
    internal struct Coordinates
    {
        public static int[] SetDefaultCoordinates()
        {
            int[] coordinates = [0, 0, 0];
            return coordinates;
        }
        public static void PrintCurrentCoordinates(Object o)
        {
            Type type = o.GetType();

            var name = type.Name;

            var value = type.GetField("current_coordinates").GetValue(o);

            int[] coords = (int[])value;

            Console.WriteLine($"\nThe {name}'s current location: X:{coords[0]} Y:{coords[1]} Z:{coords[2]}.");
        }
    }
}
