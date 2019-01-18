using System;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using Lab08_LINQ_Manhattan.Classes;
using System.Collections.Generic;

namespace Lab08_LINQ_Manhattan
{
    class Program
    {
        public static string Path = "../../../../../data.json";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ReadJson();
            
        }

        public static List<Properties> ReadJson()
        {
            JObject propObject = JObject.Parse(File.ReadAllText(@"../../../../../data.json"));
            Console.WriteLine(propObject);
            var newObject = propObject["features"];
            List<Properties> listProps = new List<Properties>();
            foreach (var p in newObject)
            {


                Properties props = new Properties
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
            foreach (Properties item in listProps)
            {
                if (item != null)
                {
                    Console.Write(item.Neighborhood);
                }
            }
            return listProps;
        }
    }
}
