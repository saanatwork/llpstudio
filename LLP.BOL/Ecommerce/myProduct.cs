using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BOL.Ecommerce
{
    public class MyProductHeader 
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }

    }
    public class MyProductImage 
    {
        public int ProductID { get; set; }
        public int ProductImageID { get; set; }
        public string ImageFile { get; set; }
    }
    public class MyProductVideo
    {
        public int ProductID { get; set; }
        public int ProductVideoID { get; set; }
        public string VideoFile { get; set; }
    }
    public class MyProductPrice 
    {
        public int ProductID { get; set; }
        public int ProductPriceID { get; set; }
        public int FrameSizeID { get; set; }
        public string FrameSize { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double SalesPrice { get; set; }
    }
    public class myProduct
    {
        public int ProductID { get; set; }
        public MyProductHeader ProductHdr { get; set; }
        public List<MyProductPrice> ProductPrice { get; set; }
        public MyProductVideo ProductVideo { get; set; }
        public List<MyProductImage> ProductImageList { get; set; }
    }
    public class myProduct4DT 
    {
        public int ProductCategoryID { get; set; }
        public string ProductCatDesc { get; set; }
        public int FrameSizeID { get; set; }
        public int ProdictID { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double SalesPrice { get; set; }
        public int RowNum { get; set; }
        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
        public double Pages { get; set; }
        public double SelectedPage { get; set; }
    }
}
