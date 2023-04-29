using LLP.BOL.Ecommerce;
using LLP.DAL.DataSync;
using LLP.DAL.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.DAL.Entities
{
    public class ECommerceEntity
    {
        DataTable dt = null;
        DataSet ds = null;
        ECommerceDataSync _ECommerceDataSync;
        EcommerceObjectMapper _EcommerceObjectMapper;
        public ECommerceEntity()
        {
            _ECommerceDataSync = new ECommerceDataSync();
            _EcommerceObjectMapper = new EcommerceObjectMapper();
        }
        public List<ProductCategory> GetProductCategory(int CategoryID, ref string pMsg)
        {
            List<ProductCategory> result = new List<ProductCategory>();
            try
            {
                dt = _ECommerceDataSync.GetProductCategory(CategoryID, ref pMsg);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_EcommerceObjectMapper.Map_ProductCategory(dt.Rows[i]));
                    }
                }
            }
            catch (Exception ex) { pMsg = ex.Message; }
            return result;
        }
        public List<FrameSize> GetFrameSize(int FrameSizeId, ref string pMsg) 
        {
            List<FrameSize> result = new List<FrameSize>();
            try
            {
                dt = _ECommerceDataSync.GetFrameSize(FrameSizeId, ref pMsg);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_EcommerceObjectMapper.Map_FrameSize(dt.Rows[i]));
                    }
                }
            }
            catch (Exception ex) { pMsg = ex.Message; }
            return result;
        }
        public List<myProduct4DT> GetProductList(int FrameSizeID, int CategoryID, int PageNumber, ref string pMsg) 
        {
            List<myProduct4DT> result = new List<myProduct4DT>();
            try
            {
                dt = _ECommerceDataSync.GetProductList(FrameSizeID,CategoryID,PageNumber, ref pMsg);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_EcommerceObjectMapper.Map_myProduct4DT(dt.Rows[i]));
                    }
                }
            }
            catch (Exception ex) { pMsg = ex.Message; }
            return result;
        }
        public myProduct GetProduct(int ProductID,ref string pMsg) 
        {
            myProduct result = new myProduct();
            result.ProductID = ProductID;
            ds = _ECommerceDataSync.GetProducts(ProductID, 0,0,0, ref pMsg);
            if (ds != null) 
            {
                dt = ds.Tables[1];
                DataTable pricedt = ds.Tables[2];
                DataTable imagedt = ds.Tables[3];
                DataTable videodt = ds.Tables[4];
                if(dt!=null && dt.Rows.Count > 0) 
                {
                    result.ProductHdr=_EcommerceObjectMapper.Map_MyProductHeader(dt.Rows[0]);
                }
                if (pricedt != null && pricedt.Rows.Count > 0) 
                {
                    result.ProductPrice = new List<MyProductPrice>();
                    for (int i = 0; i < pricedt.Rows.Count; i++) 
                    {
                        result.ProductPrice.Add(_EcommerceObjectMapper.Map_MyProductPrice(pricedt.Rows[i]));
                    }
                }
                if (imagedt != null && imagedt.Rows.Count > 0) 
                {
                    result.ProductImageList = new List<MyProductImage>();
                    for (int i = 0; i < imagedt.Rows.Count; i++)
                    {
                        result.ProductImageList.Add(_EcommerceObjectMapper.Map_MyProductImage(imagedt.Rows[i]));
                    }
                }
                if (videodt != null && videodt.Rows.Count > 0)
                {
                    result.ProductVideo = _EcommerceObjectMapper.Map_MyProductVideo(videodt.Rows[0]);
                }
            }
            return result;
        }





    }
}
