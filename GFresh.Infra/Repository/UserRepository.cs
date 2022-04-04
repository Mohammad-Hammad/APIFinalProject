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

        public bool CreateCredit(Credits newCredites)
        {
            var p = new DynamicParameters();
            p.Add("@card_name", newCredites.CardName, dbType: DbType.String);
            p.Add("@card_num", newCredites.CardNumber, dbType: DbType.Int32);
            p.Add("@cus_id", newCredites.CustomerID, dbType: DbType.Int32);
           
            var result = _dbContext.Connection.Query<Credits>("User_Package.CreateCredit",
                p, commandType: CommandType.StoredProcedure);
            return true;
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
            row.Add("@L_Name", registerUser.LastName, dbType: DbType.String);
            row.Add("@E_Email", registerUser.Email, dbType: DbType.String);
            row.Add("@I_image", registerUser.ImageName, dbType: DbType.String);
            row.Add("@U_Name", registerUser.UserName, dbType: DbType.String);
            row.Add("@P_Password", registerUser.Password, dbType: DbType.String);

            var result = _dbContext.Connection.Query<RegisterUser>
               ("User_Package.RegisterUser", row,
               commandType: CommandType.StoredProcedure);
            return "the registration is done";

        }

        public SearchBarCode SearchBarcode(string barCode)
        {
            var p = new DynamicParameters();
            p.Add("@bar_code", barCode, dbType: DbType.String);
            var result =
            _dbContext.Connection.Query<SearchBarCode>("User_Package.SearchBarcode",
            p, commandType: CommandType.StoredProcedure).SingleOrDefault<SearchBarCode>();
            return result;
        }

        public List<ProductSearch> SearchOfProduct(Product product)
        {
            var p = new DynamicParameters();
            p.Add("@Product_Name", product.ProName, dbType: DbType.String);

            var result = _dbContext.Connection.Query<ProductSearch>
              ("User_Package.SearchOfProduct", p,
              commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<ProductSearch> getAllProduct()
        {

            var result = _dbContext.Connection.Query<ProductSearch>
              ("User_Package.GETALLPRODUCT",
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

        public ViewProfile ViewCustomerProfile(string cus_id)
        {
            var p = new DynamicParameters();
            p.Add("@customer_id", cus_id, dbType: DbType.Int32);
            var result =
            _dbContext.Connection.Query<ViewProfile>("User_Package.ViewCustomerProfile",
            p, commandType: CommandType.StoredProcedure).SingleOrDefault<ViewProfile>();
            return result;
        }

        public List<getCart> getCarts(int customer_id)
        {
            var p = new DynamicParameters();
            p.Add("@customer_Id", customer_id, dbType: DbType.Int32);
            IEnumerable<getCart> result =
            _dbContext.Connection.Query<getCart>("User_Package.getcart", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool AddToCarts(getCart getCart)
        {
            var p = new DynamicParameters();
            p.Add("@customer_Id", getCart.customerId, dbType: DbType.Int32);
            p.Add("@Pro_Id", getCart.ProId, dbType: DbType.Int32);
          


            var result = _dbContext.Connection.Query<getCart>("User_Package.addtocart", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeletToCarts(getCart getCart)
        {
            var p = new DynamicParameters();
            p.Add("@customer_Id", getCart.customerId, dbType: DbType.Int32);
            p.Add("@Pro_Id", getCart.ProId, dbType: DbType.Int32);



            var result = _dbContext.Connection.Query<getCart>("User_Package.deletcart", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public GetTotal GetTotalCustomer(int customer_id)
        {
            var p = new DynamicParameters();
            p.Add("@customer_Id", customer_id, dbType: DbType.Int32);

            var result = _dbContext.Connection.Query<GetTotal>("User_Package.GetTotalCustomer", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public bool UpdateQuantity(Updatecart updatecart)
        {
            var p = new DynamicParameters();
            p.Add("@QUAN_TITY", updatecart.Quantity, dbType: DbType.Int32);
            p.Add("@Pro_Id", updatecart.ProId , dbType: DbType.Int32);
            p.Add("@customer_Id", updatecart.customerId, dbType: DbType.Int32);

            var result = _dbContext.Connection.Query<Updatecart>("User_Package.updateqauntity", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public CreditAmount GetCreditAmount(int customerId)
        {

            var p = new DynamicParameters();
            p.Add("@customer_id", customerId, dbType: DbType.Int32);
            var result =
           _dbContext.Connection.Query<CreditAmount>("User_Package.GETCREDITAMOUNT",
            p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool updateAmount(Credits credits)
        {
            var p = new DynamicParameters();
            p.Add("@cus_amount", credits.Amount, dbType: DbType.Int32);
            p.Add("@customer_Id", credits.CustomerID, dbType: DbType.String);



            var result = _dbContext.Connection.Query<Credits>("User_Package.updateAmount", p, commandType: CommandType.StoredProcedure);
            return true;
        }


    }
}

