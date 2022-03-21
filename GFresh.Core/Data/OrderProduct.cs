using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GFresh.Core.Data
{
    public class OrderProduct
    {
        [Key]
        public int OrderProductID { get; set; }
        public int? OrderID { get; set; }
        [ForeignKey("OrderID")]
        public virtual Orders Orders { get; set; }
        public int? ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
