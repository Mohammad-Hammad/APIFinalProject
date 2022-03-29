using System;
using System.Collections.Generic;
using System.Text;

namespace GFresh.Core.DTO
{
    public class getAllAdmins
    {
        public int AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Image { get; set; }
    }
}
