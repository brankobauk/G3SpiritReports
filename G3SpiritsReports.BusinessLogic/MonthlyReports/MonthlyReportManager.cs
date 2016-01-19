using G3SpiritsReports.BusinessLogic.Countries;
using G3SpiritsReports.Helpers;
using G3SpiritsReports.Models.Models;
using G3SpiritsReports.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.BusinessLogic.MonthlyReports
{
    public class MonthlyReportManager
    {
        private readonly MonthlyReportHandler _monthlyReportHandler = new MonthlyReportHandler();
        private readonly DropDownHelper _dropDownHelper = new DropDownHelper();
        private readonly CountryManager _countryManager = new CountryManager();
        public MonthlyReportViewModel GetMonthlyReport(int countryId, int month, int year)
        {
            var monthlyReport = _monthlyReportHandler.GetMonthlyReport(countryId, month, year);
            if (monthlyReport == null) monthlyReport = new MonthlyReport();
            monthlyReport.CountryId = countryId;
            monthlyReport.Month = month;
            monthlyReport.Year = year;
            var monthlyBrandReportViewModel = new MonthlyReportViewModel()
            {
                MonthlyReport = monthlyReport,
                Month = month,
                Year = year,
                CountryId = countryId,
                Months = _dropDownHelper.GetMonthsListForDropDown(),
                Years = _dropDownHelper.GetYearsListForDropDown(),
                Countries = _dropDownHelper.GetCountriesListForDropDown(_countryManager.GetAllCountries())
            };
            return monthlyBrandReportViewModel;
        }

        public void CreateOrEdit(int countryId, int month, int year, decimal plannedValue, decimal soldValue)
        {
            var monthlyReport = new MonthlyReport();
            monthlyReport.CountryId = countryId;
            monthlyReport.Month = month;
            monthlyReport.Year = year;
            monthlyReport.PlannedValue = plannedValue;
            monthlyReport.SoldValue = soldValue;
            _monthlyReportHandler.CreateOrEdit(monthlyReport);
        }
    }
}
