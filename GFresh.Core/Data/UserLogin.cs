using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GFresh.Core.Data
{
    public class UserLogin
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string RoleID { get; set; }
        public int? CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        public int? AdminID { get; set; }
        [ForeignKey("AdminID")]
        public virtual Admins Admins { get; set; }
    }
}
