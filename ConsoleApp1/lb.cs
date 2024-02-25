

using System;

namespace ConsoleApp1
{
    public static class lb
    {
        public static void Task1()
        {
            Console.WriteLine("Enter num:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int number))
            {
                if (number >= 1 && number <= 100)
                {
                    for (int i = 1; i <= number; i++)
                    {
                        if (i % 3 == 0 && i % 5 == 0)
                        {
                            Console.WriteLine("FizzBuzz");
                        }
                        else if (i % 3 == 0)
                        {
                            Console.WriteLine("Fizz");
                        }
                        else if (i % 5 == 0)
                        {
                            Console.WriteLine("Buzz");
                        }
                        else
                        {
                            Console.WriteLine(i);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
            Console.ReadLine();
        }
    }
}
