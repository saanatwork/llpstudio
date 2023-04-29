using LLP.DAL.ParamMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.DAL.DataSync
{
    public class ECommerceDataSync
    {
        ECommerceParamMapper _ECommerceParamMapper;
        public ECommerceDataSync()
        {
            _ECommerceParamMapper = new ECommerceParamMapper();
        }

        public DataTable GetProductCategory(int CategoryID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [ECOM].[GetProductCategory](" + CategoryID + ")", CommandType.Text))
                {
                    return sql.GetDataTable();
                }
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
        }
        public DataTable GetFrameSize(int FrameSizeId, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [ECOM].[GetFrameSize](" + FrameSizeId + ")", CommandType.Text))
                {
                    return sql.GetDataTable();
                }
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
        }
        public DataTable GetProductList(int FrameSizeID, int CategoryID, int PageNumber, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[ECOM].[GetProductList]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_ECommerceParamMapper.MapParam_GetProductList(FrameSizeID,CategoryID,PageNumber,ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
        }
        public DataSet GetProducts(int ProductId, int CategoryID, int PageNumber, int PageSize, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[PDT].[usp_GetProduct]", CommandType.StoredProcedure))
                {
                    return sql.GetDataSet(_ECommerceParamMapper.MapParam_usp_GetProduct(ProductId,CategoryID, PageNumber,PageSize, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
        }



    }
}
