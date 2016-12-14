using System;

namespace EuroFunds.Runner
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var loader = new DataLoader.DataLoader();
            //loader.Load();

            //using (var statisticsGenerator = new StatisticsGenerator())
            //{
            //    statisticsGenerator.Initialize();
            //    statisticsGenerator.GenerateAll();
            //}

            ProjectFileOutput.WriteAllProjectsToFile();
            
            Console.WriteLine(@"Finished. Waiting for keypress..");
            Console.ReadKey();
        }
    }
}
