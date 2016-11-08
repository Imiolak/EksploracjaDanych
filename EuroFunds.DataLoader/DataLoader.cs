using EuroFunds.DataLoader.DataSource;
using EuroFunds.DataLoader.ResourceLoader;
using EuroFunds.DataLoader.ResourceLoader.Reader;
using System.IO;

namespace EuroFunds.DataLoader
{
    public class DataLoader
    {
        private const string TmpFileSourcePath = @"D:\Storage\Uni\9\Eksploracja\Projekt\Sample\Lista_projektow_FE_2014_2020_011116.xlsx";

        public void Load()
        {
            var loader = new ProjectLoader(new OpenXmlResourceReader());
            var projects = loader.Read(new FileInfo(TmpFileSourcePath));

            using (var client = new DataSourceClient())
            {
            }
        }
    }
}
