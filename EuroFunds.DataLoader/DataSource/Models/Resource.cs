using System;

namespace EuroFunds.DataLoader.DataSource.Models
{
    public class Resource
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
