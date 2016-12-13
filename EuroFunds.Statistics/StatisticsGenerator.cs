﻿using EuroFunds.Database.DAO;
using EuroFunds.Database.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace EuroFunds.Statistics
{
    public class StatisticsGenerator : IDisposable
    {
        private const string ChartsFolder = @"..\..\..\Charts\";

        private readonly EuroFundsContext _context;
        private IList<Project> _projects;
        private IList<int> _distinctYears;
        private IList<string> _distinctLocations;

        public StatisticsGenerator()
        {
            _context = new EuroFundsContext();
        } 

        public void Initialize()
        {
            _projects = _context.Projects.ToList();
            _distinctYears = GetDistinctYears().ToList();
            _distinctLocations = GetDistinctProjectLocations().ToList();
        }

        public void GenerateAll()
        {
            var stopwatch = Stopwatch.StartNew();
            Console.WriteLine($"Generating statistics. Output folder: {new DirectoryInfo(ChartsFolder).FullName}");

            SumOfTotalProjectValuesForEachLocation();
            NumberOfProjectsForEachLocation();
            AverageTotalProjectValueForEachLocation();
            SumOfTotalProjectValuesForEachYear();
            NumberOfProjectsForEachYear();
            AverageTotalProjectValueForEachYear();
            AverageProjectLengthByYearByRegion();
            AverageProjectLengthByYear();

            stopwatch.Stop();
            Console.WriteLine($"Took {stopwatch.Elapsed}");
        }

        public IDictionary<int, IDictionary<string, decimal>> SumOfTotalProjectValuesForEachLocation()
        {
            var distinctYears = GetDistinctYears();
            var distinctProjectLocations = GetDistinctProjectLocations();
            var map = PrepareDictionary<int, string, decimal>(distinctYears, distinctProjectLocations);
            
            foreach (var project in _projects)
            {
                var projectValue = project.TotalProjectValue;
                var year = project.ProjectStartDate.Year;
                var projectLocations = project.ProjectLocations.Select(pl => pl.Name).ToList();

                if (projectLocations.Count == 1 && projectLocations.First() == ProjectLocation.WholeCountry.Name)
                {
                    foreach (var projectLocation in map[year].Keys.ToList())
                    {
                        map[year][projectLocation] += projectValue;
                    }
                }
                else
                {
                    foreach (var projectLocation in projectLocations)
                    {
                        map[year][projectLocation] += projectValue;
                    }
                }
            }
            
            var chartBuilder = new ColumnChartBuilder<string, decimal>()
                .Title("Sum of projects total values for each location by years")
                .AxesTitles("Voivodeships", "Sum of projects total values (PLN)")
                .Height(400)
                .Width(1000)
                .WithLegend("Years");

            foreach (var yearSeries in map.OrderBy(entry => entry.Key))
            {
                chartBuilder.AddSeries(yearSeries.Key.ToString(), yearSeries.Value);
            }

            var chart = chartBuilder.Build();
            chart.SaveImage(Path.Combine(ChartsFolder, "sumByYearByRegion.png"), ChartImageFormat.Png);

            return map;
        }

        

        public IDictionary<int, IDictionary<string, int>> NumberOfProjectsForEachLocation()
        {
            var distinctYears = GetDistinctYears();
            var distinctProjectLocations = GetDistinctProjectLocations();
            var map = PrepareDictionary<int, string, int>(distinctYears, distinctProjectLocations);
            
            foreach (var project in _projects)
            {
                var year = project.ProjectStartDate.Year;
                var projectLocations = project.ProjectLocations.Select(pl => pl.Name).ToList();

                if (projectLocations.Count == 1 && projectLocations.First() == ProjectLocation.WholeCountry.Name)
                {
                    foreach (var projectLocation in map[year].Keys.ToList())
                    {
                        ++map[year][projectLocation];
                    }
                }
                else
                {
                    foreach (var projectLocation in projectLocations)
                    {
                        ++map[year][projectLocation];
                    }
                }
            }

            var chartBuilder = new ColumnChartBuilder<string, int>()
                .Title("Number of projects for each location by years")
                .AxesTitles("Voivodeships", "Number of projects")
                .Height(400)
                .Width(1000)
                .WithLegend("Years");

            foreach (var yearSeries in map.OrderBy(entry => entry.Key))
            {
                chartBuilder.AddSeries(yearSeries.Key.ToString(), yearSeries.Value);
            }

            var chart = chartBuilder.Build();
            chart.SaveImage(Path.Combine(ChartsFolder, "countByYearByRegion.png"), ChartImageFormat.Png);

            return map;
        }

        public IDictionary<int, IDictionary<string, decimal>> AverageTotalProjectValueForEachLocation()
        {
            var totalValues = SumOfTotalProjectValuesForEachLocation();
            var noProjects = NumberOfProjectsForEachLocation();
            var map = PrepareDictionary<int, string, decimal>(totalValues.Keys, totalValues.First().Value.Keys);

            foreach (var year in totalValues.Keys)
            {
                foreach (var projectLocation in totalValues[year].Keys)
                {
                    map[year][projectLocation] = noProjects[year][projectLocation] == 0 
                        ? 0m
                        : decimal.Round(totalValues[year][projectLocation]/noProjects[year][projectLocation], 2);
                }
            }

            var chartBuilder = new ColumnChartBuilder<string, decimal>()
                .Title("Average project's total value for each location by years")
                .AxesTitles("Voivodeships", "Average project's total value (PLN)")
                .Height(400)
                .Width(1000)
                .WithLegend("Years");

            foreach (var yearSeries in map.OrderBy(entry => entry.Key))
            {
                chartBuilder.AddSeries(yearSeries.Key.ToString(), yearSeries.Value);
            }

            var chart = chartBuilder.Build();
            chart.SaveImage(Path.Combine(ChartsFolder, "avgValueByYearByRegion.png"), ChartImageFormat.Png);

            return map;
        }

        public IDictionary<int, decimal> SumOfTotalProjectValuesForEachYear()
        {
            var years = GetDistinctYears();
            var map = PrepareDictionary<int, decimal>(years);
            
            foreach (var project in _projects.OrderBy(p => p.ProjectStartDate.Year))
            {
                var year = project.ProjectStartDate.Year;
                map[year] += project.TotalProjectValue;
            }

            var chart = new ColumnChartBuilder<int, decimal>()
                .Title("Sum of projects total values for each year")
                .AxesTitles("Years", "Sum of projects total values (PLN)")
                .Height(400)
                .Width(1000)
                .AddSeries("", map)
                .Build();

            chart.SaveImage(Path.Combine(ChartsFolder, "sumByYear.png"), ChartImageFormat.Png);

            return map;
        }

        public IDictionary<int, int> NumberOfProjectsForEachYear()
        {
            var years = GetDistinctYears();
            var map = PrepareDictionary<int, int>(years);
            
            foreach (var project in _projects.OrderBy(p => p.ProjectStartDate.Year))
            {
                var year = project.ProjectStartDate.Year;
                ++map[year];
            }

            var chart = new ColumnChartBuilder<int, int>()
                .Title("Number of projects for each year")
                .AxesTitles("Years", "Number of projects")
                .Height(400)
                .Width(1000)
                .AddSeries("", map)
                .Build();

            chart.SaveImage(Path.Combine(ChartsFolder, "countByYear.png"), ChartImageFormat.Png);

            return map;
        }

        public IDictionary<int, decimal> AverageTotalProjectValueForEachYear()
        {
            var totalValues = SumOfTotalProjectValuesForEachYear();
            var noProjects = NumberOfProjectsForEachYear();

            var map = totalValues.ToDictionary(kv => kv.Key, kv => decimal.Round(kv.Value/noProjects[kv.Key], 2));

            var chart = new ColumnChartBuilder<int, decimal>()
                .Title("Average project's total value for each year")
                .AxesTitles("Years", "Average project's total value (PLN)")
                .Height(400)
                .Width(1000)
                .AddSeries("", map)
                .Build();

            chart.SaveImage(Path.Combine(ChartsFolder, "avgByYear.png"), ChartImageFormat.Png);

            return map;
        }

        public IDictionary<int, IDictionary<string, double>> AverageProjectLengthByYearByRegion()
        {
            var counts = PrepareDictionary<int, string, int>(_distinctYears, _distinctLocations);
            var averages = PrepareDictionary<int, string, double>(_distinctYears, _distinctLocations);

            foreach (var project in _projects)
            {
                var length = project.GetProjectLength().TotalDays;
                var year = project.ProjectStartDate.Year;
                var projectLocations = project.ProjectLocations.Select(pl => pl.Name).ToList();

                if (projectLocations.Count == 1 && projectLocations.First() == ProjectLocation.WholeCountry.Name)
                {
                    foreach (var projectLocation in averages[year].Keys.ToList())
                    {
                        averages[year][projectLocation] = (averages[year][projectLocation] * counts[year][projectLocation] + length) / (counts[year][projectLocation] + 1);
                        ++counts[year][projectLocation];
                    }
                }
                else
                {
                    foreach (var projectLocation in projectLocations)
                    {
                        averages[year][projectLocation] = (averages[year][projectLocation] * counts[year][projectLocation] + length) / (counts[year][projectLocation] + 1);
                        ++counts[year][projectLocation];
                    }
                }
            }

            var chartBuilder = new ColumnChartBuilder<string, double>()
                .Title("Average project's length in days for each location by year")
                .AxesTitles("Years", "Average project's length (days)")
                .Height(400)
                .Width(1000);

            foreach (var yearSeries in averages.OrderBy(entry => entry.Key))
            {
                chartBuilder.AddSeries(yearSeries.Key.ToString(), yearSeries.Value);
            }

            var chart = chartBuilder.Build();

            chart.SaveImage(Path.Combine(ChartsFolder, "agvLengthByYearByLocation.png"), ChartImageFormat.Png);

            return averages;
        }

        public IDictionary<int, double> AverageProjectLengthByYear()
        {
            var counts = PrepareDictionary<int, int>(_distinctYears);
            var averages = PrepareDictionary<int, double>(_distinctYears);

            foreach (var project in _projects)
            {
                var year = project.ProjectStartDate.Year;

                averages[year] = (averages[year] * counts[year] + project.GetProjectLength().TotalDays) / (counts[year] + 1);
                ++counts[year];
            }

            var chart = new ColumnChartBuilder<int, double>()
                .Title("Average project's length in days for each year")
                .AxesTitles("Years", "Average project's length (days)")
                .Height(400)
                .Width(1000)
                .AddSeries("", averages)
                .Build();

            chart.SaveImage(Path.Combine(ChartsFolder, "agvLengthByYear.png"), ChartImageFormat.Png);
            
            return averages;
        }

        #region Helpers

        private IEnumerable<int> GetDistinctYears()
        {
            return _context.Projects
                .Select(project => project.ProjectStartDate.Year)
                .Distinct()
                .OrderBy(year => year)
                .ToList();
        }

        private IEnumerable<string> GetDistinctProjectLocations(bool excludeWholeCountry = true)
        {
            var distinctProjectLocations = _context.ProjectLocations
                .Select(pl => pl.Name)
                .Distinct()
                .OrderBy(pl => pl)
                .ToList();

            return excludeWholeCountry
                ? distinctProjectLocations.Where(pl => pl != ProjectLocation.WholeCountry.Name)
                : distinctProjectLocations;
        }

        private static IDictionary<T1, T2> PrepareDictionary<T1, T2>(IEnumerable<T1> t1Values)
        {
            var map = new Dictionary<T1, T2>();

            foreach (var t1Value in t1Values)
            {
                map[t1Value] = default(T2);
            }

            return map;
        }

        private static IDictionary<T1, IDictionary<T2, T3>> PrepareDictionary<T1, T2, T3>(IEnumerable<T1> t1Values, IEnumerable<T2> t2Values)
        {
            var map = new Dictionary<T1, IDictionary<T2, T3>>();

            foreach (var t1Value in t1Values)
            {
                map[t1Value] = new Dictionary<T2, T3>();

                foreach (var t2Value in t2Values)
                {
                    map[t1Value][t2Value] = default(T3);
                }
            }

            return map;
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            _context.Dispose();
        }

        #endregion
    }
}
