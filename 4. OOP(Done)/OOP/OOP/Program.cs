namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarPark carPark = new();
            Vehicle vehicle = new();


            vehicle = new Passenger_car("Nissan Altima",
                "248-hp", "2,5", "DIG", "8DC0398",
                "4", "5UXXW3C53J0T80683", "16 tons",
                "CVT", "6", "\"American Axle\"");
            carPark.AddToPark(vehicle);

            vehicle = new Truck("Volvo FMX",
                "400-hp", "6,0", "DSL", "MXS81323",
                "6", "1FUJGLD13HLJF2695", "25 tons",
                "PGA", "9", "\"Dana Limited\"");
            carPark.AddToPark(vehicle);

            vehicle = new Bus("Ashok Leyland Cheetah",
                "320-hp", "9,0", "ISL", "CJ010132X",
                "4", "2H2XA59BWDY987665", "20 tons",
                "AT", "7", "\"Diwa\"");
            carPark.AddToPark(vehicle);

            vehicle = new Scooter("Honda Cliq",
                "8-hp", "0,15", "SI", "TP00535",
                "2", "RFBG1G107EB160295", "125 kg",
                "CVT", "4", "\"CHANGXING\"");
            carPark.AddToPark(vehicle);


            carPark.Vehicles.ForEach(car => car.PrintInfo());

            Console.ReadKey();
        }
    }
}
