﻿using System.Collections.Generic;

namespace EuroFunds.Database.Models
{
    public class Measure
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public string Name { get; set; }
        
        public virtual Priority Priority { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Submeasure> Submeasures { get; set; }
    }
}
