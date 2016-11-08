using System.Collections.Generic;
using System.IO;

namespace EuroFunds.DataLoader.ResourceLoader.Reader
{
    public interface IResourceReader
    {
        IEnumerable<string[]> ReadRows(FileInfo resource);
    }
}
