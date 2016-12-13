using EuroFunds.Database.Models;
using EuroFunds.Database.Repositories;
using EuroFunds.DataLoader.DataSource;
using EuroFunds.DataLoader.ResourceLoader;
using EuroFunds.DataLoader.ResourceLoader.Reader;
using System;
using System.Diagnostics;
using System.Linq;

namespace EuroFunds.DataLoader
{
    public class DataLoader
    {
        public void Load()
        {
            var stopwatch = Stopwatch.StartNew();
            Console.WriteLine("Loading projects..");

            var client = new DataSourceClient();

            var mostRecentInSource = client.GetMostRecentResource();
            var mostRecentInDb = ResourceRepository.GetMostRecentResource();

            if (NoResourcesInDbYet(mostRecentInDb)
                || WasNewResourceAdded(mostRecentInSource, mostRecentInDb)
                || WasLastResourceUpdated(mostRecentInSource, mostRecentInDb))
            {
                Console.WriteLine("New or updated reasource found. Downloading..");

                var downloadedResource = client.DownloadResource(mostRecentInSource);
                var projectLoader = new ProjectLoader(new OpenXmlResourceReader());

                Console.WriteLine("Reading resource..");

                var projectsInResource = projectLoader.Read(downloadedResource);
                var newProjects = ProjectRepository.FilterAlreadyExistingProjects(projectsInResource);

                Console.WriteLine($"{newProjects.Count()} new projects found. Adding to DB..");

                ProjectRepository.AddOrUpdateMany(newProjects);
                ResourceRepository.AddOrUpdate(mostRecentInSource);

                client.DeleteTemporaryDirectory();

                Console.WriteLine("Loading projects done.");
            }
            else
            {
                Console.WriteLine("No project to add..");
            }

            stopwatch.Stop();
            Console.WriteLine($"Took {stopwatch.Elapsed}");
        }

        #region Helpers
        private static bool NoResourcesInDbYet(Resource mostRecentInDb)
        {
            return mostRecentInDb == null;
        }

        private static bool WasNewResourceAdded(Resource mostRecentInSource, Resource mostRecentInDb)
        {
            return mostRecentInSource.Id != mostRecentInDb.Id;
        }

        private static bool WasLastResourceUpdated(Resource mostRecentInSource, Resource mostRecentInDb)
        {
            return mostRecentInSource.LastModified != null && mostRecentInSource.LastModified > mostRecentInDb.LastModified;
        }
        #endregion
    }
}
