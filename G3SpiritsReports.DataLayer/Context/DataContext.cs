using G3SpiritsReports.DataLayer.Migrations;
using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.DataLayer.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<MonthlyBrandReport> MonthlyBrandReports { get; set; }
        public DbSet<MonthlyReport> MonthlyReports { get; set; }
        public DbSet<YearlyBrandReport> YearlyBrandReports { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DataContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());

        }
    }
}
