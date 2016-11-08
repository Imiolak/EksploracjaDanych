using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int teritoryTypeId { get; set; }
        public int measureId { get; set; }
        public int submeasureId { get; set; }
        public int resourceId { get; set; }
        public int projectLocationId { get; set; }
        public int fundId { get; set; }
        public int formOfFinanceId { get; set; }
        public int beneficiaryNameId { get; set; }
        public int areaOfEconomicActivityId { get; set; }
        public int areaOfProjectInterventionId { get; set; }

    }
}
