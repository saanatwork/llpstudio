using llpstudio.Classes;
using llpstudio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Windows.Forms;

namespace llpstudio.Controllers
{
    public class UserDashboardController : Controller
    {
        AccountDataLayer acdl = new AccountDataLayer();
        // GET: UserDashboard
        public ActionResult Index()
        {
            return View();
        }


        //[HttpPost]
        //public ActionResult Index(UserAccount p)
        //{
        //    HttpCookie logincookie_llpstudio_User = Request.Cookies["logincookie_llpstudio_User"];
        //    p.CustomerId = Convert.ToInt64(logincookie_llpstudio_User["CustomerID"]);
        //    DataSet dsCust = acdl.usp_SetCustomer(p);
        //    if (dsCust != null && dsCust.Tables[0].Rows.Count > 0)
        //    {
        //        if (Convert.ToBoolean(dsCust.Tables[0].Rows[0]["IsSuccess"]))
        //        {
        //            MessageBox.Show(dsCust.Tables[0].Rows[0]["msg"].ToString());
        //        }
        //        else
        //        {
        //            MessageBox.Show(dsCust.Tables[0].Rows[0]["msg"].ToString());
        //        }
        //    }
        //    return View();
        //}

        public ActionResult ShippingAddress()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult ShippingAddress(CheckOutCustomerDetails p)
        //{
        //    HttpCookie logincookie_llpstudio_User = Request.Cookies["logincookie_llpstudio_User"];
        //    p.CustomerId=Convert.ToInt64(logincookie_llpstudio_User["CustomerID"]);
        //    p.CustomerAddressId = 0;
        //    DataSet dsCustAddress = acdl.usp_SetCustomerAddress(p);
        //    if (dsCustAddress!=null && dsCustAddress.Tables[0].Rows.Count>0)
        //    {
        //        if (Convert.ToBoolean(dsCustAddress.Tables[0].Rows[0]["IsSuccess"]))
        //        {
        //            MessageBox.Show(dsCustAddress.Tables[0].Rows[0]["msg"].ToString());
        //        }
        //        else
        //        {
        //            MessageBox.Show(dsCustAddress.Tables[0].Rows[0]["msg"].ToString());
        //        }
        //    }
        //    return View();
        //}
    }
}