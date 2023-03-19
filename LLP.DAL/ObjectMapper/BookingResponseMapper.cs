using LLP.BOL.BookingForm;
using LLP.BOL.CustomModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.DAL.ObjectMapper
{
    public class BookingResponseMapper
    {
        public CustomComboOptions Map_EventsforCombo(DataRow dr)
        {
            CustomComboOptions result = new CustomComboOptions();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["EventId"]))
                    result.ID = int.Parse(dr["EventId"].ToString());
                if (!DBNull.Value.Equals(dr["EventName"]))
                    result.DisplayText =dr["EventName"].ToString();
            }
            return result;
        }
        public Album Map_Album(DataRow dr) 
        {
            Album result = new Album();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["AlbumTypeId"]))
                    result.ID = int.Parse(dr["AlbumTypeId"].ToString());
                if (!DBNull.Value.Equals(dr["AlbumType"]))
                    result.DisplayText = dr["AlbumType"].ToString();
                if (!DBNull.Value.Equals(dr["IsActive"]))
                    result.IsActive = bool.Parse(dr["IsActive"].ToString());
                if (!DBNull.Value.Equals(dr["UnitPrice"]))
                    result.UnitPrice = int.Parse(dr["UnitPrice"].ToString());
            }
            return result;
        }
        public Component Map_Component(DataRow dr) 
        {
            Component result = new Component();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["ComponentId"]))
                    result.ID = int.Parse(dr["ComponentId"].ToString());
                if (!DBNull.Value.Equals(dr["ComponentName"]))
                    result.DisplayText = dr["ComponentName"].ToString();
                if (!DBNull.Value.Equals(dr["IsActive"]))
                    result.IsActive = bool.Parse(dr["IsActive"].ToString());
            }
            return result;
        }
        public BookingDtlFromDB Map_BookingDtlFromDB(DataRow dr) 
        {
            BookingDtlFromDB result = new BookingDtlFromDB();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["DayNo"]))
                    result.EventDay = int.Parse(dr["DayNo"].ToString());
                if (!DBNull.Value.Equals(dr["PhotographerTypeId"]))
                    result.PhotoGrapherTypeID = int.Parse(dr["PhotographerTypeId"].ToString());
                if (!DBNull.Value.Equals(dr["PhotographerType"]))
                    result.PhotoGrapherTypeDesc = dr["PhotographerType"].ToString();
                if (!DBNull.Value.Equals(dr["PhotographerTypeComponentLinkId"]))
                    result.PhotographerTypeComponentLinkID = int.Parse(dr["PhotographerTypeComponentLinkId"].ToString());
                if (!DBNull.Value.Equals(dr["ComponentId"]))
                    result.ComponentID = int.Parse(dr["ComponentId"].ToString());
                if (!DBNull.Value.Equals(dr["Component"]))
                    result.ComponentDesc = dr["Component"].ToString();
                if (!DBNull.Value.Equals(dr["Price"]))
                    result.CompUnitPrice = int.Parse(dr["Price"].ToString());
                if (!DBNull.Value.Equals(dr["IsIncludedInPackage"]))
                    result.CompIsInPackage = bool.Parse(dr["IsIncludedInPackage"].ToString());
            }
            return result;
        }

    }
}
