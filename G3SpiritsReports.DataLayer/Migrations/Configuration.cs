using G3SpiritsReports.DataLayer.Context;
using System.Data.Entity.Migrations;

namespace G3SpiritsReports.DataLayer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataContext context)
        {

        }

    }
}
