using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroFunds.Database.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectSummary { get; set; }

        [MaxLength(25)]
        public string ContractNumber { get; set; }

        public decimal TotalProjectValue { get; set; }
        public decimal TotalEligibleValue { get; set; }
        public decimal AmountOfEUCofinancing { get; set; }
        public float EUCofinancingRate { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public bool UnderCompetetive { get; set; }

        public virtual Beneficiary Beneficiary { get; set; }
        public virtual Fund Fund { get; set; }
        public virtual Programme Programme { get; set; }
        public virtual Measure Measure { get; set; }
        public virtual Submeasure Submeasure { get; set; }
        public virtual FormOfFinance FormOfFinance { get; set; }
        public virtual ProjectLocation ProjectLocation { get; set; }
        public virtual TerritoryType TerritoryType{ get; set; }
        public virtual AreaOfEconomicActivity AreaOfEconomicActivity { get; set; }
        public virtual AreaOfProjectIntervention AreaOfProjectIntervention { get; set; }
        public virtual ProjectObjective ProjectObjective { get; set; }
        public virtual ESFSecondaryTheme ESFSecondaryTheme { get; set; }
        public virtual ImplementedUnderTerritorialDeliveryMechanisms ImplementedUnderTerritorialDeliveryMechanisms { get; set; }

        [NotMapped]
        public Priority Priority { get; set; }
    }
}
