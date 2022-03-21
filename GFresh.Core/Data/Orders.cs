using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GFresh.Core.Data
{
    public class Orders
    {
        [Key]
        public int OrdID { get; set; }
        public float TotalPrice { get; set; }
        public DateTime Order_At { get; set; }
        public int? CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
