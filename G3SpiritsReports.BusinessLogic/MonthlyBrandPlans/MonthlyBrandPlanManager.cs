using G3SpiritsReports.BusinessLogic.Brands;
using G3SpiritsReports.BusinessLogic.Countries;
using G3SpiritsReports.Helpers;
using G3SpiritsReports.Models.Models;
using G3SpiritsReports.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.BusinessLogic.MonthlyBrandPlans
{
    public class MonthlyBrandPlanManager
    {
        private readonly MonthlyBrandPlanHandler _monthlyBrandPlanHandler = new MonthlyBrandPlanHandler();
        private readonly BrandManager _brandManager = new BrandManager();
        private readonly CountryManager _countryManager = new CountryManager();
        private readonly DropDownHelper _dropDownHelper = new DropDownHelper();
        public MonthlyBrandPlanViewModel GetMonthlyBrandPlan(int countryId, int month, int year)
        {
            var brands = _brandManager.GetAllBrands();
            var monthlyBrandReports = new List<MonthlyBrandPlan>();
            foreach (var brand in brands)
            {
                var monthlyBrandReport = _monthlyBrandPlanHandler.GetMonthlyBrandPlan(brand.BrandId, countryId, month, year);
                if (monthlyBrandReport == null) monthlyBrandReport = new MonthlyBrandPlan();
                monthlyBrandReport.Brand = brand;
                monthlyBrandReports.Add(monthlyBrandReport);
            }
            var monthlyBrandPlanViewModel = new MonthlyBrandPlanViewModel()
            {
                MonthlyBrandPlans = monthlyBrandReports,
                Month = month,
                Year = year,
                CountryId = countryId,
                Months = _dropDownHelper.GetMonthsListForDropDown(),
                Years = _dropDownHelper.GetYearsListForDropDown(),
                Countries = _dropDownHelper.GetCountriesListForDropDown(_countryManager.GetAllCountries())
            };
            return monthlyBrandPlanViewModel;
        }

        public void CreateOrEdit(int countryId, int month, int year, int brandId, int plannedPieces)
        {
            var monthlyBrandPlan = new MonthlyBrandPlan();
            monthlyBrandPlan.BrandId = brandId;
            monthlyBrandPlan.CountryId = countryId;
            monthlyBrandPlan.Month = month;
            monthlyBrandPlan.Year = year;
            monthlyBrandPlan.PlannedPieces = plannedPieces;
            _monthlyBrandPlanHandler.CreateOrEdit(monthlyBrandPlan);
        }
    }
}
