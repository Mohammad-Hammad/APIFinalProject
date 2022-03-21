using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GFresh.Core.Data
{
    public class Customer
    {
        [Key]
        public int CusID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImageName { get; set; }
        public ICollection<UserLogin> UserLogins { get; set; }
        public ICollection<Credits> Credits { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<Carts> Carts { get; set; }
        public ICollection<Testimonial> Testimonials { get; set; }
    }
}
