using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace G3SpiritsReports.Models.ViewModels
{
    public class YearlyBrandReportViewModel
    {
        public List<YearlyBrandReport> YearlyBrandReports { get; set; }
        public IEnumerable<SelectListItem> Brands { get; set; }
        public IEnumerable<SelectListItem> Years { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        public int BrandId { get; set; }
        public int Year { get; set; }
        public int CountryId { get; set; }
    }
}
