using EuroFunds.Database.DAO;
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
                        sb.Append($", {project.AreaOfEconomicActivity.OrderNo}");
                        sb.Append($", {project.TerritoryType.OrderNo}");

                        file.WriteLine(sb.ToString());
                    }
                }

                file.Close();
            }
        }
    }
}
