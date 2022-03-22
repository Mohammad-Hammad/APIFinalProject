using GFresh.Core.Data;
using GFresh.Core.DTO;
using GFresh.Core.Repository;
using GFresh.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFresh.Infra.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
    
        public bool CreateCategory(Category category)
        {
            return _adminRepository.CreateCategory(category);
        }

        public bool CreateProduct(Product product)
        {
            return _adminRepository.CreateProduct(product);
        }

        public bool DeleteCategory(int id)
        {
            return (_adminRepository.DeleteCategory(id));
        }

        public bool DeleteProduct(int id)
        {
            return _adminRepository.DeleteProduct(id);
        }

        public List<Category> GetAllCategories()
        {
            return _adminRepository.GetAllCategories();
        }

        public List<Product> GetAllProducts()
        {
            return _adminRepository.GetAllProducts();
        }

        
        
        public bool UpdateCategory(Category category)
        {
            return _adminRepository.UpdateCategory(category);
        }

        public bool UpdateProduct(Product product)
        {
            return _adminRepository.UpdateProduct(product);
        }
        public NumOfRegisteredCustomers NumberOfCustomers()
        {
            return _adminRepository.NumberOfCustomers();
        }
        public List<SerachOrdersDate> SerachOrdersBetweenTwoDates(DateTime DateFrom, DateTime DateTo)
        {
            return _adminRepository.SerachOrdersBetweenTwoDates(DateFrom, DateTo);
        }
        public List<MonthlyRep> MonthlyReport()
        {
            return _adminRepository.MonthlyReport();
        }
        public List<AdminProfile> ViewAdminProfile(int id)
        {
            return _adminRepository.ViewAdminProfile(id);

        }
        public bool UpdateAdminProfile(Admins admins)
        {
            return _adminRepository.UpdateAdminProfile(admins);
        }
    }
}
