using System;
using System.Collections.Generic;
using System.Text;

namespace GFresh.Core.DTO
{
   public class Invoice
    {
        public DateTime OrderAt { get; set; }
        public float TotalPrice { get; set; }
    }
}
