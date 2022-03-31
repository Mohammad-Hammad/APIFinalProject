using System;
using System.Collections.Generic;
using System.Text;

namespace GFresh.Core.DTO
{
    public class SerachOrdersDate
    {
        public int OrderID { get; set; }
        public float TotalPrice { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo{ get; set; }
        public DateTime OrderAt { get; set; }
        public int CustomerID { get; set; }
    }
}
