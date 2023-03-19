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
    public class EventMembershipController : Controller
    {
        AccountDataLayer acdl = new AccountDataLayer();
        // GET: EventMembership
        public ActionResult Index(string id)
        {
            PackageModel pm = new PackageModel();
            pm.EventId =Convert.ToInt16(id);
            DataSet ds = acdl.Inline_Process("select * from [MTR].[udf_getPackage](0 , 0)");
            ViewBag.PackageList = ds;
            return View(pm);
        }
    }
}