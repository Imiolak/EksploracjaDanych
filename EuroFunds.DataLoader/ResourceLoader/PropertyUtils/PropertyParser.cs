using EuroFunds.Database.Models;
using System;
using System.Linq;

namespace EuroFunds.DataLoader.ResourceLoader.PropertyUtils
{
    public static class PropertyParser
    {
        public static decimal ParseDecimal(string value)
        {
            return decimal.Round(decimal.Parse(value), 2);
        }

        public static float ParseFloat(string value)
        {
            return (float) Math.Round(ParseDecimal(value));
        }

        public static DateTime ParseDateTime(string value)
        {
            return DateTime.FromOADate(double.Parse(value));
        }

        public static Beneficiary ParseBeneficiary(string value)
        {
            return new Beneficiary
            {
                Name = value
            };
        }

        public static Fund ParseFund(string value)
        {
            return new Fund
            {
                Name = value
            };
        }

        public static Programme ParseProgramme(string value)
        {
            return new Programme
            {
                Name = value
            };
        }

        public static Priority ParsePriority(string value)
        {
            var orderNo = value.Split(' ').First();

            return new Priority
            {
                OrderNo = orderNo,
                Name = value.Substring(orderNo.Length +1)
            };
        }

        public static Measure ParseMeasure(string value)
        {
            var orderNo = value.Split(' ').First();

            return new Measure
            {
                OrderNo = orderNo,
                Name = value.Substring(orderNo.Length + 1)
            };
        }

        public static Submeasure ParseSubmeasure(string value)
        {
            if (value == "Brak poddziałania")
            {
                return Submeasure.NullSubmeasure;
            }

            var orderNo = value.Split(' ').First();

            return new Submeasure
            {
                OrderNo = orderNo,
                Name = value.Substring(orderNo.Length + 1)
            };
        }

        public static FormOfFinance ParseFormOfFinance(string value)
        {
            var orderNo = value.Split(' ').First();

            return new FormOfFinance
            {
                OrderNo = orderNo,
                Name = value.Substring(orderNo.Length + 1)
            };
        }

        //public static ProjectLocation ParseProjectLocation(string value)
        //{
            
        //}

        public static TerritoryType ParseTerritoryType(string value)
        {
            var orderNo = value.Split(' ').First();

            return new TerritoryType
            {
                OrderNo = orderNo,
                Name = value.Substring(orderNo.Length + 1)
            };
        }

        public static bool ParseUnderCompetitive(string value)
        {
            return value == "Konkursowy";
        }

        public static AreaOfEconomicActivity ParseAreaOfEconomicActivity(string value)
        {
            var orderNo = value.Split(' ').First();

            return new AreaOfEconomicActivity
            {
                OrderNo = orderNo,
                Name = value.Substring(orderNo.Length + 1)
            };
        }

        public static AreaOfProjectIntervention ParseAreaOfProjectIntervention(string value)
        {
            var orderNo = value.Split(' ').First();

            return new AreaOfProjectIntervention
            {
                OrderNo = orderNo,
                Name = value.Substring(orderNo.Length + 1)
            };
        }

        public static ProjectObjective ParseProjectObjective(string value)
        {
            var orderNo = value.Split(' ').First();
            if (orderNo.EndsWith("_POWR"))
                orderNo = orderNo.Substring(0, orderNo.Length - "_POWR".Length);

            return new ProjectObjective
            {
                OrderNo = orderNo,
                Name = value.Substring(orderNo.Length + 1)
            };
        }

        public static ESFSecondaryTheme ParseESFSecondaryTheme(string value)
        {
            if (value == "Projekt nie jest realizowany w ramach EFS")
            {
                return new ESFSecondaryTheme
                {
                    Name = "Brak"
                };
            }

            var orderNo = value.Split(' ').First();

            return new ESFSecondaryTheme
            {
                OrderNo = orderNo,
                Name = value.Substring(orderNo.Length + 1)
            };
        }

        public static ImplementedUnderTerritorialDeliveryMechanisms ParseImplementedUnderTerritorialDeliveryMechanisms(
            string value)
        {
            return new ImplementedUnderTerritorialDeliveryMechanisms
            {
                Name = value
            };
        }
    }
}