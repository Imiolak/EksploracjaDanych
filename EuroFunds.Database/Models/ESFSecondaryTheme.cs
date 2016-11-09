using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroFunds.Database.Models
{
    [Table("ESFSecondaryThemes")]
    public class ESFSecondaryTheme
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
