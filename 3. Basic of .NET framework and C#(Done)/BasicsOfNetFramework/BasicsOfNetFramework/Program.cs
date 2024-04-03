namespace BasicsOfNetFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> remainder_stack = new Stack<string>();
           
            Console.Write("Десятичное число: ");
            int temp_num = Convert.ToInt32(Console.ReadLine());

            Console.Write("Система счисления: ");
            int base_num = Convert.ToInt32(Console.ReadLine());

            int num = temp_num; 
            int temp_remainder;

            while (true)
            {
                temp_remainder = temp_num % base_num;               
                temp_num /= base_num;

                if (temp_remainder >= 10)
                {
                    string remainder = Convert.ToString(temp_remainder);
                   
                    remainder = Switch(remainder);
                    
                    remainder_stack.Push(remainder);
                }
                else
                {
                    string remainder = Convert.ToString(temp_remainder);
                    
                    remainder_stack.Push(remainder);
                }

                if (temp_num == 0)
                {
                    break;
                }
            }

            Console.Write($"\nДесятичное число {num} в системе счисление {base_num}: ");

            Print();



            string Switch(string rem)
            {
                switch (rem)
                {
                    case "10":
                        rem = "a";
                        break;


                    case "11":
                        rem = "b";
                        break;


                    case "12":
                        rem = "c";
                        break;


                    case "13":
                        rem = "d";
                        break;


                    case "14":
                        rem = "e";
                        break;


                    case "15":
                        rem = "f";
                        break;


                    case "16":
                        rem = "g";
                        break;


                    case "17":
                        rem = "h";
                        break;


                    case "18":
                        rem = "i";
                        break;


                    case "19":
                        rem = "j";
                        break;

                    default:
                        break;

                }

                return (rem);
            }

            void Print()
            {
                foreach (string a in remainder_stack)
                {
                    Console.Write(a);
                }

                Console.Write("\n");
            }
        }
    }
}