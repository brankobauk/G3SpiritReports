using G3SpiritsReports.DataLayer.Context;
using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.DataLayer.Repositories
{
    public class MonthlyBrandReportRepository
    {
        private readonly DataContext _db = new DataContext();
        public void CreateMonthlyBrandReportItem(MonthlyBrandReport monthlyBrandReport)
        {
            _db.MonthlyBrandReports.Add(monthlyBrandReport);
            _db.SaveChanges();
        }

        public List<MonthlyBrandReport> GetMonthlyBrandReports(int month, int year)
        {
           return  _db.MonthlyBrandReports.Where(p=>p.Month == month && p.Year == year).ToList();
        }

        public MonthlyBrandReport GetMonthlyBrandReport(int brandId, int countryId, int month, int year)
        {
            return _db.MonthlyBrandReports.FirstOrDefault(p => p.BrandId == brandId && p.CountryId == countryId && p.Month == month && p.Year == year);
        }

        public void CreateOrEdit(MonthlyBrandReport monthlyBrandReport)
        {
            var monthlyBrandReportToEdit = GetMonthlyBrandReport(monthlyBrandReport.BrandId, monthlyBrandReport.CountryId, monthlyBrandReport.Month, monthlyBrandReport.Year);
            if (monthlyBrandReportToEdit == null)
            {
                CreateMonthlyBrandReportItem(monthlyBrandReport);
            }
            else
            {
                monthlyBrandReportToEdit.PlannedPieces = monthlyBrandReport.PlannedPieces;
                monthlyBrandReportToEdit.SoldPieces = monthlyBrandReport.SoldPieces;
                _db.SaveChanges();
            }
        }
    }
}
