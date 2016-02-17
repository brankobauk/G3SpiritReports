using G3SpiritsReports.DataLayer.Repositories;
using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.BusinessLogic.MonthlyBrandReports
{
    public class MonthlyBrandReportHandler
    {
        private readonly MonthlyBrandReportRepository _monthlyBrandReportRepository = new MonthlyBrandReportRepository();
        private readonly MonthlyBrandReportRepository _monthlyBrandPlanRepository = new MonthlyBrandReportRepository();
        public void CreateOrEdit(MonthlyBrandReport monthlyBrandReport)
        {
            _monthlyBrandReportRepository.CreateOrEdit(monthlyBrandReport);
        }

        public MonthlyBrandReport GetMonthlyBrandReport(int brandId, int countryId, DateTime date)
        {
            return _monthlyBrandReportRepository.GetMonthlyBrandReport(brandId, countryId, date);
        }

        public List<MonthlyBrandReport> GetMonthlyBrandReportItems(DateTime date, int countryId)
        {
            return _monthlyBrandReportRepository.GetMonthlyBrandReportItems(date, countryId);
        }
    }
}
