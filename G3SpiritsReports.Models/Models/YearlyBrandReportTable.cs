using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.Models.Models
{
    public class YearlyBrandReportTable
    {
        public string Name { get; set; }
        public string YearlyPiecesSum { get; set; }
        public string PlannedPiecesSum { get; set; }
        public string AchievedPiecesSum { get; set; }
        public List<YearlyBrandReport> YearlyBrandReport { get; set; }
    }
}
