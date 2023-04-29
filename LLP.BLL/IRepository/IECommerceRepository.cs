using LLP.BOL.Ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BLL.IRepository
{
    public interface IECommerceRepository
    {
        List<ProductCategory> GetProductCategory(int CategoryID, ref string pMsg);
        List<FrameSize> GetFrameSize(int FrameSizeId, ref string pMsg);
        List<myProduct4DT> GetProductList(int FrameSizeID, int CategoryID, int PageNumber, ref string pMsg);
        myProduct GetProduct(int ProductID, ref string pMsg);
    }
}
