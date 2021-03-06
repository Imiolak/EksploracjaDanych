﻿using EuroFunds.Database.DAO;
using EuroFunds.Database.Models;
using System.IO;
using System.Linq;
using System.Text;

namespace EuroFunds.Runner
{
    public class ProjectFileOutput
    {
        private const string OutputFilePath = @"..\..\..\Knime\EuroFunds\data\projects.txt";

        public static void WriteAllProjectsToFile()
        {
            using (var file = new StreamWriter(OutputFilePath))
            {
                using (var context = new EuroFundsContext())
                {
                    var projects = context.Projects.ToList();

                    foreach (var project in projects)
                    {
                        var sb = new StringBuilder();
                        sb.Append(project.TotalProjectValue);
                        sb.Append($", {project.ProjectStartDate.Year}");
                        sb.Append($", {project.GetProjectLength().TotalDays}");
                        sb.Append($", {project.AreaOfEconomicActivity.OrderNo}, ");

                        var baseString = sb.ToString();

                        foreach (var projectLocation in project.ProjectLocations)
                        {
                            if (projectLocation.Name == ProjectLocation.WholeCountry.Name)
                            {
                                foreach (var location in
                                        context.ProjectLocations.ToList().Where(pl => ProjectLocation.IsInPoland(pl.Name)))
                                {
                                    file.WriteLine($"{baseString}{location.Name}");
                                }
                            }
                            else
                            {
                                file.WriteLine($"{baseString}{projectLocation.Name}");
                            }
                        }

                        
                    }
                }

                file.Close();
            }
        }
    }
}
