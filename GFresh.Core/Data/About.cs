using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GFresh.Core.Data
{
    public class About
    {
        public int AboutId { get; set; }
        public string Image { get; set; }
        public string FirstText { get; set; }
        public string SecondText { get; set; }

    }
}
