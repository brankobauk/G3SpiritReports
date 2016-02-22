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

        public MonthlyReportTable GetMonthlyReportTable(DateTime date, int countryId)
        {
            var monthlyReport = _monthlyReportHandler.GetMonthlyReport(countryId, date.Month, date.Year);
            if(monthlyReport == null) return null;
            var daysInMonth = System.DateTime.DaysInMonth(date.Year, date.Month);
            var monthlyPlanToDate = monthlyReport.PlannedValue / daysInMonth * date.Day;
            var plannedValue = monthlyReport.PlannedValue;
            if (plannedValue == null) plannedValue = 0;
            var soldValue = monthlyReport.SoldValue;
            if (soldValue == null) soldValue = 0;
            return new MonthlyReportTable()
            {
                MonthlyPlanToDate = Math.Round(monthlyPlanToDate, 2).ToString(),
                MonthlyPlan = Math.Round(plannedValue, 2).ToString(),
                SoldValue = Math.Round(soldValue, 2).ToString()
            };
        }
    }
}
