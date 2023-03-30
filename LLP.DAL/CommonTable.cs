using LLP.BOL.BookingForm;
using LLP.BOL.CustomModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.DAL
{
    public class CommonTable
    {
        public DataTable UDTable { get; set; }
        public CommonTable(List<SBookingDtl> customoptions)
        {
            UDTable = new DataTable();
            UDTable.Columns.Add("CommonId", typeof(Int32));
            UDTable.Columns.Add("CommonValue1", typeof(string));
            UDTable.Columns.Add("CommonValue2", typeof(string));
            UDTable.Columns.Add("CommonValue3", typeof(string));
            UDTable.Columns.Add("CommonValue4", typeof(string));
            UDTable.Columns.Add("CommonValue5", typeof(string));
            UDTable.Columns.Add("CommonValue6", typeof(string));
            UDTable.Columns.Add("CommonValue7", typeof(string));

            if (customoptions != null && customoptions.Count > 0)
            {
                foreach (SBookingDtl obj in customoptions)
                {
                    DataRow dr = UDTable.NewRow();
                    dr["CommonValue1"] = obj.EventID.ToString();
                    dr["CommonValue2"] = obj.PhotographerTypeCompomentLinkId.ToString();
                    dr["CommonValue3"] = obj.EventLocation;
                    dr["CommonValue4"] = obj.EventDate;
                    dr["CommonValue5"] = obj.ComponentPrice.ToString();
                    UDTable.Rows.Add(dr);
                }
            }
        }
        public CommonTable(List<sAlbum> customoptions)
        {
            UDTable = new DataTable();
            UDTable.Columns.Add("CommonId", typeof(Int32));
            UDTable.Columns.Add("CommonValue1", typeof(string));
            UDTable.Columns.Add("CommonValue2", typeof(string));
            UDTable.Columns.Add("CommonValue3", typeof(string));
            UDTable.Columns.Add("CommonValue4", typeof(string));
            UDTable.Columns.Add("CommonValue5", typeof(string));
            UDTable.Columns.Add("CommonValue6", typeof(string));
            UDTable.Columns.Add("CommonValue7", typeof(string));

            if (customoptions != null && customoptions.Count > 0)
            {
                foreach (sAlbum obj in customoptions)
                {
                    DataRow dr = UDTable.NewRow();
                    dr["CommonValue1"] = obj.AlbumTypeID.ToString();
                    dr["CommonValue2"] = obj.NoOfAlbums.ToString();
                    dr["CommonValue3"] = obj.UnitPrice;
                    dr["CommonValue4"] = obj.TotalPrice;                    
                    UDTable.Rows.Add(dr);
                }
            }
        }

    }
}
