namespace EuroFunds.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AreasOfEconomicActivity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        ProjectSummary = c.String(),
                        ContractNumber = c.String(maxLength: 25),
                        TotalProjectValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalEligibleValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountOfEUCofinancing = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EUCofinancingRate = c.Single(nullable: false),
                        ProjectStartDate = c.DateTime(nullable: false),
                        ProjectEndDate = c.DateTime(nullable: false),
                        UnderCompetetive = c.Boolean(nullable: false),
                        AreaOfEconomicActivity_Id = c.Int(),
                        AreaOfProjectIntervention_Id = c.Int(),
                        Beneficiary_Id = c.Int(),
                        ESFSecondaryTheme_Id = c.Int(),
                        FormOfFinance_Id = c.Int(),
                        Fund_Id = c.Int(),
                        ImplementedUnderTerritorialDeliveryMechanisms_Id = c.Int(),
                        Measure_Id = c.Int(),
                        Submeasure_Id = c.Int(),
                        Programme_Id = c.Int(),
                        ProjectLocation_Id = c.Int(),
                        ProjectObjective_Id = c.Int(),
                        TerritoryType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AreasOfEconomicActivity", t => t.AreaOfEconomicActivity_Id)
                .ForeignKey("dbo.AreasOfProjectIntervention", t => t.AreaOfProjectIntervention_Id)
                .ForeignKey("dbo.Beneficiaries", t => t.Beneficiary_Id)
                .ForeignKey("dbo.ESFSecondaryThemes", t => t.ESFSecondaryTheme_Id)
                .ForeignKey("dbo.FormsOfFinance", t => t.FormOfFinance_Id)
                .ForeignKey("dbo.Funds", t => t.Fund_Id)
                .ForeignKey("dbo.ImplementedUnderTerritorialDeliveryMechanisms", t => t.ImplementedUnderTerritorialDeliveryMechanisms_Id)
                .ForeignKey("dbo.Measures", t => t.Measure_Id)
                .ForeignKey("dbo.Submeasures", t => t.Submeasure_Id)
                .ForeignKey("dbo.Programmes", t => t.Programme_Id)
                .ForeignKey("dbo.ProjectLocations", t => t.ProjectLocation_Id)
                .ForeignKey("dbo.ProjectObjectives", t => t.ProjectObjective_Id)
                .ForeignKey("dbo.TerritoryTypes", t => t.TerritoryType_Id)
                .Index(t => t.AreaOfEconomicActivity_Id)
                .Index(t => t.AreaOfProjectIntervention_Id)
                .Index(t => t.Beneficiary_Id)
                .Index(t => t.ESFSecondaryTheme_Id)
                .Index(t => t.FormOfFinance_Id)
                .Index(t => t.Fund_Id)
                .Index(t => t.ImplementedUnderTerritorialDeliveryMechanisms_Id)
                .Index(t => t.Measure_Id)
                .Index(t => t.Submeasure_Id)
                .Index(t => t.Programme_Id)
                .Index(t => t.ProjectLocation_Id)
                .Index(t => t.ProjectObjective_Id)
                .Index(t => t.TerritoryType_Id);
            
            CreateTable(
                "dbo.AreasOfProjectIntervention",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Beneficiaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ESFSecondaryThemes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FormsOfFinance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Funds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImplementedUnderTerritorialDeliveryMechanisms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Measures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(),
                        Name = c.String(),
                        Priority_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Priorities", t => t.Priority_Id)
                .Index(t => t.Priority_Id);
            
            CreateTable(
                "dbo.Priorities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Submeasures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(),
                        Name = c.String(),
                        Measure_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Measures", t => t.Measure_Id)
                .Index(t => t.Measure_Id);
            
            CreateTable(
                "dbo.Programmes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectObjectives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TerritoryTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Url = c.String(),
                        Created = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "TerritoryType_Id", "dbo.TerritoryTypes");
            DropForeignKey("dbo.Projects", "ProjectObjective_Id", "dbo.ProjectObjectives");
            DropForeignKey("dbo.Projects", "ProjectLocation_Id", "dbo.ProjectLocations");
            DropForeignKey("dbo.Projects", "Programme_Id", "dbo.Programmes");
            DropForeignKey("dbo.Projects", "Submeasure_Id", "dbo.Submeasures");
            DropForeignKey("dbo.Submeasures", "Measure_Id", "dbo.Measures");
            DropForeignKey("dbo.Projects", "Measure_Id", "dbo.Measures");
            DropForeignKey("dbo.Measures", "Priority_Id", "dbo.Priorities");
            DropForeignKey("dbo.Projects", "ImplementedUnderTerritorialDeliveryMechanisms_Id", "dbo.ImplementedUnderTerritorialDeliveryMechanisms");
            DropForeignKey("dbo.Projects", "Fund_Id", "dbo.Funds");
            DropForeignKey("dbo.Projects", "FormOfFinance_Id", "dbo.FormsOfFinance");
            DropForeignKey("dbo.Projects", "ESFSecondaryTheme_Id", "dbo.ESFSecondaryThemes");
            DropForeignKey("dbo.Projects", "Beneficiary_Id", "dbo.Beneficiaries");
            DropForeignKey("dbo.Projects", "AreaOfProjectIntervention_Id", "dbo.AreasOfProjectIntervention");
            DropForeignKey("dbo.Projects", "AreaOfEconomicActivity_Id", "dbo.AreasOfEconomicActivity");
            DropIndex("dbo.Submeasures", new[] { "Measure_Id" });
            DropIndex("dbo.Measures", new[] { "Priority_Id" });
            DropIndex("dbo.Projects", new[] { "TerritoryType_Id" });
            DropIndex("dbo.Projects", new[] { "ProjectObjective_Id" });
            DropIndex("dbo.Projects", new[] { "ProjectLocation_Id" });
            DropIndex("dbo.Projects", new[] { "Programme_Id" });
            DropIndex("dbo.Projects", new[] { "Submeasure_Id" });
            DropIndex("dbo.Projects", new[] { "Measure_Id" });
            DropIndex("dbo.Projects", new[] { "ImplementedUnderTerritorialDeliveryMechanisms_Id" });
            DropIndex("dbo.Projects", new[] { "Fund_Id" });
            DropIndex("dbo.Projects", new[] { "FormOfFinance_Id" });
            DropIndex("dbo.Projects", new[] { "ESFSecondaryTheme_Id" });
            DropIndex("dbo.Projects", new[] { "Beneficiary_Id" });
            DropIndex("dbo.Projects", new[] { "AreaOfProjectIntervention_Id" });
            DropIndex("dbo.Projects", new[] { "AreaOfEconomicActivity_Id" });
            DropTable("dbo.Resources");
            DropTable("dbo.TerritoryTypes");
            DropTable("dbo.ProjectObjectives");
            DropTable("dbo.ProjectLocations");
            DropTable("dbo.Programmes");
            DropTable("dbo.Submeasures");
            DropTable("dbo.Priorities");
            DropTable("dbo.Measures");
            DropTable("dbo.ImplementedUnderTerritorialDeliveryMechanisms");
            DropTable("dbo.Funds");
            DropTable("dbo.FormsOfFinance");
            DropTable("dbo.ESFSecondaryThemes");
            DropTable("dbo.Beneficiaries");
            DropTable("dbo.AreasOfProjectIntervention");
            DropTable("dbo.Projects");
            DropTable("dbo.AreasOfEconomicActivity");
        }
    }
}
