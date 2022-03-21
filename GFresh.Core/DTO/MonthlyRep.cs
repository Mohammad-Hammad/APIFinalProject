using System;
using System.Collections.Generic;
using System.Text;

namespace GFresh.Core.DTO
{
    public class MonthlyRep
    {
        public int OrderID { get; set; }
        public float TOTALPRICE { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
    }
}
