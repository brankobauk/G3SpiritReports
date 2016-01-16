using G3SpiritsReports.DataLayer.Repositories;
using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.BusinessLogic.YearlyBrandReports
{
    public class YearlyBrandReportHandler
    {
        private readonly YearlyBrandReportRepository _yearlyBrandReportRepository = new YearlyBrandReportRepository();

        public YearlyBrandReport GetYearlyBrandReport(int brandId, int countryId, int month, int year)
        {
           return  _yearlyBrandReportRepository.GetYearlyBrandReport(brandId, countryId, month, year);
        }

        public void CreateOrEdit(YearlyBrandReport yearlyBrandReport)
        {
            _yearlyBrandReportRepository.CreateOrEdit(yearlyBrandReport);
        }
    }
}
