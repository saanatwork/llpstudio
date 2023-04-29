using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BOL.Ecommerce
{
    public class ProductCategory
    {
        public int ID { get; set; }
        public string CategoryText { get; set; }
        public string CategoryUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
