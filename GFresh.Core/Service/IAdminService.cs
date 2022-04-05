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
        public List<SerachOrdersDate> SerachOrdersBetweenTwoDates(SerachOrdersDate serachOrdersDate);
        public List<MonthlyRep> MonthlyReport();
        public List<AnuualRep> AnuualReport();
        public AdminProfile ViewAdminProfile(int id);
        public bool UpdateAdminProfile(Admins admins);
        public List<UserRegisteredDetails> ViewUserRegisteredDetails();


        public List<MonthlyRepSum> MonthlyReportSUM();
        public List<MonthlyRepCount> MonthlyReportCount();
        public List<AnuualRepSum> AnuualReportSUM();
        public List<AnuualRepCount> AnuualReportCount();

        bool CreateAdmin(Admins admins);

        bool DeleteAdmin(int id);
        List<getAllAdmins> GetAllAdmins();


        bool CreateContact(Contact contact);
        bool UpdateContact(Contact contact);
        bool DeleteContact(int id);
        List<ContactDTO> GetAllContact();


        bool CreateAbout(About about);
        bool UpdateAbout(About about);
        bool DeleteAbout(int id);
        List<AboutDTO> GetAllAbout();

        bool CreateHome(HomePage homePage);
        bool UpdateHome(HomePage homePage);
        bool DeleteHome(int id);
        List<HomeDTO> GetAllHome();


        bool CreateSlider(Slider slider);
        bool UpdateSlider(Slider slider);
        bool DeleteSlider(int id);
        List<Slider> GetAllSlider();

        bool CreateTestimonial(Testimonial testimonial);
        bool UpdateTestimonial(Testimonial testimonial);
        bool DeleteTestimonial(int id);
        List<TestimonialDTO> GetAllTestimonial();
    }
}
