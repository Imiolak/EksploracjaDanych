using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroFunds.Database.Models
{
    [Table("Priorities")]
    public class Priority
    {
        public int Id { get; set; }

        [StringLength(4)]
        [Index("IX_Priority", Order = 1, IsUnique = true)]
        public string OrderNo { get; set; }

        [StringLength(450)]
        [Index("IX_Priority", Order = 2, IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Measure> Measures { get; set; } = new List<Measure>();

        public virtual ICollection<Subpriority> Subpriorities { get; set; } = new List<Subpriority>();

        #region Equality Members
        protected bool Equals(Priority other)
        {
            return string.Equals(OrderNo, other.OrderNo, StringComparison.InvariantCultureIgnoreCase) 
                && string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((Priority)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((OrderNo != null ? OrderNo.GetHashCode() : 0) * 397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }

        public static bool operator ==(Priority left, Priority right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Priority left, Priority right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}
