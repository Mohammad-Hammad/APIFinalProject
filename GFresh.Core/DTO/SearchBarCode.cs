using System;
using System.Collections.Generic;
using System.Text;

namespace GFresh.Core.DTO
{
    public class SearchBarCode
    {
        public string productname { get; set; }

        public float ProPrice { get; set; }
        public string ImageName { get; set; }
        public int BarCode { get; set; }
    }
}
