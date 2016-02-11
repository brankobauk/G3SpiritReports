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
        public MonthlyBrandReportViewModel GetMonthlyBrandReport(int countryId, DateTime date)
        {
            var brands = _brandManager.GetAllBrands();
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
    }
}
