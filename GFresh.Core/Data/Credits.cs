using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GFresh.Core.Data
{
    public class Credits
    {
        [Key]
        public int CardID { get; set; }
        public string CardName { get; set; }
        public float Amount { get; set; }
        public int CardNumber { get; set; }
        public int? CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
    }
}
