using LLP.BLL.IRepository;
using llpstudio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace llpstudio.Controllers
{
    public class BookEventController : Controller
    {
        IBookingRepository _ibooking;
        string pMsg = "";
        public BookEventController(IBookingRepository ibooking)
        {
            _ibooking = ibooking;
        }       
        // GET: BookEvent
        public ActionResult Index(int id=1, int id1=1)
        {
            BookingFormVM model = new BookingFormVM();
            model.ComponentList = _ibooking.GetComponents(0, true, ref pMsg);
            model.AlbumList = _ibooking.GetAlbumType(0, true, ref pMsg);
            model.EventList = _ibooking.GetEventTypes(id, ref pMsg);
            model.PackageDtl = _ibooking.GetPackageDetails(id1, id, ref pMsg);
            return View(model);
        }
    }
}