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
            p.Add("@c_amount", newCredites.Amount, dbType: DbType.Double);
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
        public bool CreateTestimonial(Testimonial testimonial)
        {
            var p = new DynamicParameters();
            p.Add("@Comment", testimonial.Comment, dbType: DbType.String);
            p.Add("@CusId", testimonial.CustomerID, dbType: DbType.Int32); ;
            var result = _dbContext.Connection.Query<Testimonial>("User_Package.CreateTestimonial", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteTestimonial(int id)
        {
            var p = new DynamicParameters();
            p.Add("@TID", id, dbType: DbType.Int32);
            var result = _dbContext.Connection.Query<Testimonial>("User_Package.DeleteTestimonial", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool CreateContact(Contact contact)
        {
            var p = new DynamicParameters();
            p.Add("@Name", contact.Name, dbType: DbType.String);
            p.Add("@Mail", contact.Email, dbType: DbType.String);
            p.Add("@Subjct", contact.Subject, dbType: DbType.String);
            p.Add("@Msg", contact.Message, dbType: DbType.String);
            var result = _dbContext.Connection.Query<Product>("User_Package.CreateContact", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool CreateAbout(About about)
        {
            var p = new DynamicParameters();
            p.Add("@Image", about.Image, dbType: DbType.String);
            p.Add("@Ftext", about.FirstText, dbType: DbType.String);
            p.Add("@Stext", about.SecondText, dbType: DbType.String);
            var result = _dbContext.Connection.Query<About>("User_Package.CreateAbout", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool CreateHome(HomePage homePage)
        {
            var p = new DynamicParameters();
            p.Add("@FirstImg", homePage.FirstSlider, dbType: DbType.String);
            p.Add("@SecondImg", homePage.SecondSlider, dbType: DbType.String);
            p.Add("@ThirdImg", homePage.ThirdSlider, dbType: DbType.String);
            p.Add("@Ftext", homePage.FirstText, dbType: DbType.String);
            p.Add("@Stext", homePage.SecondText, dbType: DbType.String);
            p.Add("@Ttext", homePage.CatName, dbType: DbType.String);
            p.Add("@Frtext", homePage.ProdName, dbType: DbType.String);
            var result = _dbContext.Connection.Query<Product>("User_Package.CreateHome", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public List<HomeDTO> GetAllHome()
        {
            IEnumerable<HomeDTO> result = _dbContext.Connection.Query<HomeDTO>("User_Package.GetAllHome", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<AboutDTO> GetAllAbout()
        {
            IEnumerable<AboutDTO> result = _dbContext.Connection.Query<AboutDTO>("User_Package.GetAllAbout", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}

