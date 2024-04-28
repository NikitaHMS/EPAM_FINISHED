namespace _1_Development_and_build_tools
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");

            string input = Console.ReadLine().ToLower();

            string[] words = input.Split(" ");

            int count = 0;  // Unequal consecutive numbers count 

            foreach (string word in words)
            {
                for (int i = 0; i < word.Length - 1; i++)          
                {
                    for (int j = i + 1; j < word.Length;)
                    {
                        if (word[i] != word[j])    
                        {
                            count++;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine($"The maximum number of unequal consecutive characters: {count}");
        }
    }
}   