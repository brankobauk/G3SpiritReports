using G3SpiritsReports.DataLayer.Context;
using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.DataLayer.Repositories
{
    public class MonthlyBrandPlanRepository
    {
        private readonly DataContext _db = new DataContext();
        public void CreateMonthlyBrandPlanItem(MonthlyBrandPlan monthlyBrandPlan)
        {
            _db.MonthlyBrandPlans.Add(monthlyBrandPlan);
            _db.SaveChanges();
        }

        public List<MonthlyBrandPlan> GetMonthlyBrandPlans(int month, int year)
        {
            return _db.MonthlyBrandPlans.Where(p => p.Month == month && p.Year == year).ToList();
        }

        public MonthlyBrandPlan GetMonthlyBrandPlan(int brandId, int countryId, int month, int year)
        {
            return _db.MonthlyBrandPlans.FirstOrDefault(p => p.BrandId == brandId && p.CountryId == countryId && p.Month == month && p.Year == year);
        }

        public void CreateOrEdit(MonthlyBrandPlan monthlyBrandPlan)
        {
            var monthlyBrandPlanToEdit = GetMonthlyBrandPlan(monthlyBrandPlan.BrandId, monthlyBrandPlan.CountryId, monthlyBrandPlan.Month, monthlyBrandPlan.Year);
            if (monthlyBrandPlanToEdit == null)
            {
                CreateMonthlyBrandPlanItem(monthlyBrandPlan);
            }
            else
            {
                monthlyBrandPlanToEdit.PlannedPieces = monthlyBrandPlan.PlannedPieces;
                _db.SaveChanges();
            }
        }

        public List<MonthlyBrandPlan> GetMonthlyBrandPlanItems(int countryId, int month, int year)
        {
            return _db.MonthlyBrandPlans.Where(p => p.CountryId == countryId && p.Month == month && p.Year == year).ToList();
        }

        public MonthlyBrandReport GetLatestMonthlyBrandReport()
        {
            return _db.MonthlyBrandReports.OrderByDescending(p => p.Date).FirstOrDefault();
        }
    }
}
