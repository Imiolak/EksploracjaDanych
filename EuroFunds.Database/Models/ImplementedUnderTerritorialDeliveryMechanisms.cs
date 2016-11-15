using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroFunds.Database.Models
{
    [Table("ImplementedUnderTerritorialDeliveryMechanisms")]
    public class ImplementedUnderTerritorialDeliveryMechanisms
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
