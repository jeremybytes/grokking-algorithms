using System;
using System.Collections.Generic;

namespace breadth_first
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = GetData();
            var starting_node = "you";

            // Search graph for connections to "you" who are mango sellers
            var mango_seller = Search(data, starting_node, IsMangoSeller);
            
            if (!string.IsNullOrEmpty(mango_seller))
                Console.WriteLine($"Found! {mango_seller} is connected to {starting_node}");
            else
                Console.WriteLine($"No mango sellers connected to {starting_node}");

            Console.WriteLine("--------------------");

            // Search graph for connections to "bob" who are mango sellers
            var another_starting_node = "bob";
            var another_mango_seller = Search(data, another_starting_node, IsMangoSeller);

            if (!string.IsNullOrEmpty(another_mango_seller))
                Console.WriteLine($"Found! {another_mango_seller} is connected to {another_starting_node}");
            else
                Console.WriteLine($"No mango sellers connected to {another_starting_node}");
        }

        /// <summary>
        /// Breadth-first search on a graph of string data
        /// </summary>
        /// <param name="graphData">Graph data to search: each node contains 
        ///                         a list of links to other nodes</param>
        /// <param name="startNode">The starting node for the search</param>
        /// <param name="predicate">The search criteria</param>
        /// <returns>First item found
        ///          or empty string if no item found</returns>
        static string Search(
            Dictionary<string, List<string>> graphData,
            string startNode,
            Func<string, bool> predicate)
        {
            var alreadySearched = new List<string>();
            var searchQueue = new Queue<string>();
            searchQueue.Enqueue(startNode);

            while (searchQueue.Count > 0)
            {
                var person = searchQueue.Dequeue();
                if (alreadySearched.Contains(person)) continue;

                if (predicate(person))
                {
                    return person;
                }
                else
                {
                    alreadySearched.Add(person);
                    graphData[person].ForEach(s => searchQueue.Enqueue(s));
                }
            }

            return string.Empty;
        }

        static Dictionary<string, List<string>> GetData()
        {
            var result = new Dictionary<string, List<string>>();

            result["you"] = new List<string>() { "alice", "bob", "claire" };
            result["bob"] = new List<string>() { "anuj", "peggy" };
            result["alice"] = new List<string>() { "peggy", "bob" };
            result["claire"] = new List<string>() { "thom", "johnny" };
            result["anuj"] = new List<string>() { };
            result["peggy"] = new List<string>() { };
            result["thom"] = new List<string>() { };
            result["jonny"] = new List<string>() { };

            return result;
        }

        static bool IsMangoSeller(string name)
        {
            return name.EndsWith("m");
        }

    }
}
