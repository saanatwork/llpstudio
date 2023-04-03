using LLP.BOL.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.DAL.ObjectMapper
{
    public class MasterObjectMapper
    {
        public MyEvent4DT Map_MyEvent4DT(DataRow dr)
        {
            MyEvent4DT result = new MyEvent4DT();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["EventId"]))
                    result.EventId = int.Parse(dr["EventId"].ToString());
                if (!DBNull.Value.Equals(dr["EventName"]))
                    result.EventName = dr["EventName"].ToString();
                if (!DBNull.Value.Equals(dr["EventNameUrl"]))
                    result.EventNameUrl = dr["EventNameUrl"].ToString();
                if (!DBNull.Value.Equals(dr["M01_EventId"]))
                    result.ParentEventID =int.Parse(dr["M01_EventId"].ToString());
                if (!DBNull.Value.Equals(dr["ImageFile"]))
                    result.ImageFile = dr["ImageFile"].ToString();
                if (!DBNull.Value.Equals(dr["Description"]))
                    result.EventLongText = dr["Description"].ToString();
                if (!DBNull.Value.Equals(dr["IsActive"]))
                    result.IsActive =bool.Parse(dr["IsActive"].ToString());
                if (!DBNull.Value.Equals(dr["RowNum"]))
                    result.RowNum = int.Parse(dr["RowNum"].ToString());
                if (!DBNull.Value.Equals(dr["TotalCount"]))
                    result.TotalCount = int.Parse(dr["TotalCount"].ToString());
                if (!DBNull.Value.Equals(dr["TotalRecords"]))
                    result.TotalRecords = int.Parse(dr["TotalRecords"].ToString());
                if (!DBNull.Value.Equals(dr["ParrentEventName"]))
                    result.ParrentEventName = dr["ParrentEventName"].ToString();
                result.IsActiveStr = result.IsActive ? "Yes" : "No";
            }
            return result;
        }
        public MyEvent Map_MyEvent(DataRow dr) 
        {
            MyEvent4DT result = new MyEvent4DT();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["EventId"]))
                    result.EventId = int.Parse(dr["EventId"].ToString());
                if (!DBNull.Value.Equals(dr["EventName"]))
                    result.EventName = dr["EventName"].ToString();
                if (!DBNull.Value.Equals(dr["EventNameUrl"]))
                    result.EventNameUrl = dr["EventNameUrl"].ToString();
                if (!DBNull.Value.Equals(dr["M01_EventId"]))
                    result.ParentEventID = int.Parse(dr["M01_EventId"].ToString());
                if (!DBNull.Value.Equals(dr["ImageFile"]))
                    result.ImageFile = dr["ImageFile"].ToString();
                if (!DBNull.Value.Equals(dr["Description"]))
                    result.EventLongText = dr["Description"].ToString();
                if (!DBNull.Value.Equals(dr["IsActive"]))
                    result.IsActive = bool.Parse(dr["IsActive"].ToString());
                
            }
            return result;
        }



    }
}
