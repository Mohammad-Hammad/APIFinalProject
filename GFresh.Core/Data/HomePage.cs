using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GFresh.Core.Data
{
    public class HomePage
    {
        public int HomeId { get; set; }
        public string FirstText { get; set; }
        public string SecondText { get; set; }
        public string CatName { get; set; }
        public string ProdName { get; set; }

    }
}
