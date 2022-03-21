using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GFresh.Core.Data
{
    public class Product
    {
        [Key]
        public int ProID { get; set; }
        public string ProName { get; set; }
        public int Sale { get; set; }
        public float ProPrice { get; set; }
        public string ImageName { get; set; }
        public int? CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        public int BarCode { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        public ICollection<Carts> Carts { get; set; }
    }
}
