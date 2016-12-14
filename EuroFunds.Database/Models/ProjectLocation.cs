using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static System.Char;

namespace EuroFunds.Database.Models
{
    [Table("ProjectLocations")]
    public class ProjectLocation
    {
        [NotMapped]
        public static ProjectLocation WholeCountry => new ProjectLocation
        {
            Name = "Cały Kraj"
        };

        public int Id { get; set; }

        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

        public static bool IsInPoland(string value)
        {
            return value.All(t => !IsLetter(t) || IsUpper(t));
        }
    }
}
