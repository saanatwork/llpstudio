using LLP.BOL.BookingForm;
using LLP.BOL.CustomModels;
using LLP.DAL.DataSync;
using LLP.DAL.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.DAL.Entities
{    
    public class BookingEntity
    {
        DataTable dt = null;
        DataSet ds = null;
        bool mRes = false;
        BookingDatasync _BookingDatasync;
        DBResponseMapper _DBResponseMapper;
        BookingResponseMapper _BookingResponseMapper;
        public BookingEntity()
        {
            _BookingDatasync = new BookingDatasync();
            _DBResponseMapper = new DBResponseMapper();
            _BookingResponseMapper = new BookingResponseMapper();
        }
        public List<CustomComboOptions> GetEventTypes(int ParentEventID, ref string pMsg) 
        {            
            List <CustomComboOptions> result= new List<CustomComboOptions>();
            try
            {
                ds = _BookingDatasync.GetEventTypes(ParentEventID, ref pMsg);
                if (ds != null)
                {
                    dt = ds.Tables[1];
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        _DBResponseMapper.Map_DBResponse(ds.Tables[0], ref pMsg, ref mRes);
                    }
                    if (mRes && dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            result.Add(_BookingResponseMapper.Map_EventsforCombo(dt.Rows[i]));
                        }
                    }
                }
            }
            catch (Exception ex) { pMsg = ex.Message; }
            return result;
        }
        public List<Album> GetAlbumType(int AlbumTypeID, bool IsActive, ref string pMsg)
        {
            List<Album> result = new List<Album>();
            try
            {
                dt = _BookingDatasync.GetAlbumType(AlbumTypeID, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_BookingResponseMapper.Map_Album(dt.Rows[i]));
                    }
                }
            }
            catch (Exception ex) { pMsg = ex.Message; }
            if (IsActive && result!=null) { result = result.Where(o => o.IsActive).ToList(); }
            return result;
        }
        public List<Component> GetComponents(int ComponentID, bool IsActive, ref string pMsg) 
        {
            List<Component> result = new List<Component>();
            try
            {
                dt = _BookingDatasync.GetComponents(ComponentID, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_BookingResponseMapper.Map_Component(dt.Rows[i]));
                    }
                }
            }
            catch (Exception ex) { pMsg = ex.Message; }
            if (IsActive && result != null) { result = result.Where(o => o.IsActive).ToList(); }
            return result;
        }
        public List<BookingDtlFromDB> GetPackageDetails(int PackageID, int ParentEventID, ref string pMsg) 
        {
            List<BookingDtlFromDB> result = new List<BookingDtlFromDB>();
            try
            {
                ds = _BookingDatasync.GetPackageDetails(PackageID,ParentEventID, ref pMsg);
                if (ds != null)
                {
                    dt = ds.Tables[1];
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        _DBResponseMapper.Map_DBResponse(ds.Tables[0], ref pMsg, ref mRes);
                    }
                    if (mRes && dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            result.Add(_BookingResponseMapper.Map_BookingDtlFromDB(dt.Rows[i]));
                        }
                    }
                }
            }
            catch (Exception ex) { pMsg = ex.Message; }
            return result;
        }
    }
}
