using G3SpiritsReports.DataLayer.Context;
using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.DataLayer.Repositories
{
    public class YearlyBrandReportRepository
    {
        private readonly DataContext _db = new DataContext();
        public YearlyBrandReport GetYearlyBrandReport(int brandId, int countryId, int month, int year)
        {
            return _db.YearlyBrandReports.FirstOrDefault(p => p.BrandId == brandId && p.CountryId == countryId && p.Month == month && p.Year == year);
        }

        public void CreateOrEdit(YearlyBrandReport yearlyBrandReport)
        {
            var yearlyBrandReportToEdit = GetYearlyBrandReport(yearlyBrandReport.BrandId, yearlyBrandReport.CountryId, yearlyBrandReport.Month, yearlyBrandReport.Year);
            if (yearlyBrandReportToEdit == null)
            {
                CreateYearlyBrandReportItem(yearlyBrandReport);
            }
            else
            {
                yearlyBrandReportToEdit.PlannedPieces = yearlyBrandReport.PlannedPieces;
                yearlyBrandReportToEdit.SoldPieces = yearlyBrandReport.SoldPieces;
                _db.SaveChanges();
            }
        }

        private void CreateYearlyBrandReportItem(YearlyBrandReport yearlyBrandReport)
        {
            _db.YearlyBrandReports.Add(yearlyBrandReport);
            _db.SaveChanges();
        }
    }
}
