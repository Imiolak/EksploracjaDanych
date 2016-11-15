using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroFunds.Database.Models
{
    [Table("Beneficiaries")]
    public class Beneficiary
    {
        public int Id { get; set; }

        [MaxLength(300)]
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
