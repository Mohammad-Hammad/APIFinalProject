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

        public bool CreateCredit([FromBody] Credits newCredites)
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
                var fullPath = Path.Combine(@"C:\Users\User\Desktop\Hyper_Market\src\assets\images", ImageName);
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

        [HttpGet]
        [Route("getcart/{customer_id}")]
        [ProducesResponseType(typeof(List<getCart>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<getCart> getCarts(int customer_id)
        {
            return _userServic.getCarts(customer_id);
        }

        [HttpPost]
        [Route("addtocart")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool AddToCarts([FromBody] getCart getCart)
        {
            return _userServic.AddToCarts(getCart);
        }

        [HttpPost]
        [Route("deletecart")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool DeletToCarts([FromBody] getCart getCart)
        {
            return _userServic.DeletToCarts(getCart);
        }
        [HttpGet]
        [Route("GetTotalCustomer/{customer_id}")]
        [ProducesResponseType(typeof(GetTotal), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public GetTotal GetTotalCustomer(int customer_id)
        {
            return _userServic.GetTotalCustomer(customer_id);


        }
        [HttpPut]
        [Route("UpdateQuantity")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateQuantity([FromBody] Updatecart updatecart)
        {
            return _userServic.UpdateQuantity( updatecart);
        }

        [HttpGet]
        [Route("CreditAmount/{customerId}")]
        [ProducesResponseType(typeof(List<CreditAmount>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<CreditAmount> GetCreditAmount(int customerId)
        {
            return _userServic.GetCreditAmount(customerId);


        }
        [HttpPut]
        [Route("UpdateAmount")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool updateAmount([FromBody] Credits credits)
        {
            return _userServic.updateAmount(credits);
        }

        [HttpPost]
        [Route("addOrder")]
        [ProducesResponseType(typeof(Orders), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool addOrder([FromBody] Orders order)
        {
            return _userServic.addOrder(order);
        }

        [HttpPost]
        [Route("orderProduct")]
        [ProducesResponseType(typeof(OrderProduct), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool addOrderProduct([FromBody] OrderProduct orderPro)
        {
            return _userServic.addOrderProduct(orderPro);
        }


        [HttpGet]
        [Route("getOrderId/{Cus_Id}")]
        [ProducesResponseType(typeof(List<GetOrder>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<GetOrder> getOrdId(int Cus_Id)
        {
            return _userServic.getOrdId(Cus_Id);
        }


        [HttpDelete]
        [Route("deletecustomercarts/{Cus_Id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool DeletCustomerCarts(int Cus_Id)
        {
            return _userServic.DeletCustomerCarts(Cus_Id);
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<TestimonialDTO>), StatusCodes.Status200OK)]
        [Route("GetAllTestimonial")]
        public List<TestimonialDTO> GetAllTestimonial()
        {
            return _userServic.GetAllTestimonial();
        }
    }
    }
