using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GFresh.Core.Data
{
    public class Carts
    {
        [Key]
        public int CartID { get; set; }
        public int Quantity { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int? ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
        public int? CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
    }
}
