using GFresh.Core.Data;
using GFresh.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GFresh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginServic;
        public LoginController(ILoginService loginServic)
        {
            this._loginServic = loginServic;
        }
        [HttpPost]
        [Route("SingIn")]
        [ProducesResponseType(typeof(UserLogin), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Authintication([FromBody] UserLogin userLogIn)
        {

            var result = _loginServic.Authintication(userLogIn);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized();

            }
        }
    }

}

