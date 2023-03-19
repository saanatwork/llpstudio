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
    public class RegistrationController : Controller
    {
        AccountDataLayer acdl = new AccountDataLayer();
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult Index(UserAccount p)
        {
            try
            {
                p.CustomerId = 0;
                //if (p.Password != p.ConfirmPassword)
                //{
                //    TempData["SignUpError"] = "Password and confirm password not match!!";
                //    return RedirectToAction("SignUp");
                //}
                
                DataSet ds = new DataSet();
                ds = acdl.usp_SetCustomer(p);


                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsSuccess"]))
                {
                    TempData["SignUpSuccess"] = ds.Tables[0].Rows[0]["Msg"].ToString();
                    
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    TempData["SignUpError"] = "Unable to register!!";
                }
            }
            catch (Exception)
            {
                TempData["SignUpError"] = "Oops!! Something went wrong.. Try Again!!";
            }
            return RedirectToAction("Index");
        }
    }
}