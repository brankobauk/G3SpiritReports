using G3SpiritsReports.BusinessLogic.Brands;
using G3SpiritsReports.BusinessLogic.Countries;
using G3SpiritsReports.BusinessLogic.MonthlyBrandPlans;
using G3SpiritsReports.DataLayer.Repositories;
using G3SpiritsReports.Helpers;
using G3SpiritsReports.Models.Models;
using G3SpiritsReports.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.BusinessLogic.MonthlyBrandReports
{
    public class MonthlyBrandReportManager
    {
        private readonly MonthlyBrandReportHandler _monthlyBrandReportHandler = new MonthlyBrandReportHandler();
        private readonly MonthlyBrandPlanHandler _monthlyBrandPlanHandler = new MonthlyBrandPlanHandler();
        private readonly BrandHandler _brandHandler = new BrandHandler();
        private readonly CountryManager _countryManager = new CountryManager();
        private readonly DropDownHelper _dropDownHelper = new DropDownHelper();
        public MonthlyBrandReportViewModel GetMonthlyBrandReport(int countryId, DateTime date)
        {
            var brands = _brandHandler.GetAllBrands();
            var monthlyBrandReports = new List<MonthlyBrandReport>();
            foreach (var brand in brands)
            {
                var monthlyBrandReport = _monthlyBrandReportHandler.GetMonthlyBrandReport(brand.BrandId, countryId, date);
                if (monthlyBrandReport == null) monthlyBrandReport = new MonthlyBrandReport();
                monthlyBrandReport.Brand = brand;
                monthlyBrandReports.Add(monthlyBrandReport);
            }
            var monthlyBrandReportViewModel = new MonthlyBrandReportViewModel()
            {
                MonthlyBrandReports = monthlyBrandReports,
                Date = date,
                CountryId = countryId,
                Countries = _dropDownHelper.GetCountriesListForDropDown(_countryManager.GetAllCountries())
            };
            return monthlyBrandReportViewModel;
        }

        public void CreateOrEdit(int countryId, DateTime date, int brandId, int soldPieces)
        {
            var monthlyBrandReport = new MonthlyBrandReport();
            monthlyBrandReport.BrandId = brandId;
            monthlyBrandReport.CountryId = countryId;
            monthlyBrandReport.Date = date;
            monthlyBrandReport.SoldPieces = soldPieces;
            _monthlyBrandReportHandler.CreateOrEdit(monthlyBrandReport);
        }

        public List<MonthlyBrandReportTable> GetMonthlyBrandReportTable(DateTime date, int countryId)
        {
            var daysInMonth = System.DateTime.DaysInMonth(date.Year, date.Month);
            var monthlyBrandReportTable = new List<MonthlyBrandReportTable>();
            var monthlyBrandReportItems = _monthlyBrandReportHandler.GetMonthlyBrandReportItems(date, countryId);
            var monthlyBrandPlanItems = _monthlyBrandPlanHandler.GetMonthlyBrandPlanItems(date, countryId);
            var brands = _brandHandler.GetAllBrands();
            foreach(var item in brands)
            {
                var monthlyReport = monthlyBrandReportItems.FirstOrDefault(p => p.BrandId == item.BrandId && p.Date == date);
                if(monthlyReport != null)
                { 
                    var monthlyPlan = monthlyBrandPlanItems.FirstOrDefault(p=>p.BrandId==item.BrandId);
                    var monthlyPlanToDate = 0;
                    var plannedPieces = 0;
                    if (monthlyPlan != null) 
                    {
                        plannedPieces = monthlyPlan.PlannedPieces;
                        monthlyPlanToDate = plannedPieces / daysInMonth * date.Day;
                    }
                    var onPlan = (monthlyPlanToDate > monthlyReport.SoldPieces) ? false : true;
                    var soldPercentage = Math.Round(Convert.ToDecimal(monthlyReport.SoldPieces) / Convert.ToDecimal(monthlyPlanToDate) * 100, 2);
                    var monthlyBrandReportTableItem = new MonthlyBrandReportTable() 
                    { 
                        Name = item.Name,
                        Image = item.Image,
                        MonthlyPlan = plannedPieces.ToString(),
                        MonthlyPlanToDate = monthlyPlanToDate.ToString(),
                        SoldPieces = monthlyReport.SoldPieces.ToString(),
                        SoldPercentage = soldPercentage.ToString(),
                        OnPlan = onPlan
                    };
                    monthlyBrandReportTable.Add(monthlyBrandReportTableItem);
                }
            }
            
            return monthlyBrandReportTable;
        }

        public MonthlyBrandReport GetLatestMonthlyBrandReport()
        {
            return _monthlyBrandPlanHandler.GetLatestMonthlyBrandReport();
        }
    }
}
