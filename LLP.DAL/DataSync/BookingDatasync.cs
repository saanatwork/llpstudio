using LLP.BOL.BookingForm;
using LLP.DAL.ParamMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.DAL.DataSync
{
    public class BookingDatasync
    {
        BookingParamMapper _paramMapper;
        public BookingDatasync()
        {
            _paramMapper = new BookingParamMapper();
        }
        public DataSet GetEventTypes(int ParentEventID, ref string pMsg)
        {
            try
            {   
                using (SQLHelper sql = new SQLHelper("[MTR].[usp_GetEvent]", CommandType.StoredProcedure))
                {
                    return sql.GetDataSet(_paramMapper.MapParam_usp_GetEvent(0, ParentEventID,2,0,0, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
        }
        public DataTable GetAlbumType(int AlbumTypeID, ref string pMsg) 
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [MTR].[udf_getAlbumType]("+ AlbumTypeID + ")", CommandType.Text))
                {
                    return sql.GetDataTable();
                }
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
        }
        public DataTable GetComponents(int ComponentID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [MTR].[udf_getComponent](" + ComponentID + ")", CommandType.Text))
                {
                    return sql.GetDataTable();
                }
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
        }
        public DataSet GetPackageDetails(int PackageID,int ParentEventID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[MTR].[usp_GetPackageDetails]", CommandType.StoredProcedure))
                {
                    return sql.GetDataSet(_paramMapper.MapParam_usp_GetPackageDetails(PackageID, ParentEventID, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
        }
        public DataTable SetCustomer(BOL.BookingForm.Customer customer, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[BKN].[usp_SetCustomer]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_paramMapper.MapParam_usp_SetCustomer(customer, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
        }
        public DataTable SetBooking(SaveBooking data, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[BKN].[usp_SetBooking]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_paramMapper.MapParam_usp_SetBooking(data, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
        }





        //public DateTime GetEffectedRuleID(int RuleType, ref string pMsg)
        //{
        //    try
        //    {
        //        using (SQLHelper sql = new SQLHelper("SELECT [CTV].[GetEffectiveRuleID](" + RuleType + ")", CommandType.Text))
        //        {
        //            return DateTime.Parse(sql.ExecuteScaler(ref pMsg).ToString());
        //        }
        //    }
        //    catch (Exception ex) { pMsg = ex.Message; return DateTime.Today; }
        //}
        //public DataTable SetDateWiseTourDetails(string NoteNumber, List<DateWiseTourDetails> dtldata, ref string pMsg)
        //{
        //    try
        //    {
        //        CommonTable dtl = new CommonTable(dtldata);
        //        int paracount = 0;
        //        SqlParameter[] para = new SqlParameter[2];
        //        para[paracount] = new SqlParameter("@NoteNumber", SqlDbType.NChar, 25);
        //        para[paracount++].Value = NoteNumber;
        //        para[paracount] = new SqlParameter("@DateWiseTourDtl", SqlDbType.Structured);
        //        para[paracount++].Value = dtl.UDTable;
        //        using (SQLHelper sql = new SQLHelper("[EHG].[SetDateWiseTourDetails]", CommandType.StoredProcedure))
        //        {
        //            return sql.GetDataTable(para, ref pMsg);
        //        }
        //    }
        //    catch (Exception ex) { pMsg = ex.Message; return null; }
        //}



    }
}
