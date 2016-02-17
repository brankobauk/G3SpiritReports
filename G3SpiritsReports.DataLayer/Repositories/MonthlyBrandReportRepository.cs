using G3SpiritsReports.DataLayer.Context;
using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public List<MonthlyBrandReport> GetMonthlyBrandReports(DateTime date)
        {
           return  _db.MonthlyBrandReports.Where(p=>p.Date == date).ToList();
        }

        public MonthlyBrandReport GetMonthlyBrandReport(int brandId, int countryId, DateTime date)
        {
            return _db.MonthlyBrandReports.FirstOrDefault(p => p.BrandId == brandId && p.CountryId == countryId && p.Date.Equals(date.Date));
        }

        public void CreateOrEdit(MonthlyBrandReport monthlyBrandReport)
        {
            var monthlyBrandReportToEdit = GetMonthlyBrandReport(monthlyBrandReport.BrandId, monthlyBrandReport.CountryId, monthlyBrandReport.Date);
            if (monthlyBrandReportToEdit == null)
            {
                CreateMonthlyBrandReportItem(monthlyBrandReport);
            }
            else
            {
                monthlyBrandReportToEdit.SoldPieces = monthlyBrandReport.SoldPieces;
                _db.SaveChanges();
            }
        }

        public List<MonthlyBrandReport> GetMonthlyBrandReportItems(DateTime date, int countryId)
        {
            return _db.MonthlyBrandReports.Where(p => p.CountryId == countryId && p.Date == date && p.BrandId == p.Brand.BrandId).Include(p=>p.Brand).ToList();
        }
    }
}
