using G3SpiritsReports.BusinessLogic.YearlyBrandReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G3SpiritsReports.UI.Controllers
{
    public class YearlyBrandReportController : Controller
    {
        private readonly YearlyBrandReportManager _yearlyBrandReportManager = new YearlyBrandReportManager();
        //
        // GET: /YearlyBrandReport/

        public ActionResult Index()
        {
            var countryId = Convert.ToInt32(Request.QueryString["countryId"]);
            if (countryId == 0)
            {
                countryId = 1;
            }
            var brandId = Convert.ToInt32(Request.QueryString["brandId"]);
            if (brandId == 0)
            {
                brandId = 1;
            }
            var year = Convert.ToInt32(Request.QueryString["year"]);
            if (year == 0)
            {
                year = DateTime.Now.Year;
            }
            var yearlyBrandReportViewModel = _yearlyBrandReportManager.GetYearlyBrandReportViewModel(countryId, brandId, year);
            return View(yearlyBrandReportViewModel);
        }

        [HttpGet]
        public string CreateOrEdit(int countryId, int brandId, int year, int month, int plannedPieces, int soldPieces)
        {
            try
            {
                _yearlyBrandReportManager.CreateOrEdit(countryId, brandId, year, month, plannedPieces, soldPieces);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
