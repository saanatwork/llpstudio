using LLP.BLL.IRepository;
using LLP.BOL.Ecommerce;
using LLP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BLL.Repository
{
    public class ECommerceRepository : IECommerceRepository
    {
        ECommerceEntity _ECommerceEntity;
        public ECommerceRepository()
        {
            _ECommerceEntity = new ECommerceEntity();
        }
        public List<ProductCategory> GetProductCategory(int CategoryID, ref string pMsg)
        {
            return _ECommerceEntity.GetProductCategory(CategoryID, ref pMsg);
        }
        public List<FrameSize> GetFrameSize(int FrameSizeId, ref string pMsg) 
        {
            return _ECommerceEntity.GetFrameSize(FrameSizeId, ref pMsg);
        }
        public List<myProduct4DT> GetProductList(int FrameSizeID, int CategoryID, int PageNumber, ref string pMsg) 
        {
            return _ECommerceEntity.GetProductList(FrameSizeID, CategoryID, PageNumber, ref pMsg);
        }
        public myProduct GetProduct(int ProductID, ref string pMsg) 
        {
            return _ECommerceEntity.GetProduct(ProductID, ref pMsg);
        }


    }
}
