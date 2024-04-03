using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_and_abstract_classes
{
    /// <remarks>
    /// Restrictions:
    /// The aircraft increases speed by 10 km/h every 10 km of flight from an initial speed of 200 km/h
    /// If a flight lasts longer than 20 hours, the plane will have to land to refuel; refueling process takes 1 hour
    /// </remarks>
    internal class Airplane : IFlyable
    {
        public int[] current_coordinates;
        private int initial_speed;
        private int max_speed;

        public Airplane()
        {
            current_coordinates = Coordinate.SetDefaultCoordinates();

            initial_speed = 200;
            max_speed = 900;
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
        /// Distance = Sqrt( (x2 - x1)^2 + (y2 - y1)^2 + (z2 -z1)^2 )
        /// Time = Distance / Speed 
        /// </remarks>
        public void GetFlyTime(int x, int y, int z)
        {
            double total_distance = 0;
            int distance_to_max_speed = 0;
            
            double total_time = 0;
            double time_to_max_speed = 0;

            int time_until_refueling = 20;
            double max_distance_without_refueling = 0;
            

            total_distance = Math.Round(Math.Sqrt(
                Math.Pow(x - current_coordinates[0], 2) +
                Math.Pow(y - current_coordinates[1], 2) +
                Math.Pow(z - current_coordinates[2], 2)), 3);

            
            // Assuming the aircraft increases it's speed each 10km of flight by 10 km/h

            distance_to_max_speed = (max_speed - initial_speed) / 10 * 10;  


            int num_of_increments = distance_to_max_speed / 10;

            for (int i = 0; i < num_of_increments; i++)
            {
                time_to_max_speed += 10.0 / (initial_speed + i * 10);
            }


            max_distance_without_refueling = (time_until_refueling * 60 * 60 - time_to_max_speed * 60 * 60) / 60 / 60 * max_speed + distance_to_max_speed;


            if (total_distance > max_distance_without_refueling)
            {
                // Refueling is needed


                // Finding the max distance the aircraft can cover before refueling 

                double distance_at_max_speed = (time_until_refueling * 60 * 60 - time_to_max_speed * 2) / 60 / 60 * max_speed;

                double total_distance_until_refuel = distance_to_max_speed * 2 + distance_at_max_speed;


                // Finding the distance left after refueling

                double total_distance_after_refuel =  total_distance - total_distance_until_refuel;

                distance_at_max_speed = total_distance_after_refuel - distance_to_max_speed;


                // Finding the time it takes to cover the whole distance

                total_time = time_until_refueling + (time_to_max_speed + distance_at_max_speed / max_speed);

                // Assuming it takes 1 hour to refuel the aircarft

                total_time += 1;
            }
            else if (total_distance > distance_to_max_speed)
            {
                // Refueling is not needed, the aircraft is able to reach max speed


                // Finding the distance left to cover at max speed

                double distance_at_max_speed = total_distance - distance_to_max_speed;


                // Finding the time it takes to cover the whole distance

                total_time = distance_at_max_speed / max_speed + time_to_max_speed;
            }  
            else  
            {
                // The aircraft is unable to reach max speed


                // Finding the number of times the speed has been increased

                num_of_increments = (int)Math.Floor(total_distance / 10);


                // Finding the time it takes to reach the destination

                for (int i = 0; i < num_of_increments; i++)
                {
                    total_time += 10.0 / (initial_speed + i * 10);
                }     
            }

            double time_minutes = Math.Floor(60 * (total_time - Math.Floor(total_time)));

            double time_hours = Math.Floor(total_time);

            if (time_hours > 23)
            {
                // Refueling is needed + day count


                int time_days = (int)time_hours / 24;
                time_hours -= time_days * 24;

                Console.WriteLine($"\nIt takes approximately {time_days} day, {time_hours} hour(s) and {time_minutes} minute(s)" +
                    $" for the airplane to reach X:{x} Y:{y} Z:{z}" +
                    $" from X:{current_coordinates[0]} Y:{current_coordinates[1]} Z:{current_coordinates[2]}." +
                    $" The distance is {total_distance} units! Refueling is needed.");
            }
            else if (time_hours >= 20)
            {
                // Refueling is needed


                Console.WriteLine($"\nIt takes approximately {time_hours} hour(s) and {time_minutes} minute(s)" +
                    $" for the airplane to reach X:{x} Y:{y} Z:{z}" +
                    $" from X:{current_coordinates[0]} Y:{current_coordinates[1]} Z:{current_coordinates[2]}." +
                    $" The distance is {total_distance} units! Refueling is needed.");
            }
            else
            {
                // Refueling is not needed


                Console.WriteLine($"\nIt takes approximately {time_hours} hour(s) and {time_minutes} minute(s)" +
                    $" for the airplane to reach X:{x} Y:{y} Z:{z}" +
                    $" from X:{current_coordinates[0]} Y:{current_coordinates[1]} Z:{current_coordinates[2]}." +
                    $" The distance is {total_distance} units! Refueling is not needed.");
            }
        }
    }
}
