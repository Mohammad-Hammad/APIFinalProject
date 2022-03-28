using GFresh.Core.Data;
using GFresh.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFresh.Core.Service
{
    public interface IAdminService
    {
        public List<NumOfRegisteredCustomers> NumberOfCustomers();
        bool CreateCategory(Category category);
        List<Category> GetAllCategories();
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
        bool CreateProduct(Product product);
        List<Product> GetAllProducts();
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
        public List<SerachOrdersDate> SerachOrdersBetweenTwoDates(DateTime DateFrom, DateTime DateTo);
        public List<MonthlyRep> MonthlyReport();
        public List<AnuualRep> AnuualReport();
        public List<AdminProfile> ViewAdminProfile(int id);
        public bool UpdateAdminProfile(Admins admins);
        public List<UserRegisteredDetails> ViewUserRegisteredDetails();


        public List<MonthlyRepSum> MonthlyReportSUM();
        public List<MonthlyRepCount> MonthlyReportCount();
        public List<AnuualRepSum> AnuualReportSUM();
        public List<AnuualRepCount> AnuualReportCount();

    }
}
