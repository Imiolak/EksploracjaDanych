using System;
using EuroFunds.DataLoader.DataSource;
using EuroFunds.DataLoader.DataSource.Models;
using EuroFunds.DataLoader.ResourceLoader;
using EuroFunds.DataLoader.ResourceLoader.Reader;
using System.IO;

namespace EuroFunds.DataLoader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var date = DateTime.FromOADate(42417);

            var loader = new ProjectLoader(new OpenXmlResourceReader());
            loader.Read(
                new FileInfo(
                    @"D:\Storage\Uni\9\Eksploracja\Projekt\Sample\Lista_projektow_FE_2014_2020_011116.xlsx"));
            
            using (var client = new DataSourceClient())
            {
                //var mostRecentResource = client.GetMostRecentResource();
                
                //LoadResource(mostRecentResource, client);

                //TODO database
                //var lastLoadedResource = db.GetLastLoadedResource();

                //if (lastLoadedResource == null || mostRecentResource.Created > lastLoadedResource.Created)
                //{
                //    db.AddResource(mostRecentResource);
                //    LoadResource(mostRecentResource, client);
                //}
                //else if (mostRecentResource.LastModified > lastLoadedResource.LastModified)
                //{
                //    db.UpdateResource(mostRecentResource);
                //    LoadResource(mostRecentResource, client);
                //}
            }
        }

        private static void LoadResource(Resource mostRecentResource, DataSourceClient client)
        {
            //var reader = new ProjectLoader();

            //var file = client.DownloadResource(mostRecentResource);
            //var projects = reader.Read(file);
            //var projectsToSave = db.FilterNewAndUpdatedProjects(projects);
        }
    }
}
