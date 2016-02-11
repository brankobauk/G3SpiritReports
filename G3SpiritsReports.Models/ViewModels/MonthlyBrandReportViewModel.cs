using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace G3SpiritsReports.Models.ViewModels
{
    public class MonthlyBrandReportViewModel
    {
        public List<MonthlyBrandReport> MonthlyBrandReports { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        public int CountryId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Date { get; set; }
    }
}
