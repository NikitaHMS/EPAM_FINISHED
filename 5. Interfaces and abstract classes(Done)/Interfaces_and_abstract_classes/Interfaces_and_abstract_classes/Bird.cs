using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_and_abstract_classes
{
    /// <remarks>
    /// Restrictions:
    /// The bird stops to look for food once every 3 hours for 5 minutes
    /// The bird needs 11 hours of sleep a day
    /// </remarks>
    internal class Bird : IFlyable
    {
        public int[] current_coordinates;       
        private int speed;

        public Bird()
        {
            speed = new Random().Next(1, 20);
            current_coordinates = Coordinate.SetDefaultCoordinates();
        }

        public void FlyTo(int x, int y, int z)
        {
            Console.WriteLine("\nFlying from X:{0} Y:{1} Z:{2} to X:{3} Y:{4} Z:{5}!", 
                current_coordinates[0],
                current_coordinates[1],
                current_coordinates[2],
                x, y, z);
            
            current_coordinates[0] = x;
            current_coordinates[1] = y;
            current_coordinates[2] = z;
        }

        /// <remarks>
        /// Formulas used:
        /// Distance = Sqrt( ( x2 - x1 )^2 + ( y2 - y1 )^2 + ( z2 - z1 )^2 )
        /// Time = Distance / Speed 
        /// </remarks>
        public void GetFlyTime(int x, int y, int z)
        {
            double total_distance = Math.Round(Math.Sqrt(
                Math.Pow(x - current_coordinates[0], 2) +
                Math.Pow(y - current_coordinates[1], 2) +
                Math.Pow(z - current_coordinates[2], 2)), 3);

            double total_time = Math.Round(total_distance / speed, 3);  // In hours


            // Assuming the bird stops to look for food once every 3 hours for 5 minutes

            double additional_time_eating = Math.Floor(total_time / 3) * (5 / 60);

            // Assuming the bird sleeps 11 hours a day

            double additional_time_sleeping = Math.Floor(total_time / 24) * 11;


            total_time += additional_time_eating + additional_time_sleeping;


            double time_minutes = Math.Floor(60 * total_time - Math.Floor(total_time));

            double time_hours = Math.Floor(total_time);

            while (time_minutes > 59)
            {
                time_minutes -= 60;
                time_hours += 1;
            }

            if (time_hours > 23)
            {
                int time_days = (int)time_hours / 24;
                time_hours -= time_days * 24; 
                
                Console.WriteLine($"\nIt takes approximately {time_days} day(s), {time_hours} hour(s) and {time_minutes} minute(s)" +
                    $" for the bird to reach X:{x} Y:{y} Z:{z}" +
                    $" from X:{current_coordinates[0]} Y:{current_coordinates[1]} Z:{current_coordinates[2]}" +
                    $" at the speed of {speed}km/h." +
                    $" The distance is {total_distance} units!");
            }
            else
            {
                Console.WriteLine($"\nIt takes approximately {time_hours} hour(s) and {time_minutes} minute(s)" +
                    $" for the bird to reach X:{x} Y:{y} Z:{z}" +
                    $" from X:{current_coordinates[0]} Y:{current_coordinates[1]} Z:{current_coordinates[2]}" +
                    $" at the speed of {speed}km/h." +
                    $" The distance is {total_distance} units!");
            }                
        }
    }
}
