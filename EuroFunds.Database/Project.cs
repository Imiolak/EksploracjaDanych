using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroFunds.Database
{
    public class Project
    {
        public String projectName { get; set; }
        public String projectSummary { get; set; }
        public String contractNumber { get; set; }
        public int totalProjectValue { get; set; }
        public int totalEligibleValue { get; set; }
        public int amountOfEuCofinancing { get; set; }
        public int unionCofinancingRate { get; set; }
        public DateTime projectStartDate { get; set; }
        public DateTime projectEndDate { get; set; }
        public String underCompetative { get; set; }
    }
}
