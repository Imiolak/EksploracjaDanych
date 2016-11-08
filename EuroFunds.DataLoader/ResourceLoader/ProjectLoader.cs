using EuroFunds.DataLoader.ResourceLoader.Reader;
using EuroFunds.DataLoader.Temp;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EuroFunds.DataLoader.ResourceLoader
{
    public class ProjectLoader
    {
        private readonly IResourceReader _reader;

        public ProjectLoader(IResourceReader reader)
        {
            _reader = reader;
        }

        public IEnumerable<Project> Read(FileInfo resource)
        {
            var rows = _reader.ReadRows(resource);

            return Enumerable.Empty<Project>();
        }
    }

    internal static class PropertyMapper
    {
        private static readonly Dictionary<string, int> Columns = new Dictionary<string, int>
        {
            { "ProjectName", 1 },
            { "ProjectSummary", 2 },
            { "ContractNumber", 3 },
            { "TotalValue", 10 },
            { "TotalEligible", 11 },
            { "CoFinancingAmount", 12 },
            { "CoFinancingRate", 13 },
            { "StartDate", 17 },
            { "EndDate", 18 },
            { "IsCompetitive", 19 }
        };
    }
}
