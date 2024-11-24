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
        private List<int> dynamiclist;

        ////////////////// Constructor ////////////////// 
        public TargetArray(int length)
        {
            this.length = length; 
            dynamiclist = new List<int>(length);
        }

        ////////////////// Destructor ////////////////// 
        ~TargetArray()
        {
            Console.WriteLine("Object destroyed");
            dynamiclist = null; 
        }

        public void FillRandom()
        {
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
            string json = File.ReadAllText(filePath);
            var obj = JsonConvert.DeserializeObject<TargetArray>(json);
            Console.WriteLine(json);
            return obj;
        }
    }
}