using LLP.BLL.IRepository;
using LLP.BOL.CustomModels;
using LLP.BOL.Master;
using LLP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BLL.Repository
{
    public class MasterRepository : IMasterRepository
    {
        MasterEntity _MasterEntity;
        public MasterRepository()
        {
            _MasterEntity = new MasterEntity();
        }
        public MyEvent GetEvent(int EventID, ref string pMsg)
        {
            return _MasterEntity.GetEvents(EventID, -1, 2, ref pMsg).FirstOrDefault();
        }
        public List<MyEvent4DT> GetEventsForDataTable(int DisplayLength, int DisplayStart, int SortColumn, string SortDirection, string SearchText, ref string pMsg)
        {
            return _MasterEntity.GetEventsForDataTable(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg);
        }
        public List<MyEvent> GetParentEvents(ref string pMsg)
        {
            return _MasterEntity.GetEvents(0,-1,1,ref pMsg);
        }
        public List<MyEvent> GetSubEventsOfaParrent(int ParrentEventID, ref string pMsg)
        {
            return _MasterEntity.GetEvents(0, ParrentEventID, 2, ref pMsg);
        }
        public bool SetEvent(MyEvent data, ref string pMsg)
        {
            data.ImageFile = string.IsNullOrEmpty(data.ImageFile) ? " " : data.ImageFile;
            return _MasterEntity.SetEvent(data, ref pMsg);
        }
        public bool SetEventImage(int EventID, string ImageFile, ref string pMsg)
        {
            return _MasterEntity.SetEventImage(EventID, ImageFile, ref pMsg);
        }
        public List<MyPackages4DT> GetPackagesForDataTable(int DisplayLength, int DisplayStart, int SortColumn, string SortDirection, string SearchText, ref string pMsg)
        {
            return _MasterEntity.GetPackagesForDataTable(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg);
        }
        public List<MyPackages> GetPackages(int PackageID, int EventID, ref string pMsg)
        {
            return _MasterEntity.GetPackages(PackageID, EventID, ref pMsg);
        }
        public bool SetPackage(MyPackages data, ref string pMsg)
        {
            data.PackageIcon = string.IsNullOrEmpty(data.PackageIcon) ? " " : data.PackageIcon;
            return _MasterEntity.SetPackage(data, ref pMsg);
        }
        public bool SetPackageIcon(int PackageID, string ImageFile, ref string pMsg) 
        {
            return _MasterEntity.SetPackageIcon(PackageID, ImageFile, ref pMsg);
        }
        public List<Album4DT> GetAlbumTypeForDataTable(int DisplayLength, int DisplayStart, int SortColumn, string SortDirection, string SearchText, ref string pMsg)
        {
            return _MasterEntity.GetAlbumTypeForDataTable(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg);
        }
        public List<Album> GetAlbumType(int AlbumTypeID, ref string pMsg)
        {
            return _MasterEntity.GetAlbumType(AlbumTypeID, ref pMsg);
        }
        public bool SetAlbumType(Album data, ref string pMsg)
        {
            return _MasterEntity.SetAlbumType(data, ref pMsg);
        }




    }
}
