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
        public List<NumOfRegisteredCustomers> NumberOfCustomers()
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
        public AdminProfile ViewAdminProfile(int id)
        {
            return _adminRepository.ViewAdminProfile(id);

        }
        public bool UpdateAdminProfile(Admins admins)
        {
            return _adminRepository.UpdateAdminProfile(admins);
        }
        public List<UserRegisteredDetails> ViewUserRegisteredDetails()
        {
            return _adminRepository.ViewUserRegisteredDetails();
        }

        public List<AnuualRep> AnuualReport()
        {
            return _adminRepository.AnuualReport();
        }

        public List<MonthlyRepSum> MonthlyReportSUM()
        {
            return _adminRepository.MonthlyReportSUM();
        }
        public List<MonthlyRepCount> MonthlyReportCount()
        {
            return _adminRepository.MonthlyReportCount();
        }
        public List<AnuualRepSum> AnuualReportSUM()
        {
            return _adminRepository.AnuualReportSUM();
        }
        public List<AnuualRepCount> AnuualReportCount()
        {
            return _adminRepository.AnuualReportCount();
        }
        public bool CreateAdmin(Admins admins)
        {
            return _adminRepository.CreateAdmin(admins);
        }

        public bool DeleteAdmin(int id)
        {
            return _adminRepository.DeleteAdmin(id);
        }
        public List<getAllAdmins> GetAllAdmins()
        {
            return _adminRepository.GetAllAdmins();
        }
    }
}
