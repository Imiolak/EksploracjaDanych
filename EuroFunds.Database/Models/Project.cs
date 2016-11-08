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

        public virtual TeritoryType TeritoryType{ get; set; }
        public virtual Measure Measure{ get; set; }
        public virtual Submeasure Submeasure { get; set; }
        public virtual ProjectLocation ProjectLocation { get; set; }
        public virtual Fund Fund { get; set; }
        public virtual FormOfFinance FormOfFinance { get; set; }
        public virtual BeneficiaryName BeneficiaryName { get; set; }
        public virtual AreaOfEconomicActivity AreaOfEconomicActivity { get; set; }
        public virtual AreaOfProjectIntervention AreaOfProjectIntervention { get; set; }
    }
}
