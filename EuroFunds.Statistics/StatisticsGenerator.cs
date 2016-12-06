using EuroFunds.Database.DAO;
using EuroFunds.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace EuroFunds.Statistics
{
    public class StatisticsGenerator
    {
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

            return map;
        }

        public IDictionary<string, int> NumberOfProjectsForEachLocation()
        {
            using (var context = new EuroFundsContext())
            {
                var map = context.ProjectLocations
                    .Where(pl => pl.Name != ProjectLocation.WholeCountry.Name)
                    .ToDictionary(pl => pl.Name, pl => pl.Projects.Count);

                var wholeCountryProjects = context.ProjectLocations
                    .Single(pl => pl.Name != ProjectLocation.WholeCountry.Name)
                    .Projects
                    .Count;

                foreach (var key in map.Keys.ToList())
                {
                    map[key] += wholeCountryProjects;
                }

                return map;
            }
        }

        public IDictionary<string, decimal> AverageTotalProjectValueForEachLocation()
        {
            var totalValues = SumOfTotalProjectValuesForEachLocation();
            var noProjects = NumberOfProjectsForEachLocation();

            return totalValues.ToDictionary(kv => kv.Key, kv => kv.Value / noProjects[kv.Key]);
        }
    }
}
