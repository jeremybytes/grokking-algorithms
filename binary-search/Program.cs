using System;
using System.Collections.Generic;
using static System.Console;

namespace binary_search
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            int targetValue = rnd.Next(-1, 101);
            if (args?.Length > 0)
                int.TryParse(args[0], out targetValue);

            WriteLine($"Looking for value {targetValue}");

            var list = new List<int>();
            for (int i = 1; i < 100; i += 2)
                list.Add(i);

            (int index, int value) = FindValue(targetValue, list);

            WriteLine("==========================");
            if (index == -1)
                WriteLine($"Value {targetValue} not found");
            else
                WriteLine($"Found value {value} at index {index}");
        }

        private static (int, int) FindValue(int targetValue, List<int> list)
        {
            int stepCount = 0;
            int low = 0;
            int high = list.Count - 1;

            while (low <= high)
            {
                stepCount++;
                int mid = (low + high) / 2;
                int guess = list[mid];

                WriteLine("--------------------------");
                WriteLine($"Step {stepCount}");
                WriteLine($"Trying location {mid}");
                WriteLine($"Value at location is {list[mid]}");

                if (guess == targetValue)
                    return (mid, list[mid]);
                if (guess > targetValue)
                    high = mid - 1;
                if (guess < targetValue)
                    low = mid + 1;
            }

            return (-1, -1);
        }
    }
}
