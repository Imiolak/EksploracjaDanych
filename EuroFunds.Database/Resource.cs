using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroFunds.Database
{
    class Resource
    {
        public int id { get; set; }
        public String name { get; set; }
        public String url { get; set; }
        public bool dataLoaded { get; set; }
        public ICollection<Project> projects { get; set; }
    }
}
