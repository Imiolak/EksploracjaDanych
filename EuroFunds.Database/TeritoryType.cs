﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroFunds.Database
{
    class TeritoryType
    {
        public int id { get; set; }
        public String name { get; set; }
        public ICollection<Project> projects { get; set; }
    }
}
