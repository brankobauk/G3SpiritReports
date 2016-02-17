using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.Models.Models
{
    public class MonthlyBrandReportTable
    {
        public string Name { get; set; }
        public string MonthlyPlan { get; set; }
        public string MonthlyPlanToDate { get; set; }
        public string SoldPieces { get; set; }
        public string SoldPercentage { get; set; }
        public byte[] Image { get; set; }
        public bool OnPlan { get; set; }
    }
}
