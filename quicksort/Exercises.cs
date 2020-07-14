using System;
using System.Collections.Generic;
using System.Text;

namespace quicksort
{
    public static class Exercises
    {
        // Exercise 4.1 Recursive sum
        public static int Sum(List<int> input)
        {
            if (input.Count == 1)
                return input[0];
            else
                return input[0] + Sum(input.GetRange(1, input.Count - 1));
        }

        // Exercise 4.2 Recursive count
        public static int Count<T>(List<T> input)
        {
            if (input.Count == 1)
                return 1;
            else
                return 1 + Count(input.GetRange(1, input.Count - 1));
        }

        // Exercise 4.3 Recursive maximum
        public static T Max<T>(List<T> input) where T : IComparable
        {
            if (input.Count == 1)
                return input[0];
            else if (input.Count == 2)
                return (input[0].CompareTo(input[1]) > 0) ? input[0] : input[1];
            else
            {
                T subMax = Max(input.GetRange(1, input.Count - 1));
                return (input[0].CompareTo(subMax) > 0) ? input[0] : subMax;
            }
        }
    }
}