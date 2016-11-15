using EuroFunds.Database.DAO;
using EuroFunds.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EuroFunds.Database.Repositories
{
    public static class ProjectRepository
    {
        public static IEnumerable<Project> FilterAlreadyExistingProjects(IEnumerable<Project> projectsInResource)
        {
            using (var context = new EuroFundsContext())
            {
                var existingProjects = context.Projects.Select(p => p.ContractNumber);

                return projectsInResource.Where(p => !existingProjects.Contains(p.ContractNumber)).ToList();
            }
        }

        public static void AddOrUpdate(Project project)
        {
            using (var context = new EuroFundsContext())
            {
                AddOrUpdateProject(project, context);

                context.SaveChanges();
            }
        }

        public static void AddOrUpdateMany(IEnumerable<Project> projects)
        {
            using (var context = new EuroFundsContext())
            {
                var i = 1;

                foreach (var project in projects)
                {
                    AddOrUpdateProject(project, context);

                    if (i%100 == 0)
                    {
                        Console.WriteLine($"Added {i} so far. Saving progress..");
                    }

                    context.SaveChanges();
                    i++;
                }
            }
        }

        private static void AddOrUpdateProject(Project project, EuroFundsContext context)
        {
            ResolveDependencies(project, context);

            context.Projects.AddOrUpdate(project);
        }

        #region Helpers
        private static void ResolveDependencies(Project project, EuroFundsContext context)
        {
            Beneficiary beneficiary;
            if ((beneficiary = context.Beneficiaries.SingleOrDefault(b => b.Name == project.Beneficiary.Name)) != null)
            {
                project.Beneficiary = beneficiary;
            }

            Fund fund;
            if ((fund = context.Funds.SingleOrDefault(f => f.Name == project.Fund.Name)) != null)
            {
                project.Fund = fund;
            }

            Programme programme;
            if ((programme = context.Programmes.SingleOrDefault(p => p.Name == project.Programme.Name)) != null)
            {
                project.Programme = programme;
            }

            Priority priority;
            if ((priority = 
                    context.Priorities.ToList().SingleOrDefault(p => p == project.Priority)) != null)
            {
                project.Measure.Priority = priority;
            }

            Measure measure;
            if ((measure = context.Measures.ToList().SingleOrDefault(m => m == project.Measure)) != null)
            {
                project.Measure = measure;
            }
            else if (priority != null)
            {
                project.Measure.Priority = priority;
            }
            
            Submeasure submeasure;
            if ((submeasure = context.Submeasures.ToList().SingleOrDefault(s => s == project.Submeasure)) != null)
            {
                project.Submeasure = submeasure;
            }
            else if (project.Submeasure != Submeasure.NullSubmeasure && measure != null)
            {
                project.Submeasure.Measure = measure;
            }

            FormOfFinance formOfFinance;
            if ((formOfFinance =
                    context.FormsOfFinance.SingleOrDefault(fof => fof.OrderNo == project.FormOfFinance.OrderNo)) != null)
            {
                project.FormOfFinance = formOfFinance;
            }

            var allLocations = context.ProjectLocations.ToList();
            var newLocations = new List<ProjectLocation>();
            foreach (var projectLocation in project.ProjectLocations)
            {
                ProjectLocation location;
                if ((location = allLocations.SingleOrDefault(l => l.Name == projectLocation.Name)) != null)
                {
                    newLocations.Add(location);
                }
                else
                {
                    newLocations.Add(projectLocation);
                }
            }
            project.ProjectLocations = newLocations;

            TerritoryType territoryType;
            if ((territoryType = 
                context.TerritoryTypes.SingleOrDefault(t => t.OrderNo == project.TerritoryType.OrderNo)) != null)
            {
                project.TerritoryType = territoryType;
            }

            AreaOfEconomicActivity areaOfActivity;
            if ((areaOfActivity =
                context.AreasOfEconomicActivity.SingleOrDefault(
                    aoea => aoea.OrderNo == project.AreaOfEconomicActivity.OrderNo)) != null)
            {
                project.AreaOfEconomicActivity = areaOfActivity;
            }

            AreaOfProjectIntervention areaOfIntervention;
            if ((areaOfIntervention =
                context.AreasOfProjectIntervention.SingleOrDefault(
                    aopi => aopi.OrderNo == project.AreaOfProjectIntervention.OrderNo)) != null)
            {
                project.AreaOfProjectIntervention = areaOfIntervention;
            }

            ProjectObjective projectObjective;
            if ((projectObjective =
                context.ProjectObjectives.SingleOrDefault(po => po.OrderNo == project.ProjectObjective.OrderNo)) != null)
            {
                project.ProjectObjective = projectObjective;
            }

            ESFSecondaryTheme esfTheme;
            if ((esfTheme =
                context.ESFSecondaryThemes.SingleOrDefault(t => t.Name == project.ESFSecondaryTheme.Name)) != null)
            {
                project.ESFSecondaryTheme = esfTheme;
            }

            ImplementedUnderTerritorialDeliveryMechanisms implementedUnder;
            if ((implementedUnder =
                context.ImplementedUnderTerritorialDeliveryMechanisms.SingleOrDefault(
                    iu => iu.Name == project.ImplementedUnderTerritorialDeliveryMechanisms.Name)) != null)
            {
                project.ImplementedUnderTerritorialDeliveryMechanisms = implementedUnder;
            }
        }
        #endregion
    }
}
