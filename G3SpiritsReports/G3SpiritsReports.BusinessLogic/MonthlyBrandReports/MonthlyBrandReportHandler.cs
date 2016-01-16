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
        public void CreateOrEdit(MonthlyBrandReport monthlyBrandReport)
        {
            _monthlyBrandReportRepository.CreateOrEdit(monthlyBrandReport);
        }

        public MonthlyBrandReport GetMonthlyBrandReport(int brandId, int countryId, int month, int year)
        {
            return _monthlyBrandReportRepository.GetMonthlyBrandReport(brandId, countryId, month, year);
        }
    }
}
