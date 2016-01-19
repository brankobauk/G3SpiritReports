using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace G3SpiritsReports.Helpers
{
    public class DropDownHelper
    {
        public IEnumerable<SelectListItem> GetMonthsListForDropDown()
        {
            var textInfo = new CultureInfo("en-US", false).TextInfo;
            var items = new List<SelectListItem>();
            //var selFirstListItem = new SelectListItem { Value = "", Text = "--- Choose ---" };
            //items.Add(selFirstListItem);

            var selItems = new List<SelectListItem>();
            if (DateTimeFormatInfo
                .CurrentInfo != null)
            {
                selItems = DateTimeFormatInfo
                    .CurrentInfo
                    .MonthNames
                    .Select((monthName, index) =>
                        new SelectListItem
                        {
                            Value = (index + 1).ToString(CultureInfo.InvariantCulture),
                            Text = textInfo.ToTitleCase(monthName)
                        }).Where(p => p.Text != "").ToList();

            }
            selItems = DateTimeFormatInfo
            .InvariantInfo
            .MonthNames
            .Select((monthName, index) =>
                new SelectListItem
                {
                    Value = (index + 1).ToString(CultureInfo.InvariantCulture),
                    Text = monthName
                }).Where(p => p.Text != "").ToList();

            items.AddRange(selItems);
            return items;
        }

        public IEnumerable<SelectListItem> GetYearsListForDropDown()
        {
            var yearDropdown = new List<SelectListItem>();
            for (int i = 2015; i <= DateTime.Now.Year + 1; i++)
            {
                var selListItem = new SelectListItem { Value = i.ToString(CultureInfo.InvariantCulture), Text = i.ToString(CultureInfo.InvariantCulture) };
                yearDropdown.Add(selListItem);
            }
            return yearDropdown;
        }

        public IEnumerable<SelectListItem> GetCountriesListForDropDown(List<Country> countries)
        {
            var countryDropdown = new List<SelectListItem>();
            foreach (var country in countries)
            {
                var selListItem = new SelectListItem { Value = country.CountryId.ToString(), Text = country.Name.ToString() };
                countryDropdown.Add(selListItem);
            }
            return countryDropdown;
        }

        public IEnumerable<SelectListItem> GetBrandsListForDropDown(List<Brand> brands)
        {
            var brandDropdown = new List<SelectListItem>();
            foreach (var brand in brands)
            {
                var selListItem = new SelectListItem { Value = brand.BrandId.ToString(), Text = brand.Name.ToString() };
                brandDropdown.Add(selListItem);
            }
            return brandDropdown;
        }
    }
}
