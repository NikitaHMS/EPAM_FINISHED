using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_test_framework
{
    public class CountConsecutive
    {
        public static int UnequalCharacters(string input)
        {
            int count = 0;
            string[] words = input.Split(" ");  

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
                        
                        break;                        
                    }
                }
            }

            return count;
        }

        public static int IdenticalLatinCharacters(string input)
        {
            int count = 0;
            string latinAlphabet = "abcdefghijklmnopqrstuvwxyz";

            input.ToCharArray();

            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = i + 1; j < input.Length;)
                {
                    if ((latinAlphabet.Contains(input[i]) && latinAlphabet.Contains(input[j])) &&
                        (input[i] == input[j]))
                    {
                        count++;
                        break;
                    }

                    break;
                }
            }

            return count;
        }

        public static int IdenticalDigits(string input)
        {
            int count = 0;
            string digits = "1234567890";

            input.ToCharArray();

            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = i + 1; j < input.Length;)
                {
                    if ((digits.Contains(input[i]) && digits.Contains(input[j])) &&
                        (input[i] == input[j]))
                    {
                        count++;
                        break;
                    }

                    break;
                }
            }

            return count;
        }
    }
}
