using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroFunds.Database.Models
{
    [Table("Measures")]
    public class Measure
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public string Name { get; set; }
        
        public virtual Priority Priority { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Submeasure> Submeasures { get; set; }
    }
}
