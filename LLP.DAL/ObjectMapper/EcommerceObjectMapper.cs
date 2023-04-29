using LLP.BOL.Ecommerce;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.DAL.ObjectMapper
{
    public class EcommerceObjectMapper
    {
        public ProductCategory Map_ProductCategory(DataRow dr)
        {
            ProductCategory result = new ProductCategory();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["ProductCategoryId"]))
                    result.ID = int.Parse(dr["ProductCategoryId"].ToString());
                if (!DBNull.Value.Equals(dr["ProductCategory"]))
                    result.CategoryText = dr["ProductCategory"].ToString();
                if (!DBNull.Value.Equals(dr["ProductCategoryUrl"]))
                    result.CategoryUrl = dr["ProductCategoryUrl"].ToString();
                if (!DBNull.Value.Equals(dr["IsActive"]))
                    result.IsActive = bool.Parse(dr["IsActive"].ToString());
                
            }
            return result;
        }
        public FrameSize Map_FrameSize(DataRow dr)
        {
            FrameSize result = new FrameSize();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["FrameSizeId"]))
                    result.ID = int.Parse(dr["FrameSizeId"].ToString());
                if (!DBNull.Value.Equals(dr["FrameSize"]))
                    result.Size = dr["FrameSize"].ToString();
                if (!DBNull.Value.Equals(dr["Description"]))
                    result.Description = dr["Description"].ToString();
                if (!DBNull.Value.Equals(dr["IsActive"]))
                    result.IsActive = bool.Parse(dr["IsActive"].ToString());

            }
            return result;
        }
        public myProduct4DT Map_myProduct4DT(DataRow dr)
        {
            myProduct4DT result = new myProduct4DT();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["RowNum"]))
                    result.RowNum = int.Parse(dr["RowNum"].ToString());
                if (!DBNull.Value.Equals(dr["TotalCount"]))
                    result.TotalCount = int.Parse(dr["TotalCount"].ToString());
                if (!DBNull.Value.Equals(dr["TotalRecords"]))
                    result.TotalRecords = int.Parse(dr["TotalRecords"].ToString());

                if (!DBNull.Value.Equals(dr["ProductCategoryID"]))
                    result.ProductCategoryID = int.Parse(dr["ProductCategoryID"].ToString());
                if (!DBNull.Value.Equals(dr["ProductCatDesc"]))
                    result.ProductCatDesc = dr["ProductCatDesc"].ToString();
                if (!DBNull.Value.Equals(dr["FrameSizeID"]))
                    result.FrameSizeID =int.Parse(dr["FrameSizeID"].ToString());
                if (!DBNull.Value.Equals(dr["ProdictID"]))
                    result.ProdictID = int.Parse(dr["ProdictID"].ToString());
                if (!DBNull.Value.Equals(dr["ProductName"]))
                    result.ProductName = dr["ProductName"].ToString();
                if (!DBNull.Value.Equals(dr["ProductImage"]))
                    result.ProductImage = dr["ProductImage"].ToString();
                if (!DBNull.Value.Equals(dr["Price"]))
                    result.Price = double.Parse(dr["Price"].ToString());
                if (!DBNull.Value.Equals(dr["Discount"]))
                    result.Discount =double.Parse(dr["Discount"].ToString());
                result.SalesPrice = Math.Round(result.Price * (100 - result.Discount) / 100);
            }
            return result;
        }
        public MyProductHeader Map_MyProductHeader(DataRow dr)
        {
            MyProductHeader result = new MyProductHeader();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["ProductId"]))
                    result.ProductID = int.Parse(dr["ProductId"].ToString());
                if (!DBNull.Value.Equals(dr["ProductCategoryId"]))
                    result.CategoryID = int.Parse(dr["ProductCategoryId"].ToString());
                if (!DBNull.Value.Equals(dr["ProductCategory"]))
                    result.CategoryName = dr["ProductCategory"].ToString();
                if (!DBNull.Value.Equals(dr["ProductName"]))
                    result.ProductName = dr["ProductName"].ToString();
                if (!DBNull.Value.Equals(dr["ProductDescription"]))
                    result.ProductDesc = dr["ProductDescription"].ToString();
                
            }
            return result;
        }
        public MyProductPrice Map_MyProductPrice(DataRow dr)
        {
            MyProductPrice result = new MyProductPrice();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["ProductId"]))
                    result.ProductID = int.Parse(dr["ProductId"].ToString());
                if (!DBNull.Value.Equals(dr["ProductPriceId"]))
                    result.ProductPriceID = int.Parse(dr["ProductPriceId"].ToString());
                if (!DBNull.Value.Equals(dr["FrameSizeId"]))
                    result.FrameSizeID = int.Parse(dr["FrameSizeId"].ToString());
                if (!DBNull.Value.Equals(dr["FrameSize"]))
                    result.FrameSize = dr["FrameSize"].ToString();
                if (!DBNull.Value.Equals(dr["Description"]))
                    result.Description = dr["Description"].ToString();
                if (!DBNull.Value.Equals(dr["Price"]))
                    result.Price =double.Parse(dr["Price"].ToString());
                if (!DBNull.Value.Equals(dr["Discount"]))
                    result.Discount = double.Parse(dr["Discount"].ToString());
                result.SalesPrice = Math.Round(result.Price * (100 - result.Discount) / 100);
            }
            return result;
        }
        public MyProductImage Map_MyProductImage(DataRow dr)
        {
            MyProductImage result = new MyProductImage();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["ProductId"]))
                    result.ProductID = int.Parse(dr["ProductId"].ToString());
                if (!DBNull.Value.Equals(dr["ProductImageId"]))
                    result.ProductImageID = int.Parse(dr["ProductImageId"].ToString());
                if (!DBNull.Value.Equals(dr["ImageFile"]))
                    result.ImageFile = dr["ImageFile"].ToString();               

            }
            return result;
        }
        public MyProductVideo Map_MyProductVideo(DataRow dr)
        {
            MyProductVideo result = new MyProductVideo();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["ProductId"]))
                    result.ProductID = int.Parse(dr["ProductId"].ToString());
                if (!DBNull.Value.Equals(dr["ProductVideoId"]))
                    result.ProductVideoID = int.Parse(dr["ProductVideoId"].ToString());
                if (!DBNull.Value.Equals(dr["VideoFile"]))
                    result.VideoFile = dr["VideoFile"].ToString();

            }
            return result;
        }


    }
}
