using LLP.BLL.IRepository;
using LLP.BOL.BookingForm;
using LLP.BOL.CustomModels;
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
        SaveBooking _SaveBooking;
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
            model.MasterEventID = id1;
            model.MasterPackageID = id;
            model.ComponentList = _ibooking.GetComponents(0, true, ref pMsg);
            model.AlbumList = _ibooking.GetAlbumType(0, true, ref pMsg);
            model.EventList = _ibooking.GetEventTypes(id, ref pMsg);
            model.PackageDtl = _ibooking.GetPackageDetails(id1, id, ref pMsg);
            return View(model);
        }
        public ActionResult CheckOut() 
        {
            _SaveBooking = CastBookingTempData();
            CheckOutVM model = new CheckOutVM();
            model.bookingdtl = _SaveBooking;
            model.customer = new Customer();
            if (_SaveBooking.BookingDtlList != null && _SaveBooking.BookingDtlList.Count>0) 
            {
                model.EventTotal = _SaveBooking.BookingDtlList.Sum(o => o.ComponentPrice);
                model.EventCount = _SaveBooking.BookingDtlList.Select(o => o.EventDate).Distinct().Count();
            }
            if (_SaveBooking.AlbumList != null && _SaveBooking.AlbumList.Count > 0) 
            {
                model.AlbumTotal = _SaveBooking.AlbumList.Sum(o => o.TotalPrice);
                model.AlbumCount = _SaveBooking.AlbumList.Sum(o => o.NoOfAlbums);
            }
            model.Subtotal = model.EventTotal + model.AlbumTotal;
            model.OrderTotal = model.Subtotal;
            return View(model);
        }
        [HttpPost]
        public ActionResult CheckOut(CheckOutVM model) 
        {
            int customerid = 0;
            _SaveBooking = CastBookingTempData();
            _SaveBooking.UserRemarks = model.UserRemarks;
            if (model.customer.CustomerID > 0)
                customerid = model.customer.CustomerID;
            else
                _ibooking.SetCustomer(model.customer, ref pMsg, ref customerid);
            _SaveBooking.CustomerID = customerid;
            //SetBooking Code Here

            return View(model);
        }



        [HttpPost]
        public ActionResult SaveEventDetails(SaveBooking modelobj)
        {
            CustomAjaxResponse result = new CustomAjaxResponse();
            if (modelobj != null)
            {
                TempData["SB"] = modelobj;
                result.bResponseBool = true;
            }
            else {
                result.bResponseBool = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        private SaveBooking CastBookingTempData()
        {
            if (TempData["SB"] != null)
            {
                _SaveBooking = TempData["SB"] as SaveBooking;
            }
            else
            {
                _SaveBooking = new SaveBooking();
            }
            
            return _SaveBooking;
        }
    }
}