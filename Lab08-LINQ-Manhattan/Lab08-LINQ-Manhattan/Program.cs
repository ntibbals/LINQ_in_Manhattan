using System;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using Lab08_LINQ_Manhattan.Classes;
using System.Collections.Generic;
using System.Linq;

namespace Lab08_LINQ_Manhattan
{
    class Program
    {
        public static string Path = "../../../../../data.json";
        static void Main(string[] args)
        {
            Console.WriteLine("Neighborhoods: ");
            DisplayNeighborhoods(ReadJson());////Answers Question #1
            RemoveNeighborhoodBlanks(ReadJson());/// Answers Question #2
            RemoveDuplicates(ReadJson()); /// Answers Question #3
            RemoveBlanksTwo(ReadJson()); /// Answers Question #5
            FilterNeighborhoods(ReadJson()); /// Answers Question #4
            Console.ReadLine();
        }

        /// <summary>
        /// Method to return a list containing all neighborhoods
        /// </summary>
        /// <returns>parsed out json object of neighborhoods</returns>
        public static List<Neighborhoods> ReadJson()
        {
            JObject propObject = JObject.Parse(File.ReadAllText(@"../../../../../data.json"));
            var newObject = propObject["features"];
            List<Neighborhoods> listProps = new List<Neighborhoods>();
            foreach (var p in newObject)
            {
                Neighborhoods props = new Neighborhoods
                {
                    Zip = (string)p["properties"]["zip"],
                    City = (string)p["properties"]["city"],
                    State = (string)p["properties"]["state"],
                    Address = (string)p["properties"]["address"],
                    Borough = (string)p["properties"]["borough"],
                    Neighborhood = (string)p["properties"]["neighborhood"],
                    County = (string)p["properties"]["county"],
                };
                listProps.Add(props);
            }
            return listProps;
        }

        /***********************QUESTION 1-a **************************/
        /// <summary>
        /// Display a list of neighborhoods 
        /// </summary>
        /// <param name="neighborhoods">List of Neighborhoods</param>
        /// <returns>neighborhoods</returns>
        public static List<Neighborhoods> DisplayNeighborhoods(List<Neighborhoods> neighborhoods)
        {
            foreach (Neighborhoods item in neighborhoods)
            {
                if (item != null)
                {
                    Console.Write($" {item.Neighborhood} |");
                }
            }

            return neighborhoods;
        }

        /***********************QUESTION 1-b **************************/
        /// <summary>
        /// Display enumerable neighborhoods
        /// </summary>
        /// <param name="neighborhoods">Enumerable neighbords</param>
        /// <returns>Neighborhoods</returns>
        public static IEnumerable<Neighborhoods> DisplayNeighborhoodsE(IEnumerable<Neighborhoods> neighborhoods)
        {
            foreach (Neighborhoods item in neighborhoods)
            {
                if (item != null)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine($"- Neighborhood: {item.Neighborhood}");
                }
            }

            return neighborhoods;
        }

        /***********************QUESTION 2 **************************/
        /// <summary>
        /// Method that Removes all blank spaces from imported JSON file
        /// </summary>
        /// <param name="neighborhoods">imported JSON list</param>
        /// <returns>Enumerable list of neighborhoods with blanks spaces removed</returns>
        public static IEnumerable<Neighborhoods> RemoveNeighborhoodBlanks(List<Neighborhoods> neighborhoods)
        {
            IEnumerable<Neighborhoods> spacelessNeighborhoods = from neigh in neighborhoods
                                                         where neigh.Neighborhood.Length > 0
                                                         select neigh;
            foreach (Neighborhoods item in spacelessNeighborhoods)
            {
                if (item != null)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine($"- Neighborhood: {item.Neighborhood}");
                }
            }
            return spacelessNeighborhoods;
        }

        /***********************QUESTION 3 **************************/
        /// <summary>
        /// Method removes duplicates from JSON object
        /// </summary>
        /// <param name="neighborhoods">Enumerated parsed JSON objet</param>
        /// <returns>All neighborhoods less duplicates</returns>
        public static IEnumerable<Neighborhoods> RemoveDuplicates(IEnumerable<Neighborhoods> neighborhoods)
        {
            IEnumerable<Neighborhoods> spacelessNeighborhoods = from neigh in neighborhoods
                                                                where neigh.Neighborhood.Length > 0
                                                                select neigh;
            IEnumerable<Neighborhoods> removeDupe = spacelessNeighborhoods.GroupBy(n => n.Neighborhood).Select(p => p.First());

            foreach (Neighborhoods item in removeDupe)
            {
                if (item != null)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine($"- Neighborhood: {item.Neighborhood}");
                }
            }
            return removeDupe;
        }

        /***********************QUESTION 4 **************************/
        /// <summary>
        /// Method removes blanks, then groups neighborhoods and only selects first of each grouping, removing duplicates
        /// </summary>
        /// <param name="neighborhoods">List of neighborhoods</param>
        /// <returns>Filtered out list of neighborhoods</returns>
        public static IEnumerable<Neighborhoods> FilterNeighborhoods(List<Neighborhoods> neighborhoods)

        {
            var filterNeigh = neighborhoods.Where(p => p.Neighborhood.Length > 0).GroupBy(n => n.Neighborhood).Select( t => t.First());

            foreach (Neighborhoods item in filterNeigh)
            {
                if (item != null)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine($"- Neighborhood: {item.Neighborhood}");
                }
            }
            return filterNeigh;
        }

        /***********************QUESTION 5 **************************/
        /// <summary>
        /// Another example of a removal of blanks method utilizing lambda
        /// </summary>
        /// <param name="neighborhoods">List of neighborhoods</param>
        /// <returns>List of neighborhoods with removed spaces</returns>
        public static IEnumerable<Neighborhoods> RemoveBlanksTwo(List<Neighborhoods> neighborhoods)
        {
            IEnumerable<Neighborhoods> removeBlanks = neighborhoods.Where(p => p.Neighborhood != "");

            foreach (Neighborhoods item in removeBlanks)
            {
                if (item != null)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine($"- Neighborhood: {item.Neighborhood}");
                }
            }
            return removeBlanks;

        }

    }

}

