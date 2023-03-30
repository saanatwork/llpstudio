using LLP.BOL.BookingForm;
using LLP.BOL.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BLL.IRepository
{
    public interface IBookingRepository
    {
        List<CustomComboOptions> GetEventTypes(int ParentEventID, ref string pMsg);
        List<Album> GetAlbumType(int AlbumTypeID, bool IsActive, ref string pMsg);
        List<Component> GetComponents(int ComponentID, bool IsActive, ref string pMsg);
        List<BookingDtl> GetPackageDetails(int PackageID, int ParentEventID, ref string pMsg);
        bool SetCustomer(BOL.BookingForm.Customer customer, ref string pMsg, ref int CostomerID);
        bool SetBooking(SaveBooking data, ref string pMsg);

    }
}
