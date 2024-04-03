namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarPark carPark = new();
            Vehicle vehicle = new();

            vehicle = new PassengerCar("Nissan Altima",
                "248 hp", "2,5", "DIG", "8DC0398",
                "4", "5UXXW3C53J0T80683", "300 kg",
                "CVT", "6", "\"American Axle\"");
            carPark.AddToPark(vehicle);

            vehicle = new PassengerCar("Honda Civic LX",
                "158 hp", "1,8", "In-Line 4-Cylinder", "EW9V3X9Q",
                "4", "JQP3WA5JMHV9DM477", "290 kg",
                "CVT", "6", "\"Honda\"");
            carPark.AddToPark(vehicle);

            vehicle = new PassengerCar("Volkswagen Bora",
                "204 hp", "1,9", "4-Cylinder diesel engine", "3KJK7F3V",
                "4", "BXZC93N3B7E9DZNHE", "1,4 tons",
                "FWD", "4", "\"Volkswagen\"");
            carPark.AddToPark(vehicle);


            vehicle = new Truck("Volvo FMX",
                "400 hp", "6,0", "DSL", "MXS81323",
                "6", "1FUJGLD13HLJF2695", "25 tons",
                "PGA", "9", "\"Dana Limited\"");
            carPark.AddToPark(vehicle);

            vehicle = new Truck("Ford 1833 DC",
                "330 hp", "9,0", "Ecotorq", "N3BE72S8",
                "4", "NVZVJDJ6L8DAX9CC8", "19 tons",
                "ZF", "10", "\"Ford\"");
            carPark.AddToPark(vehicle);

            vehicle = new Truck("Kenworth T680",
                "510 hp", "12,9", "MX-13", "4TKAXR6E",
                "6", "5J6TJN5F8PPRSHT3Y", "23 tons",
                "Manual", "10", "\"Kenworth\"");
            carPark.AddToPark(vehicle);


            vehicle = new Bus("Ashok Leyland Cheetah",
                "320 hp", "9,0", "ISL", "CJ010132X",
                "4", "2H2XA59BWDY987665", "20 tons",
                "AT", "7", "\"Diwa\"");
            carPark.AddToPark(vehicle);

            vehicle = new Bus("Iveco Magelys Lounge",
                "394 hp", "8,7", "Cursor 9", "PB46B4QZ",
                "4", "BHHECA762RVMHHYXJ", "12,5 tons",
                "ZF", "12", "\"Iveco\"");
            carPark.AddToPark(vehicle);

            vehicle = new Bus("The Man TGE Coach",
                "174 hp", "2,0", "Turbo Diesel", "XF7KNEN9",
                "4", "949YJ23JRA83TJF9A", "5,5 tons",
                "Automatic", "8", "\"MAN\"");
            carPark.AddToPark(vehicle);


            vehicle = new Scooter("Honda Cliq",
                "8 hp", "0,15", "SI", "TP00535",
                "2", "RFBG1G107EB160295", "125 kg",
                "CVT", "4", "\"CHANGXING\"");
            carPark.AddToPark(vehicle);

            vehicle = new Scooter("Yamaha Alpha",
                "7 hp", "0,11", "Single-cylinder engine, 4-stroke", "B6E4GNPK",
                "2", "5E6E3GXSFRKSTMBBX", "102 kg",
                "Automatic", "4", "\"Yamaha\"");
            carPark.AddToPark(vehicle);

            vehicle = new Scooter("Piaggio Medley",
                "14 hp", "0,12", "Single-cylinder, 4-stroke", "L6LA8K8V",
                "2", "S8G9PSLQ5PCXSXP8D", "125 kg",
                "Belt", "4", "\"Piaggio\"");
            carPark.AddToPark(vehicle);



            // An output of complete information about all vehicles
            // from "OOP" task
            carPark.Vehicles.ForEach(vehicle => vehicle.PrintInfo());



            // Creation of xml files with corresponding information
            // from ".NET Collections" task
            TaskXml.XmlLiters(carPark.Vehicles).Save("XML_Liters.xml");
            TaskXml.XmlTruckBus(carPark.Vehicles).Save("XML_TruckBus.xml");
            TaskXml.XmlGroupedByTransmission(carPark.Vehicles).Save("XML_GroupedByTransmission.xml");



            // InitializationException example           
            // vehicle = new PassengerCar("",
            //     "248-hp", "2,5", "DIG", "8DC0398",
            //     "4", "5UXXW3C53J0T80683", "16 tons",
            //     "CVT", "6", "\"American Axle\"");


            // AddException example
            // vehicle.Model = "";


            // GetAutoByParameterException example
            // carPark.GetAutoByParameter("Model", "Yamaha Alpha"); // No exception
            // carPark.GetAutoByParameter("Weight", "2 tons");      // Exception


            // UpdateAutoException example
            /*
            vehicle = new PassengerCar("Chevrolet Sonic",
                "138-hp", "1,4", "Inline 4", "C2L4GKX5",
                "4", "GXSFRKSLSXP8D2H2XA", "300 kg",
                "Automatic", "6", "\"Chevrolet\"");
            carPark.UpdateAuto(11, vehicle);                        // No exception
            carPark.UpdateAuto(12, vehicle);                        // Exception 
            */


            // RemoveAutoException example
            // carPark.RemoveAuto(0);                               // No exception
            // carPark.RemoveAuto(12);                              // Exception
        }
    }
}
