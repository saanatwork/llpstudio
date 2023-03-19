using LLP.BOL.BookingForm;
using LLP.BOL.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace llpstudio.ViewModel
{
    public class BookingFormVM
    {
        public List<Album> AlbumList { get; set; }
        public List<CustomComboOptions> EventList { get; set; }
        public List<BookingDtl> PackageDtl { get; set; }
        public List<Component> ComponentList { get; set; }
    }
}