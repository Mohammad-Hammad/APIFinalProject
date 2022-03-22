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

        public bool CreateCredit(Credits newCredites)
        {
            return _userRepository.CreateCredit(newCredites);
        }

        public List<Invoice> DisplayInvoice(int customerId)
        {
            return _userRepository.DisplayInvoice(customerId);
        }

        public Task<List<Category>> GetAllCategorsAndProduct()
        {
            return _userRepository.GetAllCategorsAndProduct();
        }

        public List<BillingOrders> PayOrder()
        {
            return _userRepository.PayOrder();
        }

        public string Register(RegisterUser registerUser)
        {
            return _userRepository.Register(registerUser);
        }

        public SearchBarCode SearchBarcode(string barCode)
        {
            return _userRepository.SearchBarcode(barCode);
        }

        public List<ProductSearch> SearchOfProduct(Product product)
        {
            return _userRepository.SearchOfProduct(product);
        }

        public bool UpdateCustomerProfile(Customer customer)
        {
            return _userRepository.UpdateCustomerProfile(customer);

        }

        public ViewProfile ViewCustomerProfile(string cus_id)
        {
            return _userRepository.ViewCustomerProfile(cus_id);
        }
    }
}
