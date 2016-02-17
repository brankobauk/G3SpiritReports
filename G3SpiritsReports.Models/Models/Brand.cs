using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace G3SpiritsReports.Models.Models
{
    public class Brand
    {

        public Brand()
        {
            MonthlyBrandReports = new List<MonthlyBrandReport>();
            YearlyBrandReports = new List<YearlyBrandReport>();
        }
        [Key]
        public int BrandId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int BottleHeight { get; set; }
        public int SortOrder { get; set; }

        private ICollection<MonthlyBrandReport> MonthlyBrandReports { get; set; }
        private ICollection<YearlyBrandReport> YearlyBrandReports { get; set; }
    }
}
