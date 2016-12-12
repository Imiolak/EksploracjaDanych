using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroFunds.Statistics;

namespace EuroFunds.Viewer.Controllers
{
    public class StatsController : Controller
    {
        // GET: Stats
        public string Index()
        {
            return "Come here and get some awesome stats!";
        }

        // GET: Stats/Projects
        public string Projects()
        {
            var statistics = new Statistics.StatisticsGenerator();
            return statistics.SumOfTotalProjectValuesForEachLocation();
        }
        // GET: Stats/ProjectsPerLocation
        public string ProjectsPerLocation()
        {
            var statistics = new Statistics.StatisticsGenerator();
            return statistics.NumberOfProjectsForEachLocation();
        }
    }
}