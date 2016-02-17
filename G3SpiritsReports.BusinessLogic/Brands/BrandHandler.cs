using G3SpiritsReports.DataLayer.Repositories;
using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.BusinessLogic.Brands
{
    public class BrandHandler
    {
        private readonly BrandRepository _brandRepository = new BrandRepository();
        public List<Brand> GetAllBrands()
        {
            return _brandRepository.GetAllBrands();
        }

        public void CreateBrand(Brand brand)
        {
            _brandRepository.CreateBrand(brand);
        }

        public Brand GetBrand(int brandId)
        {
            return _brandRepository.GetBrand(brandId);
        }

        public void EditBrand(Brand brand, byte[] image)
        {
            _brandRepository.EditBrand(brand, image);
        }
    }
}
