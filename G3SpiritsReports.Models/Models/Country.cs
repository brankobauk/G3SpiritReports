using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace G3SpiritsReports.Models.Models
{
    public class Country
    {
        public Country()
        {
            MonthlyBrandReports = new List<MonthlyBrandReport>();
            YearlyBrandReports = new List<YearlyBrandReport>();
        }
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }

        private ICollection<MonthlyBrandReport> MonthlyBrandReports { get; set; }
        private ICollection<YearlyBrandReport> YearlyBrandReports { get; set; }
    }
}
