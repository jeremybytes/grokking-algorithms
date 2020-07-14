using System;
using System.Collections.Generic;
using System.Text;

namespace selection_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 87, 92, 34, 1, 90, 25, 78 };
            Console.WriteLine(OutputList(list, "Initial List"));

            var sortedList = SelectionSort(list);
            Console.WriteLine(OutputList(sortedList, "Sorted List"));

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

            var sortedNames = SelectionSort(names);
            Console.WriteLine(OutputList(sortedNames, "Sorted Names"));
        }

        static List<T> SelectionSort<T>(List<T> list) where T : IComparable 
        {
            List<T> newList = new List<T>();
            for (int i = list.Count-1; i >= 0; i--)
            {
                int smallest = FindSmallest(list);
                newList.Add(list[smallest]);
                list.RemoveAt(smallest);
            }
            return newList;
        }

        static int FindSmallest<T>(List<T> list) where T : IComparable
        {
            T smallest = list[0];
            int smallest_index = 0;
            for (int i = 0; i < list.Count; i++)
                if (list[i].CompareTo(smallest) < 0)
                {
                    smallest = list[i];
                    smallest_index = i;
                }
            return smallest_index;
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
