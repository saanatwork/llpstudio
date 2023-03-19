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
    public class LoginController : Controller
    {
        AccountDataLayer acdl = new AccountDataLayer();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserAccount p)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = acdl.usp_CustomerLogin(p);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["LoginStatus"]))
                    {
                        HttpCookie logincookie_llpstudio_User = Request.Cookies["logincookie_llpstudio_User"];
                        logincookie_llpstudio_User = new HttpCookie("logincookie_llpstudio_User");
                        logincookie_llpstudio_User["CustomerID"] = ds.Tables[1].Rows[0]["CustomerID"].ToString();
                        logincookie_llpstudio_User["Mobile"] = ds.Tables[1].Rows[0]["Mobile"].ToString();
                        logincookie_llpstudio_User["WhatsApp"] = ds.Tables[1].Rows[0]["WhatsApp"].ToString();
                        logincookie_llpstudio_User["Email"] = ds.Tables[1].Rows[0]["Email"].ToString();
                        logincookie_llpstudio_User["FirstName"] = ds.Tables[1].Rows[0]["FirstName"].ToString();
                        logincookie_llpstudio_User["LastName"] = ds.Tables[1].Rows[0]["LastName"].ToString();
                        logincookie_llpstudio_User["Password"] =p.Password;
                        logincookie_llpstudio_User.Expires = System.DateTime.Now.AddHours(6);
                        Response.Cookies.Add(logincookie_llpstudio_User);
                        return RedirectToAction("Index", "UserDashboard");
                    }
                    else
                    {
                        TempData["loginerror"] = "Invalid Username or Password";
                        return RedirectToAction("Index", "Login");
                    }
                }
                else
                {
                    TempData["loginerror"] = "Invalid Username or Password";
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception ex)
            {
                TempData["loginerror"] = ex;
            }
            return RedirectToAction("Logout", "Account");
        }

        public ActionResult logout()
        {
            HttpCookie logincookie_llpstudio_User = Request.Cookies["logincookie_llpstudio_User"];
            if (logincookie_llpstudio_User != null)
            {


                logincookie_llpstudio_User.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Add(logincookie_llpstudio_User);
            }
            return RedirectToAction("Index", "Login");
        }
    }
}