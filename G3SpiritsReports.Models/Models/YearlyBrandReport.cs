using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.Models.Models
{
    public class YearlyBrandReport
    {
        [Key]
        public int YearlyReportId { get; set; }
        public int BrandId { get; set; }
        public int CountryId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int PlannedPieces { get; set; }
        public int SoldPieces { get; set; }

        public virtual Country Country { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
