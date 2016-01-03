using System.Data.Entity;
using MvcApplication2.DataAccessLayer;

namespace DataAccessLayer
{
    public class DatabaseSettings
    {
        public static void SetDatabase()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SalesErpdal>());
        }
    }
}