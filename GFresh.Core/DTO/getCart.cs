using System;
using System.Collections.Generic;
using System.Text;

namespace GFresh.Core.DTO
{
   public class getCart
    {
        public int customerId { set; get; }
        public int ProId { set; get; }
        public string ProName { set; get; }
        public float ProPrice { set; get; }
        public string ImageName { set; get; }
        public string BarCode { set; get; }
        public int Quantity { get; set; }
    }
}
