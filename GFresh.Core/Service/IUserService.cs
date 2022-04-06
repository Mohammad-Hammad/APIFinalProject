using GFresh.Core.Data;
using GFresh.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GFresh.Core.Service
{
    public interface IUserService
    {
        public string Register(RegisterUser registerUser);
        public Task<List<Category>> GetAllCategorsAndProduct();
        public List<ProductSearch> SearchOfProduct(Product product);
        public List<ProductSearch> getAllProduct();
        public List<getCart> getCarts(int customer_id);
        public bool AddToCarts(getCart getCart);
        public bool DeletToCarts(getCart getCart);
        public GetTotal GetTotalCustomer(int customer_id);
        public bool UpdateQuantity(Updatecart updatecart);



        public List<BillingOrders> PayOrder();
        List<Invoice> DisplayInvoice(int customerId);
        SearchBarCode SearchBarcode(string barCode);
        bool UpdateCustomerProfile(Customer customer);
        ViewProfile ViewCustomerProfile(string cus_id);
        bool CreateCredit(Credits newCredites);

        CreditAmount GetCreditAmount(int customerId);

        bool updateAmount(Credits credits);

        bool addOrder(Orders order);

        bool addOrderProduct(OrderProduct orderPro);
        List<GetOrder> getOrdId(int Cus_Id);

        public bool DeletCustomerCarts(int Cus_Id);

    }
}
