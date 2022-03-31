using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GFresh.Core.Data
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public int? HomeId { get; set; }
        [ForeignKey("ProductID")]
        public virtual HomePage HomePage { get; set; }
    }
}
