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
            RemoveDuplicates((ReadJson()));
            RemoveBlanksTwo(ReadJson());
            FilterNeighborhoods(ReadJson());
            Console.ReadLine();
            


        }

        /// <summary>
        /// Method to return a list containing all neighborhoods
        /// </summary>
        /// <returns></returns>
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

