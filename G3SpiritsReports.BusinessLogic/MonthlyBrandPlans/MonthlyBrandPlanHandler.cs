using G3SpiritsReports.DataLayer.Repositories;
using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.BusinessLogic.MonthlyBrandPlans
{
    public class MonthlyBrandPlanHandler
    {
        private readonly MonthlyBrandPlanRepository _monthlyBrandPlanRepository = new MonthlyBrandPlanRepository();
        public void CreateOrEdit(MonthlyBrandPlan monthlyBrandPlan)
        {
            _monthlyBrandPlanRepository.CreateOrEdit(monthlyBrandPlan);
        }

        public MonthlyBrandPlan GetMonthlyBrandPlan(int brandId, int countryId, int month, int year)
        {
            return _monthlyBrandPlanRepository.GetMonthlyBrandPlan(brandId, countryId, month, year);
        }
    }
}
