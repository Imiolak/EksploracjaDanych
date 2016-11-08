using System.Collections.Generic;

namespace EuroFunds.Database.Models
{
    public class Priority
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Measure> Measures { get; set; } = new List<Measure>();
    }
}
