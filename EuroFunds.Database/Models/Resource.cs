using System;

namespace EuroFunds.Database.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastChangedDate { get; set; }
    }
}
