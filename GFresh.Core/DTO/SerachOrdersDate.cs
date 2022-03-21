using System;
using System.Collections.Generic;
using System.Text;

namespace GFresh.Core.DTO
{
    public class SerachOrdersDate
    {
        public int OrderID { get; set; }
        public float TotalPrice { get; set; }
        public DateTime OrderAT { get; set; }
        public int CustomerID { get; set; }
    }
}
