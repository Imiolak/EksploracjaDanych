using EuroFunds.Database.Models;
using EuroFunds.DataLoader.ResourceLoader.PropertyUtils;
using System.Collections.Generic;
using System.Linq;

namespace EuroFunds.DataLoader.ResourceLoader
{
    public class ProjectFactory
    {
        public static Project CreateFromStringArray(string[] row)
        {
            return new Project
            {
                ProjectName = row[PropertyIndexes.ProjectName],
                ProjectSummary = row[PropertyIndexes.ProjectSummary],
                ContractNumber = row[PropertyIndexes.ContractNumber],
                Beneficiary = PropertyParser.ParseBeneficiary(row[PropertyIndexes.Beneficiary]),
                Fund = PropertyParser.ParseFund(row[PropertyIndexes.Fund]),
                Programme = PropertyParser.ParseProgramme(row[PropertyIndexes.Programme]),
                Measure = PropertyParser.ParseMeasure(row[PropertyIndexes.Measure]),
                Submeasure = PropertyParser.ParseSubmeasure(row[PropertyIndexes.Submeasure]),
                TotalProjectValue = PropertyParser.ParseDecimal(row[PropertyIndexes.TotalProjectValue]),
                TotalEligibleValue = PropertyParser.ParseDecimal(row[PropertyIndexes.TotalEligibleValue]),
                AmountOfEUCofinancing = PropertyParser.ParseDecimal(row[PropertyIndexes.AmountOfEUCofinancing]),
                EUCofinancingRate = PropertyParser.ParseFloat(row[PropertyIndexes.EUCofinancingRate])/100,
                FormOfFinance = PropertyParser.ParseFormOfFinance(row[PropertyIndexes.FormOfFinance]),
                //ProjectLocation = 
                TerritoryType = PropertyParser.ParseTerritoryType(row[PropertyIndexes.TerritoryType]),
                ProjectStartDate = PropertyParser.ParseDateTime(row[PropertyIndexes.ProjectStartDate]),
                ProjectEndDate = PropertyParser.ParseDateTime(row[PropertyIndexes.ProjectEndDate]),
                UnderCompetetive = PropertyParser.ParseUnderCompetitive(row[PropertyIndexes.UnderCompetetive]),
                AreaOfEconomicActivity =
                    PropertyParser.ParseAreaOfEconomicActivity(row[PropertyIndexes.AreaOfEconomicActivity]),
                AreaOfProjectIntervention =
                    PropertyParser.ParseAreaOfProjectIntervention(row[PropertyIndexes.AreaOfProjectIntervention]),
                ProjectObjective = PropertyParser.ParseProjectObjective(row[PropertyIndexes.ProjectObjective]),
                ESFSecondaryTheme = PropertyParser.ParseESFSecondaryTheme(row[PropertyIndexes.ESFSecondaryTheme]),
                ImplementedUnderTerritorialDeliveryMechanisms =
                    PropertyParser.ParseImplementedUnderTerritorialDeliveryMechanisms(
                        row[PropertyIndexes.ImplementedUnderTerritorialDeliveryMechanisms])
            };
        }

        public static IEnumerable<Project> CreateFromManyStringArrays(IEnumerable<string[]> rows)
        {
            return rows.Select(CreateFromStringArray);
        }
    }
}