using G3SpiritsReports.BusinessLogic.Brands;
using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G3SpiritsReports.UI.Controllers
{
    public class BrandController : Controller
    {
        private readonly BrandManager _brandManager = new BrandManager();
        //
        // GET: /Brand/

        public ActionResult Index()
        {
            var brands = _brandManager.GetAllBrands();
            return View(brands);
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
        public ActionResult Create(Brand brand)
        {
            try
            {
                _brandManager.CreateBrand(brand);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Brand/Edit/5

        public ActionResult Edit(int brandId)
        {
            var brand = _brandManager.GetBrand(brandId);
            return View(brand);
        }

        //
        // POST: /Brand/Edit/5

        [HttpPost]
        public ActionResult Edit(Brand brand, HttpPostedFileBase file)
        {
            try
            {
                byte[] image = null;
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    string path;
                    if (fileName != null)
                    {
                        path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                        file.SaveAs(path);
                        image = System.IO.File.ReadAllBytes(path);
                        System.IO.File.Delete(path);
                    }

                }
                _brandManager.EditBrand(brand, image);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
