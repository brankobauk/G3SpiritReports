using G3SpiritsReports.DataLayer.Repositories;
using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.BusinessLogic.Countries
{
    public class CountryHandler
    {
        private readonly CountryRepository _countryRepository = new CountryRepository();
        public List<Country> GetAllCountries()
        {
            return _countryRepository.GetAllCountries();
        }

        public void CreateCountry(Country Country)
        {
            _countryRepository.CreateCountry(Country);
        }

        public Country GetCountry(int CountryId)
        {
            return _countryRepository.GetCountry(CountryId);
        }

        public void EditCountry(Country Country)
        {
            _countryRepository.EditCountry(Country);
        }
    }
}
