using llpstudio.Classes;
using llpstudio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace llpstudio.Controllers
{
    public class EventBookingController : Controller
    {
        AccountDataLayer acdl = new AccountDataLayer();
        // GET: EventBooking
        public ActionResult Index()
        {
            EventModel m = new EventModel();
            m.ParentEventId = -1;
            m.Type = 1;
            DataSet ds = acdl.usp_GetEvent(m);
            ViewBag.EventList = ds;
            return View();
        }
    }
}