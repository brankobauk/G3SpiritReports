using G3SpiritsReports.DataLayer.Repositories;
using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.BusinessLogic.Countries
{
    public class CountryManager
    {
        private readonly CountryHandler _countryHandler = new CountryHandler();
        public List<Country> GetAllCountries()
        {
            return _countryHandler.GetAllCountries();
        }

        public void CreateCountry(Country Country)
        {
            _countryHandler.CreateCountry(Country);
        }

        public Country GetCountry(int CountryId)
        {
            return _countryHandler.GetCountry(CountryId);
        }

        public void EditCountry(Country Country)
        {
            _countryHandler.EditCountry(Country);
        }
    }
}
