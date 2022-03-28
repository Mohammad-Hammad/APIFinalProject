using Dapper;
using GFresh.Core.Common;
using GFresh.Core.Data;
using GFresh.Core.DTO;
using GFresh.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GFresh.Infra.Repository
{

    public class AdminRepository : IAdminRepository
    {
        private readonly IDbContext _dbContext;
        public AdminRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public bool CreateCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("@CategoryName", category.CatName, dbType: DbType.String);
            p.Add("@ImagePath", category.ImageName, dbType: DbType.String);
            var result = _dbContext.Connection.Query<Category>("Admin_Package.CreateCategory", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool CreateProduct(Product product)
        {
            var p = new DynamicParameters();
            p.Add("@ProName", product.ProName, dbType: DbType.String);
            p.Add("@ProPrice", product.ProPrice, dbType: DbType.Double);
            p.Add("@ImagePath", product.ImageName, dbType: DbType.String);
            p.Add("@Category_ID", product.CategoryID, dbType: DbType.Int32);
            var result = _dbContext.Connection.Query<Product>("Admin_Package.CreateProduct", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Categoty_ID", id, dbType: DbType.Int32);
            var result = _dbContext.Connection.Query<Category>("Admin_Package.DeleteCategory", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var p = new DynamicParameters();
            p.Add("@ProID", id, dbType: DbType.Int32);
            var result = _dbContext.Connection.Query<Product>("Admin_Package.DeleteProduct", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Category> GetAllCategories()
        {
            IEnumerable<Category> result = _dbContext.Connection.Query<Category>("Admin_Package.GetAllCategories", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Product> GetAllProducts()
        {
            IEnumerable<Product> result = _dbContext.Connection.Query<Product>("Admin_Package.GetAllProducts", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool UpdateCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("@Categoty_ID", category.CategoryID, dbType: DbType.Int32);
            p.Add("@CategoryName", category.CatName, dbType: DbType.String);
            p.Add("@ImagePath", category.ImageName, dbType: DbType.String);
            var result = _dbContext.Connection.Query<Category>("Admin_Package.UpdateCategory", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateProduct(Product product)
        {
            var p = new DynamicParameters();
            p.Add("@ProID", product.ProID, dbType: DbType.Int32);
            p.Add("@ProName", product.ProName, dbType: DbType.String);
            p.Add("@SALE_", product.Sale, dbType: DbType.Int32);
            p.Add("@ProPrice", product.ProPrice, dbType: DbType.Double);
            p.Add("@ImagePath", product.ImageName, dbType: DbType.String);
            p.Add("@Category_ID", product.CategoryID, dbType: DbType.Int32);
            p.Add("@Bar_Code", product.BarCode, dbType: DbType.Int32);
            var result = _dbContext.Connection.Query<Product>("Admin_Package.UpdateProduct", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public List<NumOfRegisteredCustomers> NumberOfCustomers()
        {
            var result = _dbContext.Connection.Query<NumOfRegisteredCustomers>("Admin_Package.NumberOfCustomerRegistered", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<SerachOrdersDate> SerachOrdersBetweenTwoDates(DateTime DateFrom, DateTime DateTo)
        {
            var p = new DynamicParameters();
            p.Add("START_DATE", DateFrom, dbType: DbType.DateTime);
            p.Add("END_DATE", DateTo, dbType: DbType.DateTime);
            var result = _dbContext.Connection.Query<SerachOrdersDate>("Admin_Package.SerachOrdersBetweenTwoDates", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<MonthlyRep> MonthlyReport()
        {
            var result = _dbContext.Connection.Query<MonthlyRep>("Admin_Package.MonthlyReport", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<AdminProfile> ViewAdminProfile(int id)
        {
            var p = new DynamicParameters();
            p.Add("Ad_ID", id, dbType: DbType.Int32);
            IEnumerable<AdminProfile> result = _dbContext.Connection.Query<AdminProfile>("Admin_Package.ViewAdminProfile", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool UpdateAdminProfile(Admins admins)
        {
            var p = new DynamicParameters();
            p.Add("@Ad_ID", admins.AdminID, dbType: DbType.Int32);
            p.Add("@Fname", admins.FirstName, dbType: DbType.String);
            p.Add("@Lname", admins.LastName, dbType: DbType.String);
            p.Add("@Mail", admins.Email, dbType: DbType.String);
            p.Add("@ImagePath", admins.ImageName, dbType: DbType.String);
            var result = _dbContext.Connection.Query<Admins>("Admin_Package.UpdateAdminProfile", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public List<UserRegisteredDetails> ViewUserRegisteredDetails()
        {
            IEnumerable<UserRegisteredDetails> result = _dbContext.Connection.Query<UserRegisteredDetails>("Admin_Package.ViewUserRegisteredDetails", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<AnuualRep> AnuualReport()
        {
            var result = _dbContext.Connection.Query<AnuualRep>("Admin_Package.AnuualReport", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public List<MonthlyRepSum> MonthlyReportSUM()
        {
            var result = _dbContext.Connection.Query<MonthlyRepSum>("Admin_Package.MonthlyReportSUM", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<MonthlyRepCount> MonthlyReportCount()
        {
            var result = _dbContext.Connection.Query<MonthlyRepCount>("Admin_Package.MonthlyReportCount", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<AnuualRepSum> AnuualReportSUM()
        {
            var result = _dbContext.Connection.Query<AnuualRepSum>("Admin_Package.AnuualReportSUM", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<AnuualRepCount> AnuualReportCount()
        {
            var result = _dbContext.Connection.Query<AnuualRepCount>("Admin_Package.AnuualReportCount", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}