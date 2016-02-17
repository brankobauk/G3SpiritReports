using G3SpiritsReports.BusinessLogic.Countries;
using G3SpiritsReports.BusinessLogic.MonthlyBrandReports;
using G3SpiritsReports.BusinessLogic.MonthlyReports;
using G3SpiritsReports.BusinessLogic.YearlyBrandReports;
using G3SpiritsReports.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G3SpiritsReports.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly CountryManager _countryManager = new CountryManager();
        private readonly MonthlyBrandReportManager _monthlyBrandReportManager = new MonthlyBrandReportManager();
        private readonly MonthlyReportManager _monthlyReportManager = new MonthlyReportManager();
        private readonly YearlyBrandReportManager _yearlyBrandReportManager = new YearlyBrandReportManager();
        public ActionResult Index()
        {
            var countries = _countryManager.GetAllCountries();

            return View(countries);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CountryReport()
        {
            var countryId = Convert.ToInt32(Request.QueryString["countryId"]);
            if (countryId == 0)
            {
                countryId = 1;
            }

            var dateQs = Request.QueryString["date"];
            
            var date = DateTime.Today;
            if (dateQs != "")
            {
                date = Convert.ToDateTime(Request.QueryString["date"]);
            }
            else 
            {
                var latestMonthlyBrandReport = _monthlyBrandReportManager.GetLatestMonthlyBrandReport();
                if (latestMonthlyBrandReport != null)
                    date = latestMonthlyBrandReport.Date;
            }
            var monthlyBrandReportTable = _monthlyBrandReportManager.GetMonthlyBrandReportTable(date, countryId);
            var monthlyReportTable = _monthlyReportManager.GetMonthlyReportTable(date, countryId);
            var yearlyBrandReportTable = _yearlyBrandReportManager.GetYearlyBrandReportTables(date, countryId);
            var reportTableViewModel = new ReportTableViewModel()
            {
                MonthlyBrandReportTables = monthlyBrandReportTable,
                MonthlyReportTable = monthlyReportTable,
                YearlyBrandReportTables = yearlyBrandReportTable,
                Date = date.ToShortDateString()
            };
            return View("_Report", reportTableViewModel);
        }

        public ActionResult Report()
        {
            ViewBag.Message = "Your contact page.";

            return View("_Report");
        }
    }
}
