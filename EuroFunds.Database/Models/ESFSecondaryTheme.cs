using System.Collections.Generic;

namespace EuroFunds.Database.Models
{
    public class ESFSecondaryTheme
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
