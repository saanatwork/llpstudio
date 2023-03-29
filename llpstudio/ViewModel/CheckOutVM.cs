using LLP.BOL.BookingForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace llpstudio.ViewModel
{
    public class CheckOutVM
    {
        public Customer customer { get; set; }
        public SaveBooking bookingdtl { get; set; }
        public int Subtotal { get; set; }
        public int OrderTotal { get; set; }
        public int EventTotal { get; set; }
        public int AlbumTotal { get; set; }
        public int EventCount { get; set; }
        public int AlbumCount { get; set; }
        public string UserRemarks { get; set; }
    }
}