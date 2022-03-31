using GFresh.Core.Data;
using GFresh.Core.DTO;
using GFresh.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GFresh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServic;
        public UserController(IUserService userServic)
        {
            this._userServic = userServic;
        }
        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string Register(RegisterUser registerUser)
        {
            return _userServic.Register(registerUser);
        }
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<List<Category>> GetAllCategorsAndProduct()
        {
            return _userServic.GetAllCategorsAndProduct();
        }
        [HttpPost]
        [Route("SearchOfProduct")]
        [ProducesResponseType(typeof(List<ProductSearch>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<ProductSearch> SearchOfProduct(Product product)
        {
            return _userServic.SearchOfProduct(product);

        }
        [HttpGet]
        [Route("getAllProduct")]
        [ProducesResponseType(typeof(List<ProductSearch>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<ProductSearch> getAllProduct()
        {
            return _userServic.getAllProduct();
        }




        [HttpGet]
        [Route("pay")]
        [ProducesResponseType(typeof(List<BillingOrders>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<BillingOrders> PayOrder()
        {
            return _userServic.PayOrder();
        }

        [HttpGet]
        [Route("invoice/{customerId}")]
        [ProducesResponseType(typeof(List<Invoice>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<Invoice> DisplayInvoice(int customerId)
        {
            return _userServic.DisplayInvoice(customerId);
        }

        [HttpGet]
        [Route("searchBarCode/{barCode}")]
        [ProducesResponseType(typeof(SearchBarCode), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public SearchBarCode SearchBarcode(string barCode)
        {
            return _userServic.SearchBarcode(barCode);
        }


        [HttpPut]
        [Route("updateCustomer")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateCustomerProfile([FromBody] Customer customer)
        {
            return _userServic.UpdateCustomerProfile(customer);
        }


        [HttpGet]
        [Route("viewCustomer/{cus_id}")]
        [ProducesResponseType(typeof(ViewProfile), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ViewProfile ViewCustomerProfile(string cus_id)
        {

            return _userServic.ViewCustomerProfile(cus_id);
        }

        [HttpPost]
        [Route("newCredite")]
        [ProducesResponseType(typeof(Credits), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public bool CreateCredit([FromBody]Credits newCredites)
        {
            return _userServic.CreateCredit(newCredites);
        }
        [HttpPost]
        [Route("UploadImgCustomer")]
        public Customer UploadImage()
        {
            try
            {
                var Image = Request.Form.Files[0];
                var ImageName = Guid.NewGuid().ToString() + Image.FileName;
                var fullPath = Path.Combine("C:\\Users\\LEGION\\OneDrive - Hashemite University\\Desktop\\Emirates Alliance Training\\HyperMarket\\src\\assets\\images", ImageName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                Customer customer = new Customer();
                customer.ImageName = ImageName;
                return customer;
            }
            catch
            {
                return null;
            }
        }


        [HttpPost]
        [Route("UploadImgHome")]
        public Customer UploadImageHome()
        {
            try
            {
                var Image = Request.Form.Files[0];
                var ImageName = Guid.NewGuid().ToString() + Image.FileName;
                var fullPath = Path.Combine("C:\\Users\\LEGION\\OneDrive - Hashemite University\\Desktop\\Emirates Alliance Training\\HyperMarket\\src\\assets\\images", ImageName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                Customer customer = new Customer();
                customer.ImageName = ImageName;
                return customer;
            }
            catch
            {
                return null;
            }
        }


        [HttpPost]
        [Route("UploadImgAbout")]
        public Customer UploadImageAbout()
        {
            try
            {
                var Image = Request.Form.Files[0];
                var ImageName = Guid.NewGuid().ToString() + Image.FileName;
                var fullPath = Path.Combine("C:\\Users\\LEGION\\OneDrive - Hashemite University\\Desktop\\Emirates Alliance Training\\HyperMarket\\src\\assets\\images", ImageName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                Customer customer = new Customer();
                customer.ImageName = ImageName;
                return customer;
            }
            catch
            {
                return null;
            }
        }
        [HttpPost]
        [Route("Testimonial")]
        [ProducesResponseType(typeof(Testimonial), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateTestimonial(Testimonial testimonial)
        {
            return _userServic.CreateTestimonial(testimonial);
        }
        [HttpDelete]
        [Route("DeleteTestimonial/{id}")]
        public bool DeleteTestimonial(int id)
        {
            return _userServic.DeleteTestimonial(id);
        }
        [HttpPost]
        [Route("Contact")]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateContact(Contact contact)
        {
            return _userServic.CreateContact(contact);
        }
        [HttpPost]
        [Route("About")]
        [ProducesResponseType(typeof(About), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateAbout(About about)
        {
            return _userServic.CreateAbout(about);
        }
        [HttpPost]
        [Route("HomePage")]
        [ProducesResponseType(typeof(HomePage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateHome(HomePage homePage)
        {
            return _userServic.CreateHome(homePage);
        }
        [HttpGet]
        [Route("GetHome")]
        [ProducesResponseType(typeof(List<HomeDTO>), StatusCodes.Status200OK)]
        public List<HomeDTO> GetAllHome()
        {
            return _userServic.GetAllHome();
        }
        [HttpGet]
        [Route("GetAbout")]
        [ProducesResponseType(typeof(List<AboutDTO>), StatusCodes.Status200OK)]
        public List<AboutDTO> GetAllAbout()
        {
            return _userServic.GetAllAbout();
        }
    }
}
