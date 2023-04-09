using LLP.BOL.CustomModels;
using LLP.BOL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BLL.IRepository
{
    public interface IMasterRepository
    {
        List<MyEvent4DT> GetEventsForDataTable(int DisplayLength, int DisplayStart, int SortColumn,
             string SortDirection, string SearchText, ref string pMsg);
        List<MyPackages4DT> GetPackagesForDataTable(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg);
        List<Album4DT> GetAlbumTypeForDataTable(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg);
        List<MyEvent> GetParentEvents(ref string pMsg);
        List<MyEvent> GetSubEventsOfaParrent(int ParrentEventID, ref string pMsg);
        MyEvent GetEvent(int EventID,ref string pMsg);
        bool SetEvent(MyEvent data, ref string pMsg);
        bool SetEventImage(int EventID, string ImageFile, ref string pMsg);
        List<MyPackages> GetPackages(int PackageID, int EventID, ref string pMsg);
        bool SetPackage(MyPackages data, ref string pMsg);
        bool SetPackageIcon(int PackageID, string ImageFile, ref string pMsg);
        List<Album> GetAlbumType(int AlbumTypeID, ref string pMsg);
        bool SetAlbumType(Album data, ref string pMsg);

    }
}
