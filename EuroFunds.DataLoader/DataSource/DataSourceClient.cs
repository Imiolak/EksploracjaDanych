using EuroFunds.DataLoader.DataSource.Models;
using RestSharp;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace EuroFunds.DataLoader.DataSource
{
    public class DataSourceClient : IDisposable
    {
        private const string BaseUrl = "https://danepubliczne.gov.pl";
        private const string RequestResource = "api/3/action/package_show";
        private const string ParameterName = "id";
        private const string ParameterValue = "lista-beneficjentow-funduszy-europejskich-2014-2020";
        private const string TempDownloadFolder = "Temp";

        public Resource GetMostRecentResource()
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(RequestResource, Method.GET)
            {
                RootElement = "result",
                Parameters =
                {
                    new Parameter
                    {
                        Name = ParameterName,
                        Value = ParameterValue,
                        Type = ParameterType.QueryString
                    }
                }
            };

            var response = client.Execute<Result>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception();
            }

            return response.Data.Resources.OrderByDescending(resource => resource.Created).First();
        }

        public FileInfo DownloadResource(Resource resource)
        {
            var fileName = GetFileNameFromUrl(resource.Url);
            var fileInfo = new FileInfo(Path.Combine(TempDownloadFolder, fileName));

            using (var webClient = new WebClient())
            {
                var data = webClient.DownloadData(resource.Url);
                Directory.CreateDirectory(fileInfo.DirectoryName);

                using (var stream = fileInfo.Create())
                {
                    stream.Write(data, 0, data.Length);
                }
            }

            return fileInfo;
        }

        public void Dispose()
        {
            Directory.Delete(TempDownloadFolder, recursive: true);
        }

        private static string GetFileNameFromUrl(string url)
        {
            return url.Split('/').Last();
        }
    }
}
