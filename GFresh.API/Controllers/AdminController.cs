using GFresh.Core.Data;
using GFresh.Core.DTO;
using GFresh.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace GFresh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateCategory([FromBody] Category category)
        {
            return _adminService.CreateCategory(category);
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        public List<Category> GetAllCategories()
        {
            return _adminService.GetAllCategories();
        }
        [HttpPut]
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateCategory([FromBody] Category category)
        {
            return _adminService.UpdateCategory(category);
        }
        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public bool DeleteCategory(int id)
        {
            return _adminService.DeleteCategory(id);
        }
        [HttpPost]
        [Route("Product")]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateProduct([FromBody] Product product)
        {
            return _adminService.CreateProduct(product);
        }
        [HttpGet]
        [Route("Product")]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        public List<Product> GetAllProducts()
        {
            return _adminService.GetAllProducts();
        }
        [HttpPut]
        [Route("Product")]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateProduct([FromBody] Product product)
        {
            return _adminService.UpdateProduct(product);
        }
        [HttpDelete]
        [Route("Product/{id}")]
        public bool DeleteProduct(int id)
        {
            return _adminService.DeleteProduct(id);
        }
        [HttpPost]
        [Route("UploadImg")]
        public Category UploadImage()
        {
            try
            {
                var Image = Request.Form.Files[0];
                var ImageName = Guid.NewGuid().ToString() + Image.FileName;
                var fullPath = Path.Combine("C:\\Users\\moham\\Desktop\\HyperMarket\\src\\assets\\images", ImageName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                Category category = new Category();
                category.ImageName = ImageName;
                return category;
            }
            catch
            {
                return null;
            }
        }
        [HttpGet]
        [Route("NumberOfCustomers")]
        public List<NumOfRegisteredCustomers> NumberOfCustomers()
        {
            return _adminService.NumberOfCustomers();
        }
        [HttpPost]
        [Route("SearchDates")]
        [ProducesResponseType(typeof(List<SerachOrdersDate>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<SerachOrdersDate> SerachOrdersBetweenTwoDates([FromBody]SerachOrdersDate serachOrdersDate)
        {
            return _adminService.SerachOrdersBetweenTwoDates(serachOrdersDate);
        }
        [HttpGet]
        [Route("MonthlyReport")]
        public List<MonthlyRep> MonthlyReport()
        {
            return _adminService.MonthlyReport();
        }
        [HttpPut]
        [Route("UpdateViewAdminProfile")]
        [ProducesResponseType(typeof(List<Admins>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateAdminProfile([FromBody] Admins admins)
        {
            return _adminService.UpdateAdminProfile(admins);
        }
        [HttpGet]
        [Route("ViewAdminProfile/{id}")]
        public AdminProfile ViewAdminProfile(int id)
        {
            return _adminService.ViewAdminProfile(id);
        }
        [HttpGet]
        [Route("ViewUserRegisteredDetails")]
        public List<UserRegisteredDetails> ViewUserRegisteredDetails()
        {
            return _adminService.ViewUserRegisteredDetails();
        }

        [HttpGet]
        [Route("AnuualReport")]
        public List<AnuualRep> AnuualReport()
        {
            return _adminService.AnuualReport();
        }
        [HttpPost]
        [Route("UploadImgPro")]
        public Product UploadImagePro()
        {
            try
            {
                var Image = Request.Form.Files[0];
                var ImageName = Guid.NewGuid().ToString() + Image.FileName;
                var fullPath = Path.Combine("C:\\Users\\moham\\Desktop\\HyperMarket\\src\\assets\\images", ImageName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                Product product = new Product();
                product.ImageName = ImageName;
                return product;
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        [Route("UploadImageAdmin")]
        public Admins UploadImageAdmin()
        {
            try
            {
                var Image = Request.Form.Files[0];
                var ImageName = Guid.NewGuid().ToString() + Image.FileName;
                var fullPath = Path.Combine("C:\\Users\\moham\\Desktop\\HyperMarket\\src\\assets\\images", ImageName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                Admins admins = new Admins();
                admins.ImageName = ImageName;
                return admins;
            }
            catch
            {
                return null;
            }
        }
        [HttpGet]
        [Route("MonthlyReportSUM")]
        public List<MonthlyRepSum> MonthlyReportSUM()
        {
            return _adminService.MonthlyReportSUM();
        }
        [HttpGet]
        [Route("MonthlyReportCount")]
        public List<MonthlyRepCount> MonthlyReportCount()
        {
            return _adminService.MonthlyReportCount();
        }
        [HttpGet]
        [Route("AnuualReportSUM")]
        public List<AnuualRepSum> AnuualReportSUM()
        {
            return _adminService.AnuualReportSUM();
        }
        [HttpGet]
        [Route("AnuualReportCount")]
        public List<AnuualRepCount> AnuualReportCount()
        {
            return _adminService.AnuualReportCount();
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<Admins>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CreateAdmin")]
        public bool CreateAdmin(Admins admins)
        {
            return _adminService.CreateAdmin(admins);
        }
        [HttpDelete]
        [Route("DeleteAdmin/{id}")]
        public bool DeleteAdmin(int id)
        {
            return _adminService.DeleteAdmin(id);
        }
        [HttpGet]
        [Route("GetAllAdmins")]
        public List<getAllAdmins> GetAllAdmins()
        {
            return _adminService.GetAllAdmins();
        }



        [HttpPost]
        [ProducesResponseType(typeof(List<Contact>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CreateContact")]
        public bool CreateContact(Contact contact)
        {
            return _adminService.CreateContact(contact);
        }
        [HttpPut]
        [ProducesResponseType(typeof(List<Contact>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("UpdateContact")]
        public bool UpdateContact(Contact contact)
        {
            return _adminService.UpdateContact(contact);
        }
        [HttpDelete]
        [Route("DeleteContact/{id}")]
        public bool DeleteContact(int id)
        {
            return _adminService.DeleteContact(id);
        }
        [HttpGet]
        [Route("GetAllContact")]
        [ProducesResponseType(typeof(List<ContactDTO>), StatusCodes.Status200OK)]
        public List<ContactDTO> GetAllContact()
        {
            return _adminService.GetAllContact();
        }
        [HttpPost]
        [ProducesResponseType(typeof(About), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CreateAbout")]
        public bool CreateAbout(About about)
        {
            return _adminService.CreateAbout(about);
        }
        [HttpPut]
        [ProducesResponseType(typeof(About), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("UpdateAbout")]
        public bool UpdateAbout(About about)
        {
            return _adminService.UpdateAbout(about);
        }
        [HttpDelete]
        [Route("DeleteAbout/{id}")]
        public bool DeleteAbout(int id)
        {
            return _adminService.DeleteAbout(id);
        }
        [HttpGet]
        [Route("GetAllAbout")]
        [ProducesResponseType(typeof(List<AboutDTO>), StatusCodes.Status200OK)]
        public List<AboutDTO> GetAllAbout()
        {
            return _adminService.GetAllAbout();
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<HomePage>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CreateHome")]
        public bool CreateHome(HomePage homePage)
        {
            return _adminService.CreateHome(homePage);
        }
        [HttpPut]
        [ProducesResponseType(typeof(List<HomePage>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("UpdateHome")]
        public bool UpdateHome(HomePage homePage)
        {
            return _adminService.UpdateHome(homePage);
        }
        [HttpDelete]
        [Route("DeleteHome/{id}")]
        public bool DeleteHome(int id)
        {
            return _adminService.DeleteHome(id);
        }
        [HttpGet]
        [Route("GetAllHome")]
        [ProducesResponseType(typeof(HomeDTO), StatusCodes.Status200OK)]
        public List<HomeDTO> GetAllHome()
        {
            return _adminService.GetAllHome();
        }
        [HttpPost]
        [Route("UploadImageAbout")]
        public About UploadImageAbout()
        {
            try
            {
                var Image = Request.Form.Files[0];
                var ImageName = Guid.NewGuid().ToString() + Image.FileName;
                var fullPath = Path.Combine("C:\\Users\\moham\\Desktop\\Hyper_Market\\src\\assets\\images", ImageName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                About About = new About();
                About.Image = ImageName;
                return About;
            }
            catch
            {
                return null;
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<Slider>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CreateSlider")]
        public bool CreateSlider(Slider slider)
        {
            return _adminService.CreateSlider(slider);
        }
        [HttpPut]
        [ProducesResponseType(typeof(List<Slider>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("UpdateSlider")]
        public bool UpdateSlider(Slider slider)
        {
            return _adminService.UpdateSlider(slider);
        }
        [HttpDelete]
        [Route("DeleteSlider/{id}")]
        public bool DeleteSlider(int id)
        {
            return _adminService.DeleteSlider(id);
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Slider>), StatusCodes.Status200OK)]
        [Route("GetAllSlider")]
        public List<Slider> GetAllSlider()
        {
            return _adminService.GetAllSlider();
        }
        [HttpPost]
        [Route("UploadImageSlider")]
        public Slider UploadImageSlider()
        {
            try
            {
                var Image = Request.Form.Files[0];
                var ImageName = Guid.NewGuid().ToString() + Image.FileName;
                var fullPath = Path.Combine("C:\\Users\\moham\\Desktop\\Hyper_Market\\src\\assets\\images", ImageName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                Slider HomePage = new Slider();
                HomePage.Image = ImageName;
                return HomePage;
            }
            catch
            {
                return null;
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<Testimonial>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CreateTestimonial")]
        public bool CreateTestimonial(Testimonial testimonial)
        {
            return _adminService.CreateTestimonial(testimonial);
        }
        [HttpPut]
        [ProducesResponseType(typeof(List<Testimonial>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("UpdateTestimonial")]
        public bool UpdateTestimonial(Testimonial testimonial)
        {
            return _adminService.UpdateTestimonial(testimonial);
        }
        [HttpDelete]
        [Route("DeleteTestimonial/{id}")]
        public bool DeleteTestimonial(int id)
        {
            return _adminService.DeleteTestimonial(id);
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<TestimonialDTOAdmin>), StatusCodes.Status200OK)]
        [Route("GetAllTestimonial")]
        public List<TestimonialDTOAdmin> GetAllTestimonial()
        {
            return _adminService.GetAllTestimonial();
        }
        [HttpPost]
        [Route("SearchOfComment")]
        [ProducesResponseType(typeof(List<CommentSearch>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<CommentSearch> SearchOfComment(Testimonial testimonial)
        {
            return _adminService.SearchOfComment(testimonial);
        }
    }
}
