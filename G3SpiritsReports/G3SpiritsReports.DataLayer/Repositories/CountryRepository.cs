using G3SpiritsReports.DataLayer.Context;
using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.DataLayer.Repositories
{
    public class CountryRepository
    {
        private readonly DataContext _db = new DataContext();
        public List<Country> GetAllCountries()
        {
            return _db.Countries.ToList();
        }

        public void CreateCountry(Country country)
        {
            _db.Countries.Add(country);
            _db.SaveChanges();
        }

        public Country GetCountry(int countryId)
        {
            return _db.Countries.FirstOrDefault(p => p.CountryId == countryId);
        }

        public void EditCountry(Country country)
        {
            var countryToEdit = GetCountry(country.CountryId);
            if (countryToEdit == null) return;
            countryToEdit.Name = country.Name;
            _db.SaveChanges();
        }
    }
}
