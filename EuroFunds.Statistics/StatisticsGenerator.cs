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

        public void GenerateAll()
        {
            //SumOfTotalProjectValuesForEachLocation();
            //NumberOfProjectsForEachLocation();
            //AverageTotalProjectValueForEachLocation();
            //SumOfTotalProjectValuesForEachYear();
            //NumberOfProjectsForEachYear();
            //AverageTotalProjectValueForEachYear();
            //SumByYearForMazowieckie();
            //NumByYearForMazowieckie();
            //AvgByYearForMazowieckie();
            SumByPriority();
            //AvgCoFinancingByTerritoryType();
        }

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
            
            JsonifyAndSaveToFile(map, "sumByLocation.json");

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

                JsonifyAndSaveToFile(map, "numByLocation.json");

                return map;
            }
        }

        public IDictionary<string, decimal> AverageTotalProjectValueForEachLocation()
        {
            var totalValues = SumOfTotalProjectValuesForEachLocation();
            var noProjects = NumberOfProjectsForEachLocation();

            var map = totalValues.ToDictionary(kv => kv.Key, kv => decimal.Round(kv.Value / noProjects[kv.Key], 2));
            JsonifyAndSaveToFile(map, "avgByLocation.json");

            return map;
        }

        public IDictionary<int, decimal> SumOfTotalProjectValuesForEachYear()
        {
            var map = new Dictionary<int, decimal>();

            using (var context = new EuroFundsContext())
            {
                foreach (var project in context.Projects.OrderBy(p => p.ProjectStartDate.Year))
                {
                    var year = project.ProjectStartDate.Year;

                    if (!map.ContainsKey(year))
                        map[year] = 0m;

                    map[year] += project.TotalProjectValue;
                }
            }

            JsonifyAndSaveToFile(map, "sumByYear.json");

            return map;
        }

        public IDictionary<int, int> NumberOfProjectsForEachYear()
        {
            var map = new Dictionary<int, int>();

            using (var context = new EuroFundsContext())
            {
                foreach (var project in context.Projects.OrderBy(p => p.ProjectStartDate.Year))
                {
                    var year = project.ProjectStartDate.Year;

                    if (!map.ContainsKey(year))
                        map[year] = 0;

                    map[year]++;
                }
            }

            JsonifyAndSaveToFile(map, "numByYear.json");

            return map;
        }

        public IDictionary<int, decimal> AverageTotalProjectValueForEachYear()
        {
            var totalValues = SumOfTotalProjectValuesForEachYear();
            var noProjects = NumberOfProjectsForEachYear();

            var map = totalValues.ToDictionary(kv => kv.Key, kv => decimal.Round(kv.Value/noProjects[kv.Key], 2));
            JsonifyAndSaveToFile(map, "avgByYear.json");

            return map;
        }

        public IDictionary<int, decimal> SumByYearForMazowieckie()
        {
            const string mazowieckie = "MAZOWIECKIE";

            using (var context = new EuroFundsContext())
            {
                var projects = context.ProjectLocations
                    .Where(pl => pl.Name == mazowieckie
                                 || pl.Name == ProjectLocation.WholeCountry.Name)
                    .SelectMany(pl => pl.Projects);

                var map = new Dictionary<int, decimal>();

                foreach (var project in projects.OrderBy(p => p.ProjectStartDate.Year))
                {
                    var year = project.ProjectStartDate.Year;

                    if (!map.ContainsKey(year))
                        map[year] = 0m;

                    map[year] += project.TotalProjectValue;
                }

                JsonifyAndSaveToFile(map, "sumByYearForMazowieckie.json");

                return map;
            }
        }

        public IDictionary<int, int> NumByYearForMazowieckie()
        {
            const string mazowieckie = "MAZOWIECKIE";

            using (var context = new EuroFundsContext())
            {
                var projects = context.ProjectLocations
                    .Where(pl => pl.Name == mazowieckie
                                 || pl.Name == ProjectLocation.WholeCountry.Name)
                    .SelectMany(pl => pl.Projects);

                var map = new Dictionary<int, int>();

                foreach (var project in projects.OrderBy(p => p.ProjectStartDate.Year))
                {
                    var year = project.ProjectStartDate.Year;

                    if (!map.ContainsKey(year))
                        map[year] = 0;

                    map[year]++;
                }

                JsonifyAndSaveToFile(map, "numByYearForMazowieckie.json");

                return map;
            }
        }

        public IDictionary<int, decimal> AvgByYearForMazowieckie()
        {
            var totalValues = SumByYearForMazowieckie();
            var noProjects = NumByYearForMazowieckie();

            var map = totalValues.ToDictionary(kv => kv.Key, kv => decimal.Round(kv.Value / noProjects[kv.Key], 2));
            JsonifyAndSaveToFile(map, "avgByYearForMazowieckie.json");

            return map;
        }

        public IDictionary<string, decimal> SumByPriority()
        {
            var map = new Dictionary<string, decimal>();

            using (var context = new EuroFundsContext())
            {
                var priorities = context.Priorities.ToList();

                foreach (var priority in priorities)
                {
                    if (!map.ContainsKey(priority.Name))
                        map[priority.Name] = 0m;

                    foreach (var project in priority.Measures.SelectMany(measure => measure.Projects))
                    {
                        map[priority.Name] += project.TotalProjectValue;
                    }
                }
            }

            JsonifyAndSaveToFile(map.OrderByDescending(kv => kv.Value), "sumByPriority.json");

            return map;
        }

        public IDictionary<string, float> AvgCoFinancingByTerritoryType()
        {
            var map = new Dictionary<string, float>();

            using (var context = new EuroFundsContext())
            {
                foreach (var territoryType in context.TerritoryTypes.ToList())
                {
                    map[territoryType.Name] = territoryType.Projects.Average(p => p.EUCofinancingRate);
                }
            }

            JsonifyAndSaveToFile(map, "avgCoFinancingByTerrType.json");

            return map;
        }
   
        private static void JsonifyAndSaveToFile(object value, string filename)
        {
            var json = JsonConvert.SerializeObject(value, Formatting.Indented);
            System.IO.File.WriteAllText(Path + filename, json);
        }

    }
}
