using LLP.BOL.Ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace llpstudio.ViewModel.ECommerce
{
    public class ProductListVM
    {
        public List<ProductCategory> CategoryList { get; set; }
        public List<FrameSize> FrameList { get; set; }
        public List<myProduct4DT> ProductList { get; set; }
    }
}