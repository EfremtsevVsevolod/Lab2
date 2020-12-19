using System;
using System.IO;

namespace Lab2
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("-----1-----");
                Directory.SetCurrentDirectory("..\\..\\..");
                string project_path = Directory.GetCurrentDirectory();
                string full_path = Path.Combine(project_path, "input.txt");

                V5DataOnGrid v5DataOnGridInstance = new V5DataOnGrid(full_path);
                Console.WriteLine(v5DataOnGridInstance.ToLongString("N1"));

                Console.WriteLine("-----2:v5MainCollection (AddDefaults and ToLongString)-----");
                V5MainCollection v5MainCollectionInstance = new V5MainCollection();
                v5MainCollectionInstance.AddDefaults();
                Console.WriteLine(v5MainCollectionInstance.ToLongString("N1"));

                Console.WriteLine("-----2:LINQ select results-----");
                Console.WriteLine($"v5MainCollectionInstance.Min = {v5MainCollectionInstance.Min}");

                Console.WriteLine("\nv5MainCollectionInstance.IterDataItemsFromCollectionWithMin " +
                    "enumerate:");
                foreach (var elem in v5MainCollectionInstance.IterDataItemsFromCollectionWithMin)
                {
                    Console.WriteLine(elem.ToString("N1"));
                }

                Console.WriteLine("\nv5MainCollectionInstance.IterVector2Target enumerate:");
                foreach (var elem in v5MainCollectionInstance.IterVector2Target)
                {
                    Console.WriteLine(elem.ToString("N2"));
                }

                Console.WriteLine("\nProgram finished successfully!");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"\nProgram finished with exception{exception.GetType()}!");
            }
        }
    }
}
