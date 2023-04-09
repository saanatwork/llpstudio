using LLP.BOL.Master;
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
    public class MasterEntity
    {
        DataTable dt = null;
        DataSet ds = null;
        MasterDatasync _MasterDatasync;
        DBResponseMapper _DBResponseMapper;
        MasterObjectMapper _MasterObjectMapper;
        public MasterEntity()
        {
            _MasterDatasync = new MasterDatasync();
            _DBResponseMapper = new DBResponseMapper();
            _MasterObjectMapper = new MasterObjectMapper();
        }
        public List<MyEvent4DT> GetEventsForDataTable(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg)
        {
            List<MyEvent4DT> result = new List<MyEvent4DT>();
            try
            {
                dt = _MasterDatasync.GetEventsForDataTable(DisplayLength, DisplayStart,SortColumn,SortDirection,SearchText, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_MasterObjectMapper.Map_MyEvent4DT(dt.Rows[i]));
                    }
                }
            }
            catch (Exception ex) { pMsg = ex.Message; }
            return result;
        }
        public List<MyPackages4DT> GetPackagesForDataTable(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg)
        {
            List<MyPackages4DT> result = new List<MyPackages4DT>();
            try
            {
                dt = _MasterDatasync.GetPackagesForDataTable(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_MasterObjectMapper.Map_MyPackages4DT(dt.Rows[i]));
                    }
                }
            }
            catch (Exception ex) { pMsg = ex.Message; }
            return result;
        }
        public List<Album4DT> GetAlbumTypeForDataTable(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg)
        {
            List<Album4DT> result = new List<Album4DT>();
            try
            {
                dt = _MasterDatasync.GetAlbumTypeForDataTable(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_MasterObjectMapper.Map_Album4DT(dt.Rows[i]));
                    }
                }
            }
            catch (Exception ex) { pMsg = ex.Message; }
            return result;
        }
        public List<MyEvent> GetEvents(int EventID, int ParrentEventID, int TypeID, ref string pMsg)
        {
            //ParrentEventID=1 for all, TypeID= 2 fo all, 1 for only parents.
            List<MyEvent> result = new List<MyEvent>();
            try
            {
                ds = _MasterDatasync.GetEvents(EventID,ParrentEventID,TypeID, ref pMsg);
                if (ds != null)
                {
                    dt = ds.Tables[1];                    
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            result.Add(_MasterObjectMapper.Map_MyEvent(dt.Rows[i]));
                        }
                    }
                }
            }
            catch (Exception ex) { pMsg = ex.Message; }
            return result;
        }
        public bool SetEvent(MyEvent data, ref string pMsg) 
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_MasterDatasync.SetEvent(data, ref pMsg), ref pMsg, ref result);
            return result;
        }
        public bool SetEventImage(int EventID, string ImageFile, ref string pMsg)
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_MasterDatasync.SetEventImage(EventID, ImageFile, ref pMsg), ref pMsg, ref result);
            return result;
        }
        public List<MyPackages> GetPackages(int PackageID, int EventID, ref string pMsg)
        {
            List<MyPackages> result = new List<MyPackages>();
            try
            {
                dt = _MasterDatasync.GetPackages(PackageID, EventID, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_MasterObjectMapper.Map_MyPackages(dt.Rows[i]));
                    }
                }
            }
            catch (Exception ex) { pMsg = ex.Message; }
            return result;
        }
        public bool SetPackage(MyPackages data, ref string pMsg)
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_MasterDatasync.SetPackage(data, ref pMsg), ref pMsg, ref result);
            return result;
        }
        public bool SetPackageIcon(int PackageID, string ImageFile, ref string pMsg) 
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_MasterDatasync.SetPackageIcon(PackageID, ImageFile, ref pMsg), ref pMsg, ref result);
            return result;
        }
        public List<Album> GetAlbumType(int AlbumTypeID, ref string pMsg)
        {
            List<Album> result = new List<Album>();
            try
            {
                dt = _MasterDatasync.GetAlbumType(AlbumTypeID, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_MasterObjectMapper.Map_Album(dt.Rows[i]));
                    }
                }
            }
            catch (Exception ex) { pMsg = ex.Message; }
            return result;
        }
        public bool SetAlbumType(Album data, ref string pMsg)
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_MasterDatasync.SetAlbumType(data, ref pMsg), ref pMsg, ref result);
            return result;
        }







    }
}
