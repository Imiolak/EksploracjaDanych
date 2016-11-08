using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EuroFunds.Database.Models
{
    public class Beneficiary
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
