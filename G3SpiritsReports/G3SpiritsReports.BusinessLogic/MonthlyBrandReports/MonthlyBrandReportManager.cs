using G3SpiritsReports.BusinessLogic.Brands;
using G3SpiritsReports.BusinessLogic.Countries;
using G3SpiritsReports.DataLayer.Repositories;
using G3SpiritsReports.Helpers;
using G3SpiritsReports.Models.Models;
using G3SpiritsReports.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.BusinessLogic.MonthlyBrandReports
{
    public class MonthlyBrandReportManager
    {
        private readonly MonthlyBrandReportHandler _monthlyBrandReportHandler = new MonthlyBrandReportHandler();
        private readonly BrandManager _brandManager = new BrandManager();
        private readonly CountryManager _countryManager = new CountryManager();
        private readonly DropDownHelper _dropDownHelper = new DropDownHelper();
        public MonthlyBrandReportViewModel GetMonthlyBrandReport(int countryId, int month, int year)
        {
            var brands = _brandManager.GetAllBrands();
            var monthlyBrandReports = new List<MonthlyBrandReport>();
            foreach (var brand in brands)
            {
                var monthlyBrandReport = _monthlyBrandReportHandler.GetMonthlyBrandReport(brand.BrandId, countryId, month, year);
                if (monthlyBrandReport == null) monthlyBrandReport = new MonthlyBrandReport();
                monthlyBrandReport.Brand = brand;
                monthlyBrandReports.Add(monthlyBrandReport);
            }
            var monthlyBrandReportViewModel = new MonthlyBrandReportViewModel()
            {
                MonthlyBrandReports = monthlyBrandReports,
                Month = month,
                Year = year,
                CountryId = countryId,
                Months = _dropDownHelper.GetMonthsListForDropDown(),
                Years = _dropDownHelper.GetYearsListForDropDown(),
                Countries = _dropDownHelper.GetCountriesListForDropDown(_countryManager.GetAllCountries())
            };
            return monthlyBrandReportViewModel;
        }

        public void CreateOrEdit(int countryId, int month, int year, int brandId, int plannedPieces, int soldPieces)
        {
            var monthlyBrandReport = new MonthlyBrandReport();
            monthlyBrandReport.BrandId = brandId;
            monthlyBrandReport.CountryId = countryId;
            monthlyBrandReport.Month = month;
            monthlyBrandReport.Year = year;
            monthlyBrandReport.PlannedPieces = plannedPieces;
            monthlyBrandReport.SoldPieces = soldPieces;
            _monthlyBrandReportHandler.CreateOrEdit(monthlyBrandReport);
        }
    }
}
