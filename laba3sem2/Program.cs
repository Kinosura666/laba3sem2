using System;
using Newtonsoft.Json;



namespace laba3sem2
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            TargetArray workingarray = new TargetArray(20); // Object - list size 
             
            workingarray.FillRandom();
            workingarray.Printer();

            int uniqs1 = workingarray.UniqSeeker();
            Console.WriteLine($"\nAmount of unique values in array: {uniqs1}");

            workingarray.Shuffler();
            workingarray.Printer();

            string filePath = "C:\\Users\\korni\\source\\repos\\laba3sem2\\laba3sem2\\bin\\Debug\\net8.0\\array.json";
            workingarray.SaveToJson(filePath);

            workingarray.Dispose();

            Console.ForegroundColor= ConsoleColor.Blue;
            TargetArray loadedarray = TargetArray.LoadFromJson(filePath);
            loadedarray.Printer();

            loadedarray.Shuffler();

            int uniqs2 = loadedarray.UniqSeeker();
            Console.WriteLine($"\nAmount of unique values in array: {uniqs2}");

            loadedarray.Printer();

            Console.ReadLine();
        }
    }
}