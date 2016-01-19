using G3SpiritsReports.DataLayer.Context;
using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.DataLayer.Repositories
{
    public class MonthlyReportRepository
    {
        private readonly DataContext _db = new DataContext();
        public MonthlyReport GetMonthlyReport(int countryId, int month, int year)
        {
            return _db.MonthlyReports.FirstOrDefault(p => p.CountryId == countryId && p.Month == month && p.Year == year);
        }

        public void CreateOrEdit(MonthlyReport monthlyReport)
        {
            var monthlyReportToEdit = GetMonthlyReport(monthlyReport.CountryId, monthlyReport.Month, monthlyReport.Year);
            if (monthlyReportToEdit == null)
            {
                CreateMonthlyReportItem(monthlyReport);
            }
            else
            {
                monthlyReportToEdit.PlannedValue = monthlyReport.PlannedValue;
                monthlyReportToEdit.SoldValue = monthlyReport.SoldValue;
                _db.SaveChanges();
            }
        }

        private void CreateMonthlyReportItem(MonthlyReport monthlyReport)
        {
            _db.MonthlyReports.Add(monthlyReport);
            _db.SaveChanges();
        }
    }
}
