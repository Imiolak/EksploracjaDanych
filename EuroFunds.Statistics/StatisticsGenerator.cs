using EuroFunds.Database.DAO;
using EuroFunds.Database.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace EuroFunds.Statistics
{
    public class StatisticsGenerator
    {
        private const string Path = @"..\..\..\EuroFunds.Viewer\Views\Home\";

        public IDictionary<string, decimal> SumOfTotalProjectValuesForEachLocation()
        {
            var map = new Dictionary<string, decimal>();

            using (var context = new EuroFundsContext())
            {
                var projectLocations = context.ProjectLocations.ToList();

                foreach (var projectLocation in projectLocations.Where(pl => pl.Name != ProjectLocation.WholeCountry.Name))
                {
                    map[projectLocation.Name] = projectLocation.Projects.Sum(project => project.TotalProjectValue);
                }

                foreach (var projectValue in projectLocations
                    .Single(pl => pl.Name == ProjectLocation.WholeCountry.Name)
                    .Projects
                    .Select(project => project.TotalProjectValue))
                {
                    foreach (var key in map.Keys.ToList())
                    {
                        map[key] += projectValue;
                    }
                }
            }

            var json = JsonConvert.SerializeObject(map, Formatting.Indented);
            System.IO.File.WriteAllText(Path + "sum.json", json);

            return map;
        }

        public IDictionary<string, int> NumberOfProjectsForEachLocation()
        {
            using (var context = new EuroFundsContext())
            {
                var projectLocations = context.ProjectLocations.ToList();

                var map = projectLocations
                    .Where(pl => pl.Name != ProjectLocation.WholeCountry.Name)
                    .ToDictionary(pl => pl.Name, pl => pl.Projects.Count);

                var wholeCountryProjects = projectLocations
                    .Single(pl => pl.Name == ProjectLocation.WholeCountry.Name)
                    .Projects
                    .Count;

                foreach (var key in map.Keys.ToList())
                {
                    map[key] += wholeCountryProjects;
                }

                var json = JsonConvert.SerializeObject(map, Formatting.Indented);
                System.IO.File.WriteAllText(Path + "num.json", json);

                return map;
            }
        }

        public IDictionary<string, decimal> AverageTotalProjectValueForEachLocation()
        {
            var totalValues = SumOfTotalProjectValuesForEachLocation();
            var noProjects = NumberOfProjectsForEachLocation();

            var map = totalValues.ToDictionary(kv => kv.Key, kv => decimal.Round(kv.Value / noProjects[kv.Key], 2));

            var json = JsonConvert.SerializeObject(map, Formatting.Indented);
            System.IO.File.WriteAllText(Path + "avg.json", json);

            return map;
        }

    }
}
