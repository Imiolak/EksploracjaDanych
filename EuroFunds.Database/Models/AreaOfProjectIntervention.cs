using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroFunds.Database.Models
{
    [Table("AreasOfProjectIntervention")]
    public class AreaOfProjectIntervention
    {
        public int Id { get; set; }

        [StringLength(3)]
        [Index(IsUnique = true)]
        public string OrderNo { get; set; }

        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
