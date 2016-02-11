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
            var date = Convert.ToDateTime(Request.QueryString["date"]);
            if (date == DateTime.MinValue)
            {
                date = DateTime.Today;
            }
            
            var monthlyBrandReportHandler = _monthlyBrandReportManager.GetMonthlyBrandReport(countryId, date);
            return View(monthlyBrandReportHandler);
        }

        

        //
        // POST: /MonthlyBrandReport/Create

        [HttpGet]
        public string CreateOrEdit(int countryId, DateTime date, int brandId , int soldPieces)
        {
            try
            {
                _monthlyBrandReportManager.CreateOrEdit(countryId, date, brandId, soldPieces);
                return "OK";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
