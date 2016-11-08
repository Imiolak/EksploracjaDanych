using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroFunds.Database
{
    class Measure
    {
        public int id { get; set; }
        public String name { get; set; }
        public int submeasureId { get; set; }
        public int priorityId { get; set; }
    }
}
