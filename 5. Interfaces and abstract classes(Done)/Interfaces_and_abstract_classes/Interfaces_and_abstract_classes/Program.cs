namespace Interfaces_and_abstract_classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assuming a unit distance equals 1km...");
            int[] coordinates;


            // Bird example

            coordinates = [new Random().Next(0, 10000), new Random().Next(0, 10000), new Random().Next(0, 10000)];

            Bird birdie = new();

            birdie.GetFlyTime(coordinates[0], coordinates[1], coordinates[2]); 
            birdie.FlyTo(coordinates[0], coordinates[1], coordinates[2]);

            Coordinate.PrintCurrentCoordinates(birdie);

            Console.WriteLine("\n-----------------------------------------------------------------------------");


            // Plane example

            coordinates = [new Random().Next(0, 25000), new Random().Next(0, 25000), new Random().Next(0, 25000)];

            Airplane planie = new();

            planie.GetFlyTime(coordinates[0], coordinates[1], coordinates[2]);
            planie.FlyTo(coordinates[0], coordinates[1], coordinates[2]);

            Coordinate.PrintCurrentCoordinates(planie);

            Console.WriteLine("\n-----------------------------------------------------------------------------");


            // Drone example

            coordinates = [new Random().Next(0, 2000), new Random().Next(0, 2000), new Random().Next(0, 2000)];

            Drone dronie = new();

            dronie.GetFlyTime(coordinates[0], coordinates[1], coordinates[2]);
            dronie.FlyTo(coordinates[0], coordinates[1], coordinates[2]);

            Coordinate.PrintCurrentCoordinates(dronie);

            Console.WriteLine("\n-----------------------------------------------------------------------------");
        }        
    }
}
