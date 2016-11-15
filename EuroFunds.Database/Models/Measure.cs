using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroFunds.Database.Models
{
    [Table("Measures")]
    public class Measure
    {
        public int Id { get; set; }

        [StringLength(8)]
        [Index("IX_Measure", Order = 1, IsUnique = true)]
        public string OrderNo { get; set; }

        [StringLength(450)]
        [Index("IX_Measure", Order = 2, IsUnique = true)]
        public string Name { get; set; }

        public virtual Priority Priority { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Submeasure> Submeasures { get; set; }

        #region Equality Members
        protected bool Equals(Measure other)
        {
            return string.Equals(OrderNo, other.OrderNo, StringComparison.InvariantCultureIgnoreCase) 
                && string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((Measure) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((OrderNo != null ? OrderNo.GetHashCode() : 0)*397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }

        public static bool operator ==(Measure left, Measure right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Measure left, Measure right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}
