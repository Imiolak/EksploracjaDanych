using EuroFunds.Database.Models;
using System.Data.Entity;

namespace EuroFunds.Database.DAO
{
    public class EuroFundsContext : DbContext
    {
        public EuroFundsContext() : base("name=EuroFundsContext")
        {
        }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Project> Projects { get; set; }
        
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<Fund> Funds { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Submeasure> Submeasures { get; set; }
        public DbSet<FormOfFinance> FormsOfFinance { get; set; }
        public DbSet<ProjectLocation> ProjectLocations { get; set; }
        public DbSet<TerritoryType> TerritoryTypes { get; set; }
        public DbSet<AreaOfEconomicActivity> AreasOfEconomicActivity { get; set; }
        public DbSet<AreaOfProjectIntervention> AreasOfProjectIntervention { get; set; }
        public DbSet<ProjectObjective> ProjectObjectives { get; set; }
        public DbSet<ESFSecondaryTheme> ESFSecondaryThemes { get; set; }
        public DbSet<ImplementedUnderTerritorialDeliveryMechanisms> ImplementedUnderTerritorialDeliveryMechanisms { get; set; }
    }
}
