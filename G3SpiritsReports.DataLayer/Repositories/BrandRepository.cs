using G3SpiritsReports.DataLayer.Context;
using G3SpiritsReports.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.DataLayer.Repositories
{
    public class BrandRepository
    {
        private readonly DataContext _db = new DataContext(); 
        public List<Brand> GetAllBrands()
        {
            return _db.Brands.ToList();
        }

        public void CreateBrand(Brand brand)
        {
            var noOfBrand = GetAllBrands().Count + 1;
            brand.SortOrder = noOfBrand;
            _db.Brands.Add(brand);
            _db.SaveChanges();
        }

        public Brand GetBrand(int brandId)
        {
            return _db.Brands.FirstOrDefault(p => p.BrandId == brandId);
        }

        public void EditBrand(Brand brand, byte[] image)
        {
            
            var brandToEdit = GetBrand(brand.BrandId);
            if (brandToEdit == null) return;
            brandToEdit.Name = brand.Name;
            if (image != null)
            {
                brandToEdit.Image = image;
            }
            _db.SaveChanges();
        }

        public void SortOrder(int brandId, int sortOrder)
        {
            var brandToEdit = GetBrand(brandId);
            if (brandToEdit == null) return;
            brandToEdit.SortOrder = sortOrder;
            _db.SaveChanges();
        }
    }
}
