using System;
using System.Collections.Generic;
using System.Text;

namespace GFresh.Core.DTO
{
    public class ContactDTO
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subjct { get; set; }
        public string Msg { get; set; }
    }
}
