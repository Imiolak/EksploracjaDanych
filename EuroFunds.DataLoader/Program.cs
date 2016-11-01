using EuroFunds.DataLoader.DataSource;

namespace EuroFunds.DataLoader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var client = new DataSourceClient())
            {
                var mostRecentResource = client.GetMostRecentResource();
                var file = client.DownloadResource(mostRecentResource);

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

        //private static void LoadResource(Resource mostRecentResource, DataSourceClient client)
        //{
        //    var file = client.DownloadResource(mostRecentResource);
        //    var projects = reader.ReadResource(file);
        //    var projectsToSave = db.FilterNewAndUpdatedProjects(projects);
        //}
    }
}
