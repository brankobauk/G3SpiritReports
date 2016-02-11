using G3SpiritsReports.BusinessLogic.MonthlyBrandPlans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G3SpiritsReports.UI.Controllers
{
    public class MonthlyBrandPlanController : Controller
    {
        //
        // GET: /MonthlyBrandPlan/
        private readonly MonthlyBrandPlanManager _monthlyBrandPlanManager = new MonthlyBrandPlanManager();
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
            var monthlyBrandReportHandler = _monthlyBrandPlanManager.GetMonthlyBrandPlan(countryId, month, year);
            return View(monthlyBrandReportHandler);
        }

        [HttpGet]
        public string CreateOrEdit(int countryId, int month, int year, int brandId, int plannedPieces)
        {
            try
            {
                _monthlyBrandPlanManager.CreateOrEdit(countryId, month, year, brandId, plannedPieces);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
