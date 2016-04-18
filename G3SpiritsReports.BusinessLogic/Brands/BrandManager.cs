using G3SpiritsReports.DataLayer.Repositories;
using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.BusinessLogic.Brands
{
    public class BrandManager
    {
        private readonly BrandHandler _brandHandler = new BrandHandler();
        public List<Brand> GetAllBrands()
        {
            return _brandHandler.GetAllBrands();
        }

        public void CreateBrand(Brand brand)
        {
            _brandHandler.CreateBrand(brand);
        }

        public Brand GetBrand(int brandId)
        {
            return _brandHandler.GetBrand(brandId);
        }

        public void EditBrand(Brand brand, byte[] image)
        {
            _brandHandler.EditBrand(brand, image);
        }

        public void SaveSort(int brandId, int sortOrder)
        {
            _brandHandler.SaveSort(brandId, sortOrder);
        }
    }
}
