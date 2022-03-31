using System;
using System.Collections.Generic;
using System.Text;

namespace GFresh.Core.Data
{
    public class HomePage
    {
        public int HomeId { get; set; }
        public string FirstSlider { get; set; }
        public string SecondSlider { get; set; }
        public string ThirdSlider { get; set; }
        public string FirstText { get; set; }
        public string SecondText { get; set; }
        public string CatName { get; set; }
        public string ProdName { get; set; }
        public ICollection<About> Abouts { get; set; }
        public ICollection<Contact> Contacts { get; set; }

    }
}
