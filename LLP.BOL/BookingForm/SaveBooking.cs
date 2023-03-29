using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BOL.BookingForm
{
    public class SaveBooking
    {
        public int BookingID { get; set; }
        public int CustomerID { get; set; }
        public int EventID { get; set; }
        public string UserRemarks { get; set; }
        public List<SBookingDtl> BookingDtlList { get; set; }
        public List<sAlbum> AlbumList { get; set; }

    }
    public class sAlbum 
    {
        public int AlbumTypeID { get; set; }
        public int NoOfAlbums { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
    }
    public class SBookingDtl 
    {
        public int EventID { get; set; }
        public int PhotographerTypeCompomentLinkId { get; set; }
        public string EventLocation { get; set; }
        public string EventDate { get; set; }
        public int ComponentPrice { get; set; }
    }
}
