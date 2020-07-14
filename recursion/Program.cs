using System;

namespace recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 5;
            int result = Factorial(input);
            Console.WriteLine($"Factorial of {input} is {result}");
        }

        static int Factorial(int input)
        {
            if (input == 1)
            {
                Console.WriteLine(1);
                return 1;
            }
            else
            {
                int result = input * Factorial(input-1);
                Console.WriteLine(result);
                return result;
            }
        }
    }
}
