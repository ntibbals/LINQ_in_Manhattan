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
            Console.WriteLine("Hello World!");
            DisplayNeighborhoods(ReadJson());
            RemoveNeighborhoodBlanks(ReadJson());
            RemoveDuplicates(RemoveNeighborhoodBlanks(ReadJson()));
            RemoveBlanksTwo(ReadJson());
            FilterNeighborhoods(ReadJson());
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
                    Console.WriteLine(item.Neighborhood);
                }
            }

            return neighborhoods;
        }

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
                    Console.WriteLine(item.Neighborhood);
                }
            }

            return spacelessNeighborhoods;
        }

        /// <summary>
        /// Method removes duplicates from JSON object, recommend cascading remove neighborhood within method calling readjson within remove neighborhood
        /// </summary>
        /// <param name="neighborhoods">Enumerated parsed JSON objet</param>
        /// <returns>All neighborhoods less duplicates</returns>
        public static IEnumerable<Neighborhoods> RemoveDuplicates(IEnumerable<Neighborhoods> neighborhoods)
        {
            IEnumerable<Neighborhoods> removeDupe = neighborhoods.GroupBy(n => n.Neighborhood).Select(p => p.First());

            foreach (Neighborhoods item in removeDupe)
            {
                if (item != null)
                {
                    Console.WriteLine(item.Neighborhood);
                }
            }

            return removeDupe;
        }

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
                    Console.WriteLine(item.Neighborhood);
                }
            }

            return filterNeigh;
        }

        /// <summary>
        /// Another example of a removal of blanks method utilizing lambda
        /// </summary>
        /// <param name="neighborhoods">List of neighborhoods</param>
        /// <returns>List of neighborhoods with removed spaces</returns>
        public static IEnumerable<Neighborhoods> RemoveBlanksTwo(List<Neighborhoods> neighborhoods)
        {
            IEnumerable<Neighborhoods> removeBlanks = neighborhoods.Where(p => p.Neighborhood.Length > 0);
            foreach (Neighborhoods item in removeBlanks)
            {
                if (item != null)
                {
                    Console.WriteLine(item.Neighborhood);
                }
            }

            return removeBlanks;

        }

    }

}

