using EuroFunds.Database.Models;
using EuroFunds.DataLoader.ResourceLoader.Reader;
using System.Collections.Generic;
using System.IO;

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

            return ProjectFactory.CreateFromManyStringArrays(rows);
        }
    }
}
