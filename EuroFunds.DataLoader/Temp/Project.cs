using System;

namespace EuroFunds.DataLoader.Temp
{
    public class Project
    {
        public string ProjectName { get; set; }
        public string ProjectSummary { get; set; }
        public string ContractNumber { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TotalEligible { get; set; }
        public decimal CoFinancingAmount { get; set; }
        public float CoFinancingRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompetitive { get; set; }
    }
}
