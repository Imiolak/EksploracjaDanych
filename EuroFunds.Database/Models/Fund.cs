using System.Collections.Generic;

namespace EuroFunds.Database.Models
{
    public class Fund
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
