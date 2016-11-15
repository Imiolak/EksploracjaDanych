using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroFunds.Database.Models
{
    [Table("Submeasures")]
    public class Submeasure
    {
        [NotMapped]
        public static Submeasure NullSubmeasure => new Submeasure
        {
            OrderNo = "0",
            Name = "Brak"
        };

        public int Id { get; set; }

        [StringLength(12)]
        [Index("IX_Submeasure", Order = 1, IsUnique = true)]
        public string OrderNo { get; set; }

        [StringLength(450)]
        [Index("IX_Submeasure", Order = 2, IsUnique = true)]
        public string Name { get; set; }

        public virtual Measure Measure { get; set; }
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
        
        #region Equality Members
        protected bool Equals(Submeasure other)
        {
            return string.Equals(OrderNo, other.OrderNo, StringComparison.InvariantCultureIgnoreCase) 
                && string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((Submeasure) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((OrderNo != null ? OrderNo.GetHashCode() : 0)*397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }

        public static bool operator ==(Submeasure left, Submeasure right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Submeasure left, Submeasure right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}
