using System.Runtime.CompilerServices;

namespace Unit_test_framework
{
    internal class Program
    {        
        public static void Main(string[] args)
        {
            Console.Write("Type a string: ");
            string input = Console.ReadLine().ToLower();
            
            
            Console.WriteLine();

            Console.WriteLine("The max number of consecutive unequal characters: {0}", 
                CountConsecutive.UnequalCharacters(input));

            Console.WriteLine("The max number of consecutive identical latin characters: {0}", 
                CountConsecutive.IdenticalLatinCharacters(input));

            Console.WriteLine("The max number of consecutive identical digits: {0}", 
                CountConsecutive.IdenticalDigits(input));
        }
    }
}
