using System;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;

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

        static void ReadJson()
        {
            JObject cityObject = JObject.Parse(File.ReadAllText(@"../../../../../data.json"));
            Console.WriteLine(cityObject);           
        }
    }
}
