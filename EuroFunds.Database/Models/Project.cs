using System;

namespace EuroFunds.Database.Models
{
    public class Project
    {
        public string ProjectName { get; set; }
        public string ProjectSummary { get; set; }
        public string ContractNumber { get; set; }
        public decimal TotalProjectValue { get; set; }
        public decimal TotalEligibleValue { get; set; }
        public decimal AmountOfEuCofinancing { get; set; }
        public float UnionCofinancingRate { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public bool UnderCompetative { get; set; }

        public int TeritoryTypeId { get; set; }
        public int MeasureId { get; set; }
        public int SubmeasureId { get; set; }
        public int ResourceId { get; set; }
        public int ProjectLocationId { get; set; }
        public int FundId { get; set; }
        public int FormOfFinanceId { get; set; }
        public int BeneficiaryNameId { get; set; }
        public int AreaOfEconomicActivityId { get; set; }
        public int AreaOfProjectInterventionId { get; set; }
    }
}
