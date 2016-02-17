using G3SpiritsReports.BusinessLogic.Brands;
using G3SpiritsReports.BusinessLogic.Countries;
using G3SpiritsReports.Helpers;
using G3SpiritsReports.Models.Models;
using G3SpiritsReports.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.BusinessLogic.YearlyBrandReports
{
    public class YearlyBrandReportManager
    {
        private readonly YearlyBrandReportHandler _yearlyBrandReportHandler = new YearlyBrandReportHandler();
        private readonly BrandManager _brandManager = new BrandManager();
        private readonly CountryManager _countryManager = new CountryManager();
        private readonly DropDownHelper _dropDownHelper = new DropDownHelper();
        public YearlyBrandReportViewModel GetYearlyBrandReportViewModel(int countryId, int brandId, int year)
        {
            var yearlyBrandReports = GetYearlyBrandReports(countryId, brandId, year);
            var yearlyBrandReportViewModel = new YearlyBrandReportViewModel()
            {
                YearlyBrandReports = yearlyBrandReports,
                BrandId = brandId,
                Year = year,
                CountryId = countryId,
                Brands = _dropDownHelper.GetBrandsListForDropDown(_brandManager.GetAllBrands()),
                Years = _dropDownHelper.GetYearsListForDropDown(),
                Countries = _dropDownHelper.GetCountriesListForDropDown(_countryManager.GetAllCountries())
            };
            return yearlyBrandReportViewModel;
        }

        public void CreateOrEdit(int countryId, int brandId, int year, int month, int plannedPieces, int soldPieces)
        {
            var yearlyBrandReport = new YearlyBrandReport()
            {
                CountryId = countryId,
                BrandId = brandId,
                Year = year,
                Month = month,
                PlannedPieces = plannedPieces,
                SoldPieces = soldPieces
            };
            _yearlyBrandReportHandler.CreateOrEdit(yearlyBrandReport);
        }

        public List<YearlyBrandReport> GetYearlyBrandReports(int countryId, int brandId, int year)
        {
            var yearlyBrandReports = new List<YearlyBrandReport>();
            for (int i = 1; i <= 12; i++)
            {
                var yearlyBrandReport = _yearlyBrandReportHandler.GetYearlyBrandReport(brandId, countryId, i, year);
                if (yearlyBrandReport == null) yearlyBrandReport = new YearlyBrandReport();
                yearlyBrandReport.Month = i;
                yearlyBrandReports.Add(yearlyBrandReport);
            }
            return yearlyBrandReports;
        }
        public List<YearlyBrandReportTable> GetYearlyBrandReportTables(DateTime date, int countryId)
        {
            try
            {
                var brands = _brandManager.GetAllBrands();
                var yearlyBrandReportTables = new List<YearlyBrandReportTable>();
                yearlyBrandReportTables.Add(GetYearlyBrandReportTable(countryId, 1, date.Month, date.Year, brands));
                yearlyBrandReportTables.Add(GetYearlyBrandReportTable(countryId, 2, date.Month, date.Year, brands));
                return yearlyBrandReportTables;
            }
            catch
            {
                return null;
            }
        }
        private YearlyBrandReportTable GetYearlyBrandReportTable(int countryId, int brandId, int month, int year, List<Brand> brands)
        {
            var brand = brands.FirstOrDefault(p => p.BrandId == brandId);
            var brandName = "Unknown";
            if(brand != null) brandName = brand.Name;
            var yearlyBrandReports = GetYearlyBrandReports(countryId, brandId, year);
            if (yearlyBrandReports != null)
            { 
                var item = yearlyBrandReports.FirstOrDefault(p=>p.Month == month);
                if (item != null)
                { 
                    if (item.SoldPieces == 0) month = month - 1;
                    var yearlyPiecesSum = yearlyBrandReports.Sum(p => p.PlannedPieces);
                    var plannedPiecesSum = yearlyBrandReports.Where(p=>p.Month<=month).Sum(p => p.PlannedPieces);
                    var achievedpiecesSum = yearlyBrandReports.Sum(p => p.SoldPieces);
                    return new YearlyBrandReportTable()
                    {
                        YearlyPiecesSum = yearlyPiecesSum.ToString(),
                        PlannedPiecesSum = plannedPiecesSum.ToString(),
                        AchievedPiecesSum = achievedpiecesSum.ToString(),
                        Name = brandName,
                        YearlyBrandReport = yearlyBrandReports
                    };
                }
                return null;
            }
            return null;
        }
    }
}
