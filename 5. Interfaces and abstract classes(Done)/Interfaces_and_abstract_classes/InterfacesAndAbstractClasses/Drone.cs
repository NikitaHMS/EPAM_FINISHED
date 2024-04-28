using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_and_abstract_classes
{
    /// <remarks>
    /// Restrictions:
    /// The drone's distance reach is limited
    /// The drone hovers in the air every 10 minutes of flight for 1 minute
    /// </remarks>
    internal class Drone : IFlyable
    {
        public int[] current_coordinates;
        private int speed = 70;
        private int reachable_distance;

        public Drone()
        {
            current_coordinates = Coordinates.SetDefaultCoordinates();


            // Setting the reach limit

            int[] available_reachable_distances = [1000, 1500, 2000, 2500, 3000];
            reachable_distance = available_reachable_distances[new Random().Next(0, 4)];
        }

        public void FlyTo(int x, int y, int z)
        {
            double total_distance = Math.Round(Math.Sqrt(
                Math.Pow(x - current_coordinates[0], 2) +
                Math.Pow(y - current_coordinates[1], 2) +
                Math.Pow(z - current_coordinates[2], 2)), 3);


            if(total_distance > reachable_distance)
            {
                Console.WriteLine("\nThe drone can't reach the specified destination." +
                                  "\nThe drone's available distance is {0}km," +
                                  " the distance to specified destination is {1}km.", 
                                  reachable_distance, total_distance);
            }
            else
            {
                Console.WriteLine("\nFlying from X:{0} Y:{1} Z:{2} to X:{3} Y:{4} Z:{5}!", current_coordinates[0], current_coordinates[1], current_coordinates[2], x, y, z);

                current_coordinates[0] = x;
                current_coordinates[1] = y;
                current_coordinates[2] = z;
            }       
        }

        /// <remarks>
        /// Formulas used:
        /// Distance = Sqrt( (x2 - x1)^2 + (y2 - y1)^2 + (z2 -z1)^2 )
        /// Time = Distance / Speed 
        /// </remarks>
        public void GetFlyTime(int x, int y, int z)
        {
            double total_distance = Math.Round(Math.Sqrt(
                Math.Pow(x - current_coordinates[0], 2) +
                Math.Pow(y - current_coordinates[1], 2) +
                Math.Pow(z - current_coordinates[2], 2)), 3);

            double total_time = Math.Round(total_distance / speed, 3);

            if (total_distance > reachable_distance)
            {
                Console.WriteLine("\nThe drone can't reach the specified destination." +
                                  "\nThe drone's available distance is {0}km," +
                                  " the distance to specified destination is {1}km.",
                                  reachable_distance, total_distance);
            }
            else
            { 
                //Assuming the drone hovers in the air every 10 minutes of flight for 1 minute

                double additional_time_hovering = Math.Floor(total_time * 60 / 10); // In minutes


                double time_minutes = Math.Floor(60 * (total_time - Math.Floor(total_time))) + additional_time_hovering;

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
                        $" for the drone to reach X:{x} Y:{y} Z:{z}" +
                        $" from X:{current_coordinates[0]} Y:{current_coordinates[1]} Z:{current_coordinates[2]}" +
                        $" at the speed of {speed}km/h." +
                        $" The distance is {total_distance} units!");
                }
                else
                {
                    Console.WriteLine($"\nIt takes approximately {time_hours} hour(s) and {time_minutes} minute(s)" +
                        $" for the drone to reach X:{x} Y:{y} Z:{z}" +
                        $" from X:{current_coordinates[0]} Y:{current_coordinates[1]} Z:{current_coordinates[2]}" +
                        $" at the speed of {speed}km/h." +
                        $" The distance is {total_distance} units!");
                }
            }  
        }
    }
}
