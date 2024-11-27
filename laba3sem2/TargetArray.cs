using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;


namespace laba3sem2
{
    public class TargetArray
    {
        public int length { get; private set; }
        private List<int> dynamiclist { get; set; }

        ////////////////// Constructor ////////////////// 
        public TargetArray(int length)
        {
            Console.WriteLine($"Dynamic list created");
            this.length = length; 
            dynamiclist = new List<int>(length);
        }

        ////////////////// Destructor ////////////////// 
        public void Dispose()
        {
            Console.WriteLine("\nObject disposed\n");
            dynamiclist = null; 
            GC.SuppressFinalize(this);
        }

        public void FillRandom()
        {
            Console.WriteLine("\nArray filled with random numbers");
            var random = new Random();
            dynamiclist.Clear(); 
            for (int i = 0; i < length; i++)
            {
                dynamiclist.Add(random.Next(-10, 11)); 
            }
        }

        public int UniqSeeker()
        {
            return dynamiclist.Distinct().Count();
        }

        public void Shuffler()
        {
            Console.WriteLine("\nArray shuffled");
            var rand = new Random();
            for (int i = length - 1; i > 0; i--)
            {
                int randpos = rand.Next(0, i + 1);
                int temp = dynamiclist[i];
                dynamiclist[i] = dynamiclist[randpos];
                dynamiclist[randpos] = temp;
            }
        }

        public void Printer()
        {
            Console.WriteLine("Array: " + string.Join(", ", dynamiclist));
        }

        ////////////////// SAVE TO JSON ////////////////// 
        public void SaveToJson(string filePath)
        {
            var data = new
            {
                length = this.length,
                dynamiclist = this.dynamiclist
            };

            string json = JsonConvert.SerializeObject(data, Formatting.None);
            File.WriteAllText(filePath, json);
            Console.WriteLine($"\nObject saved to {filePath}");
        }

        ////////////////// LOAD FROM JSON ////////////////// 
        public static TargetArray LoadFromJson(string filePath)
        {
            Console.WriteLine("\nLoaded data from json file:");
            string json = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<dynamic>(json);

            int length = (int)data.length;

            List<int> dynamicList = ((Newtonsoft.Json.Linq.JArray)data.dynamiclist).Select(x => (int)x).ToList();

            TargetArray loadedArray = new TargetArray(length)
            {
                dynamiclist = dynamicList 
            };

            Console.WriteLine("\nObject loaded from JSON:");
            Console.WriteLine(json);

            return loadedArray;
        }

    }
}