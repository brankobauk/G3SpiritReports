using G3SpiritsReports.BusinessLogic.MonthlyBrandReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G3SpiritsReports.UI.Controllers
{
    public class MonthlyBrandReportController : Controller
    {
        //
        // GET: /MonthlyBrandReport/
        private readonly MonthlyBrandReportManager _monthlyBrandReportManager = new MonthlyBrandReportManager();
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
            var monthlyBrandReportHandler = _monthlyBrandReportManager.GetMonthlyBrandReport(countryId, month, year);
            return View(monthlyBrandReportHandler);
        }

        

        //
        // POST: /MonthlyBrandReport/Create

        [HttpGet]
        public string CreateOrEdit(int countryId, int month, int year, int brandId, int plannedPieces, int soldPieces)
        {
            try
            {
                _monthlyBrandReportManager.CreateOrEdit(countryId, month, year, brandId, plannedPieces, soldPieces);
                return "OK";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
