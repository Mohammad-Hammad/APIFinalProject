using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GFresh.Core.Data
{
    public class Admins
    {
        [Key]
        public int AdminID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public float Salary { get; set; }
        public string Position { get; set; }
        public string ImageName { get; set; }
        public ICollection<UserLogin> UserLogins { get; set; }
    }
}
