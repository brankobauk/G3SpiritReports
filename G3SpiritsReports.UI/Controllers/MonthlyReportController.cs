using G3SpiritsReports.BusinessLogic.MonthlyReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G3SpiritsReports.UI.Controllers
{
    [Authorize]
    public class MonthlyReportController : Controller
    {
        //
        // GET: /MonthlyReport/
        private readonly MonthlyReportManager _monthlyReportManager = new MonthlyReportManager();
        public ActionResult Index()
        {
            var countryId = Convert.ToInt32(Request.QueryString["countryId"]);
            if (countryId == 0)
            {
                countryId = 1;
            }
            var month = Convert.ToInt32(Request.QueryString["month"]);
            if (month == 0)
            {
                month = DateTime.Now.Month;
            }
            var year = Convert.ToInt32(Request.QueryString["year"]);
            if (year == 0)
            {
                year = DateTime.Now.Year;
            }
            var monthlyReportViewModel = _monthlyReportManager.GetMonthlyReport(countryId, month, year);
            return View(monthlyReportViewModel);
        }

        [HttpGet]
        public string CreateOrEdit(int countryId, int month, int year, decimal plannedValue, decimal soldValue)
        {
            try
            {
                _monthlyReportManager.CreateOrEdit(countryId, month, year, plannedValue, soldValue);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
