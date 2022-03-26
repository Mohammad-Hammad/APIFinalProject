using GFresh.Core.Data;
using GFresh.Core.Repository;
using GFresh.Core.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GFresh.Infra.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepositry;
        private object tokenHandler;

        public LoginService(ILoginRepository loginRepositry)
        {
            this._loginRepositry = loginRepositry;
        }

        public DateTime Expires { get; private set; }
        public SigningCredentials SigningCredentials { get; private set; }

        public string Authintication(UserLogin userLogin)
        {
            var result = _loginRepositry.Authintication(userLogin);
            if (result != null)
            {
                //Valied user
                //Token



                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes("[AboodDagash Assi]");

                string CustomerId = result.CustomerID.ToString();
                string AdminId = result.AdminID.ToString();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, result.UserName),
                    new Claim(ClaimTypes.Role, result.RoleID),
                    new Claim(ClaimTypes.NameIdentifier, CustomerId),
                }),
                  

                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };



                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            else
            {
                //Not Valied user
                return null;
            }

        }
    }
}

