using G3SpiritsReports.BusinessLogic.Countries;
using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G3SpiritsReports.UI.Controllers
{
    public class CountryController : Controller
    {
        private readonly CountryManager _countryManager = new CountryManager();
        //
        // GET: /Country/

        public ActionResult Index()
        {
            var countries = _countryManager.GetAllCountries();
            return View(countries);
        }

        //
        // GET: /Brand/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Brand/Create

        [HttpPost]
        public ActionResult Create(Country country)
        {
            try
            {
                _countryManager.CreateCountry(country);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Brand/Edit/5

        public ActionResult Edit(int countryId)
        {
            var country = _countryManager.GetCountry(countryId);
            return View(country);
        }

        //
        // POST: /Brand/Edit/5

        [HttpPost]
        public ActionResult Edit(Country country)
        {
            try
            {
                _countryManager.EditCountry(country);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
