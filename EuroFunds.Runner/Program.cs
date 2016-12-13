using EuroFunds.Statistics;

namespace EuroFunds.Runner
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var loader = new DataLoader.DataLoader();
            //loader.Load();

            var statisticsGenerator = new StatisticsGenerator();
            statisticsGenerator.GenerateAll();
            //statisticsGenerator.SumOfTotalProjectValuesForEachLocation();
            //statisticsGenerator.NumberOfProjectsForEachLocation();
            //statisticsGenerator.AverageTotalProjectValueForEachLocation();
            //statisticsGenerator.SumOfTotalProjectValuesForEachYear();
            //do sth with stats here
        }
    }
}
