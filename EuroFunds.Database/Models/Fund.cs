using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EuroFunds.Database.Models
{
    public class Fund
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
