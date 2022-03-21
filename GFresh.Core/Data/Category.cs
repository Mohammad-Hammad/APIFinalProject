using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GFresh.Core.Data
{
    public class Category
    {
        [Key]
        public int? CategoryID { get; set; }
        public string CatName { get; set; }
        public string ImageName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
