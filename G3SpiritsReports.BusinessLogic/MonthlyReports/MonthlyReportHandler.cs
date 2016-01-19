using G3SpiritsReports.DataLayer.Repositories;
using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.BusinessLogic.MonthlyReports
{
    public class MonthlyReportHandler
    {
        private readonly MonthlyReportRepository _monthlyReportRepository = new MonthlyReportRepository();

        public MonthlyReport GetMonthlyReport(int countryId, int month, int year)
        {
            return _monthlyReportRepository.GetMonthlyReport(countryId, month, year);
        }

        public void CreateOrEdit(MonthlyReport monthlyReport)
        {
            _monthlyReportRepository.CreateOrEdit(monthlyReport);
        }
    }
}
