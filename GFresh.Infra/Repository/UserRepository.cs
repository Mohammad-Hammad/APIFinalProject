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
using System.Threading.Tasks;

namespace GFresh.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _dbContext;
        public UserRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<Invoice> DisplayInvoice(int customerId)
        {
            var p = new DynamicParameters();
            p.Add("@customer_id", customerId, dbType: DbType.Int32);
            IEnumerable<Invoice> result =
            _dbContext.Connection.Query<Invoice>("User_Package.DisplayInvoice", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Category>> GetAllCategorsAndProduct()
        {
            var result = await _dbContext.Connection.QueryAsync<Category, Product, Category>("User_Package.GetAllCategorsAndProduct",
              (category, product) =>
              {
                  category.Products = category.Products ?? new List<Product>();
                  category.Products.Add(product);
                  return category;
              }
              , splitOn: "ProId"
              , commandType: CommandType.StoredProcedure);
            var finalresult = result.AsList<Category>().GroupBy(p => p.CategoryID).Select(g =>
            {
                Category category = g.First();
                category.Products = g.Where
                (g => g.Products.Count() > 0).Select(p =>
                p.Products.Single()).GroupBy(product => product.ProID).Select(product =>
                new Product
                {
                    ProID = product.First().ProID,
                    ProName = product.First().ProName,
                    ProPrice = product.First().ProPrice
                        ,
                    BarCode = product.First().BarCode,
                    ImageName = product.First().ImageName
                }).ToList();
                return category;
            }).ToList();
            return finalresult;
        }

        public List<BillingOrders> PayOrder()
        {
            IEnumerable<BillingOrders> result =
           _dbContext.Connection.Query<BillingOrders>("User_Package.PayOrder", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public string Register(RegisterUser registerUser)
        {

            var row = new DynamicParameters();
            row.Add("@F_Name", registerUser.FirstName, dbType: DbType.String);
            row.Add("@L_Name", registerUser.LaststName, dbType: DbType.String);
            row.Add("@E_Email", registerUser.Email, dbType: DbType.String);
            row.Add("@I_image", registerUser.ImageName, dbType: DbType.String);
            row.Add("@U_Name", registerUser.UserName, dbType: DbType.String);
            row.Add("@P_Password", registerUser.Password, dbType: DbType.String);

            var result = _dbContext.Connection.Query<RegisterUser>
               ("User_Package.RegisterUser", row,
               commandType: CommandType.StoredProcedure);
            return "the registration is done";

        }

        public List<SearchBarCode> SearchBarcode(string barCode)
        {
            var p = new DynamicParameters();
            p.Add("@bar_code", barCode, dbType: DbType.String);
            IEnumerable<SearchBarCode> result =
            _dbContext.Connection.Query<SearchBarCode>("User_Package.SearchBarcode", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<ProductSearch> SearchOfProduct(Product product)
        {
            var p = new DynamicParameters();
            p.Add("@Product_Name", product.ProName, dbType: DbType.String);
            p.Add("@Category_Name", product.CategoryID, dbType: DbType.Int32);

            var result = _dbContext.Connection.Query<ProductSearch>
              ("User_Package.SearchOfProduct", p,
              commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateCustomerProfile(Customer customer)
        {
            var p = new DynamicParameters();
            p.Add("@customer_Id", customer.CusID, dbType: DbType.Int32);
            p.Add("@first_Name", customer.FirstName, dbType: DbType.String);
            p.Add("@last_Name", customer.LastName, dbType: DbType.String);
            p.Add("@cus_email", customer.Email, dbType: DbType.String);
            p.Add("@image_name", customer.ImageName, dbType: DbType.String);


            var result = _dbContext.Connection.Query<Customer>("User_Package.UpdateCustomerProfile", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
