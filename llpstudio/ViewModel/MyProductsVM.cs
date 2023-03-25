using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace llpstudio.ViewModel
{
    public class MyProducts
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string Slug
            {
                get
                {
                    return Name.ToLower().Replace(" ", "-");
                }
            }
        }

    }
}