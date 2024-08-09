using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Exp1
{
    internal class Program
    {
        public class CoilLoad
        {
            public int Index { get; set; }
            public double SetCoilLoad { get; set; }
        }
        public class CoilData
        {
            public string Key_CoilName { get; set; }
            public List<CoilLoad> Value_CoilLoad { get; set; }
        }

        static void Main(string[] args)
        {
            // Load JSON data from file
            string jsonFilePath = "C:\\Users\\GRL\\Downloads\\BPP_Loads.json";
            string jsonData = File.ReadAllText(jsonFilePath);

            // Deserialize JSON data to a list of CoilData objects
            List<CoilData> coilDataList = JsonConvert.DeserializeObject<List<CoilData>>(jsonData);

            // Prompt user for input
            Console.Write("Enter the coil name: ");
            string coilName = Console.ReadLine();

            // Search for the coil name in the list
            CoilData coil = coilDataList.Find(c => c.Key_CoilName.Equals(coilName, StringComparison.OrdinalIgnoreCase));
            //
            if (coil != null)
            {
                Console.WriteLine($"Coil Loads for {coilName}:");
                Console.ReadLine();
                //load represents each individual item in the coil.Value_CoilLoad collection during each iteration of the loop.
                foreach (var load in coil.Value_CoilLoad)
                {
                    Console.WriteLine($"Index: {load.Index}, SetCoilLoad: {load.SetCoilLoad}");
                    Console.ReadLine();

                }
            }
            else
            {
                Console.WriteLine("Coil name not found.");
            }
        }
    }
}
