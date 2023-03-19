using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.DAL.ParamMapper
{
    public class BookingParamMapper
    {
        public SqlParameter[] MapParam_usp_GetEvent(int EventID,int ParentEventID,
            int EventType,int PageNumber,int PageSize, ref string pMsg) 
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[5];
            try
            {
                para[paracount] = new SqlParameter("@EventId", SqlDbType.Int);
                para[paracount++].Value = EventID;
                para[paracount] = new SqlParameter("@ParentEventId", SqlDbType.Int);
                para[paracount++].Value = ParentEventID;
                para[paracount] = new SqlParameter("@Type", SqlDbType.Int);
                para[paracount++].Value = EventType;
                para[paracount] = new SqlParameter("@PageNumber", SqlDbType.Int);
                para[paracount++].Value = PageNumber;
                para[paracount] = new SqlParameter("@PageSize", SqlDbType.Int);
                para[paracount++].Value = PageSize;
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
            return para;
        }
        public SqlParameter[] MapParam_usp_GetPackageDetails(int PackageID, 
            int ParentEventID, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[2];
            try
            {
                para[paracount] = new SqlParameter("@PackageId", SqlDbType.Int);
                para[paracount++].Value = PackageID;
                para[paracount] = new SqlParameter("@ParentEventId", SqlDbType.Int);
                para[paracount++].Value = ParentEventID;
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
            return para;
        }


    }
}
