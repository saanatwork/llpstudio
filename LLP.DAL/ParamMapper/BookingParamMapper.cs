using LLP.BOL.BookingForm;
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
        public SqlParameter[] MapParam_usp_SetCustomer(BOL.BookingForm.Customer customer, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[8];
            try
            {
                para[paracount] = new SqlParameter("@CustomerId", SqlDbType.Int);
                para[paracount++].Value = customer.CustomerID;
                para[paracount] = new SqlParameter("@FirstName", SqlDbType.NVarChar,50);
                para[paracount++].Value = customer.FirstName;
                para[paracount] = new SqlParameter("@LastName", SqlDbType.NVarChar, 50);
                para[paracount++].Value = customer.LastName;
                para[paracount] = new SqlParameter("@Email", SqlDbType.NVarChar);
                para[paracount++].Value = customer.Email;
                para[paracount] = new SqlParameter("@Address", SqlDbType.NVarChar);
                para[paracount++].Value = customer.Address;
                para[paracount] = new SqlParameter("@Mobile", SqlDbType.NVarChar);
                para[paracount++].Value = customer.Mobile;
                para[paracount] = new SqlParameter("@WhatsApp", SqlDbType.NVarChar);
                para[paracount++].Value = customer.WhatsApp;
                para[paracount] = new SqlParameter("@Password", SqlDbType.NVarChar);
                para[paracount++].Value = customer.Password;
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
            return para;
        }
        public SqlParameter[] MapParam_usp_SetBooking(SaveBooking data, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[6];
            try
            {
                CommonTable bd = new CommonTable(data.BookingDtlList);
                CommonTable ad = new CommonTable(data.AlbumList);
                para[paracount] = new SqlParameter("@BookingId", SqlDbType.Int);
                para[paracount++].Value = data.BookingID;
                para[paracount] = new SqlParameter("@CustomerId", SqlDbType.Int);
                para[paracount++].Value = data.CustomerID;
                para[paracount] = new SqlParameter("@EventId", SqlDbType.Int);
                para[paracount++].Value = data.EventID;
                para[paracount] = new SqlParameter("@Details", SqlDbType.NVarChar);
                para[paracount++].Value = data.UserRemarks;
                para[paracount] = new SqlParameter("@UDTBookingDetails", SqlDbType.Structured);
                para[paracount++].Value = bd.UDTable;
                para[paracount] = new SqlParameter("@UDTAlbumType", SqlDbType.Structured);
                para[paracount++].Value = ad.UDTable;
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
            return para;
        }


    }
}
