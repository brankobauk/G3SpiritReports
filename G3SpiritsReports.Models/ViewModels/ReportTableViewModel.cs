using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.Models.ViewModels
{
    public class ReportTableViewModel
    {
        public string Date { get; set; }
        public List<MonthlyBrandReportTable> MonthlyBrandReportTables { get; set; }
        public MonthlyReportTable MonthlyReportTable { get; set; }
        public List<YearlyBrandReportTable> YearlyBrandReportTables { get; set; }
    }
}
