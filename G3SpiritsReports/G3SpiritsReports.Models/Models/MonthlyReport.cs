using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.Models.Models
{
    public class MonthlyReport
    {
        public int MonthlyReportId { get; set; }
        public int CountryId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal PlannedValue { get; set; }
        public decimal SoldValue { get; set; }
    }
}
