using EuroFunds.Database.DAO;
using EuroFunds.Database.Models;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EuroFunds.Database.Repositories
{
    public static class ResourceRepository
    {
        public static Resource GetMostRecentResource()
        {
            using (var context = new EuroFundsContext())
            {
                return context.Resources.OrderByDescending(r => r.Created).FirstOrDefault();
            }
        }

        public static void AddOrUpdate(Resource resource)
        {
            using (var context = new EuroFundsContext())
            {
                context.Resources.AddOrUpdate(resource);

                context.SaveChanges();
            }
        }
    }
}
