using System;
using System.Collections.Generic;
using System.Text;

namespace GFresh.Core.DTO
{
    public class ProductSearch
    {
        public int ProId { set; get; }
        public string ProName { set; get; }
        public string CatName { set; get; }
        public float ProPrice { set; get; }
        public string ImageName { set; get; }
        public string BarCode { set; get; }

    }
}
