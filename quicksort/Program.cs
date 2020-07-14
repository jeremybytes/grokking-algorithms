using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 87, 92, 34, 1, 90, 25, 78 };
            Console.WriteLine(OutputList(list, "Initial List"));

            var sortedList = Quicksort(list);
            Console.WriteLine(OutputList(sortedList, "Sorted List"));

            Console.WriteLine($"Sum: {Exercises.Sum(list)}");
            Console.WriteLine($"Count: {Exercises.Count(list)}");
            Console.WriteLine($"Max: {Exercises.Max(list)}");

            Console.WriteLine("------------------------------");

            var names = new List<string>
            {
                "Kelly",
                "Jeremy",
                "Mandy",
                "Toby",
                "Lulu",
                "Penny",
                "Max"
            };
            Console.WriteLine(OutputList(names, "Initial Names"));

            var sortedNames = Quicksort(names);
            Console.WriteLine(OutputList(sortedNames, "Sorted Names"));

            Console.WriteLine($"Count: {Exercises.Count(names)}");
            Console.WriteLine($"Max: {Exercises.Max(names)}");
        }

        static List<T> Quicksort<T>(List<T> list) where T : IComparable
        {
            if (list.Count < 2)
                return list;
            else
            {
                var pivot = list[0];
                var less = new List<T>();
                var greater = new List<T>();
                foreach (T item in list)
                {
                    if (item.CompareTo(pivot) < 0)
                        less.Add(item);
                    if (item.CompareTo(pivot) > 0)
                        greater.Add(item);
                }

                var newList = new List<T>();
                newList.AddRange(Quicksort(less));
                newList.Add(pivot);
                newList.AddRange(Quicksort(greater));
                return newList;
            }
        }

        static string OutputList<T>(List<T> list, string header = "List Values")
        {
            var output = new StringBuilder();
            output.Append($"{header} {{ ");
            foreach (var item in list)
                output.Append($"{item}, ");
            output.Remove(output.Length - 2, 2);
            output.Append(" }");
            return output.ToString();
        }
    }
}
