using GFresh.Core.Data;
using GFresh.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GFresh.Core.Repository
{
    public interface IUserRepository
    {
        public string Register(RegisterUser registerUser);
        public Task<List<Category>> GetAllCategorsAndProduct();
        public List<ProductSearch> SearchOfProduct(Product product);
        public List<ProductSearch> getAllProduct();

        public List<BillingOrders> PayOrder();
        List<Invoice> DisplayInvoice(int customerId);
        SearchBarCode SearchBarcode(string barCode);
        bool UpdateCustomerProfile(Customer customer);

        ViewProfile ViewCustomerProfile(string cus_id);
        bool CreateCredit(Credits newCredites);

        bool CreateTestimonial(Testimonial testimonial);

        bool DeleteTestimonial(int id);

        bool CreateContact(Contact contact);

        bool CreateAbout(About about);
        bool CreateHome(HomePage homePage);
        List<HomeDTO> GetAllHome();
        List<AboutDTO> GetAllAbout();
    }
}
