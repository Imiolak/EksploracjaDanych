using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroFunds.Database.Models
{
    [Table("Subpriorities")]
    public class Subpriority
    {
        public int Id { get; set; }

        [StringLength(450)]
        [Index("IX_Subpriority", Order = 1, IsUnique = true)]
        public string Name { get; set; }

        public virtual Priority Priority { get; set; }

    }
}
