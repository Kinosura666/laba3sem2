using System;
using Newtonsoft.Json;



namespace laba3sem2
{
    class Program
    {
        static void Main()
        { 
            TargetArray workingarray = new TargetArray(20); // Object - list size 
            Console.WriteLine($"Dynamic list created");

            workingarray.FillRandom();
            Console.WriteLine("\nArray filled with random numbers");
            workingarray.Printer();

            int distinctCount = workingarray.UniqSeeker();
            Console.WriteLine($"\nAmount of unique values in array: {distinctCount}");

            workingarray.Shuffler();
            Console.WriteLine("\nArray shuffled");
            workingarray.Printer();

            string filePath = "C:\\Users\\korni\\source\\repos\\laba3sem2\\laba3sem2\\bin\\Debug\\net8.0\\array.json";
            workingarray.SaveToJson(filePath);

            Console.WriteLine("\nLoaded data from json file:");
            TargetArray loadedarray = TargetArray.LoadFromJson(filePath);

            Console.ReadLine();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}