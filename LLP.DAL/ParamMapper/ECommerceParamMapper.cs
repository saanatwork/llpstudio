using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.DAL.ParamMapper
{
    public class ECommerceParamMapper
    {
        public SqlParameter[] MapParam_GetProductList(int FrameSizeID,int CategoryID,int PageNumber, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[4];
            try
            {
                para[paracount] = new SqlParameter("@DisplayLength", SqlDbType.Int);
                para[paracount++].Value = 9;
                para[paracount] = new SqlParameter("@DisplayStart", SqlDbType.Int);
                para[paracount++].Value = PageNumber==1?0: (PageNumber-1)*9;
                para[paracount] = new SqlParameter("@FrameSizeID", SqlDbType.Int);
                para[paracount++].Value = FrameSizeID;
                para[paracount] = new SqlParameter("@CategoryID", SqlDbType.Int);
                para[paracount++].Value = CategoryID;
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
            return para;
        }
        public SqlParameter[] MapParam_usp_GetProduct(int ProductId, int CategoryID, int PageNumber,int PageSize, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[4];
            try
            {
                para[paracount] = new SqlParameter("@ProductId", SqlDbType.Int);
                para[paracount++].Value = ProductId;
                para[paracount] = new SqlParameter("@ProductCategoryId", SqlDbType.Int);
                para[paracount++].Value = CategoryID;
                para[paracount] = new SqlParameter("@PageNumber", SqlDbType.Int);
                para[paracount++].Value = PageNumber;
                para[paracount] = new SqlParameter("@PageSize", SqlDbType.Int);
                para[paracount++].Value = PageSize;
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
            return para;
        }
    }
}
