namespace Object_Oriented_Design_Principles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarInfo car = CarInfo.GetInstance();
            TheProgram.Start(car);   
        }
    }
}