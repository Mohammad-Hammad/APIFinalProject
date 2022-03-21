using GFresh.Core.Data;
using GFresh.Core.DTO;
using GFresh.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

    }
}
