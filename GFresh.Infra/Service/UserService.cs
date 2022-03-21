using GFresh.Core.Data;
using GFresh.Core.DTO;
using GFresh.Core.Repository;
using GFresh.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GFresh.Infra.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public Task<List<Category>> GetAllCategorsAndProduct()
        {
            return _userRepository.GetAllCategorsAndProduct();
        }

        public string Register(RegisterUser registerUser)
        {
            return _userRepository.Register(registerUser);
        }

        public List<ProductSearch> SearchOfProduct(Product product)
        {
            return _userRepository.SearchOfProduct(product);
        }
    }
}
