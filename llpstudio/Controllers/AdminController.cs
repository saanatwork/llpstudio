using LLP.BLL.IRepository;
using LLP.BOL.CustomModels;
using LLP.BOL.Master;
using llpstudio.Classes;
using llpstudio.Models;
using llpstudio.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace llpstudio.Controllers
{
    public class AdminController : Controller
    {
        AccountDataLayer acdl = new AccountDataLayer();
        // GET: Admin
        #region For Master Menu --  By Santosh 
        string pMsg = "";
        IMasterRepository _iMaster;
        public AdminController(IMasterRepository iMaster)
        {
            _iMaster = iMaster;
        }
        public ActionResult Events() 
        {
            List<MyEvent> model = _iMaster.GetParentEvents(ref pMsg);
            return View(model);
        }



        //Ajax Calling
        public JsonResult GetEventList(int iDisplayLength, int iDisplayStart, int iSortCol_0,
            string sSortDir_0, string sSearch)
        {
            List<MyEvent4DT> objlist = _iMaster.GetEventsForDataTable(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch, ref pMsg);
            var result = new
            {
                iTotalRecords = objlist.Count == 0 ? 0 : objlist.FirstOrDefault().TotalRecords,
                iTotalDisplayRecords = objlist.Count == 0 ? 0 : objlist.FirstOrDefault().TotalCount,
                iDisplayLength = iDisplayLength,
                iDisplayStart = iDisplayStart,
                aaData = objlist
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SetEventImage(string ImageFile,int EventID)
        {
            var result = _iMaster.SetEventImage(EventID, ImageFile, ref pMsg);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEventInfo(string EventID)
        {
            var result = _iMaster.GetEvent(int.Parse(EventID), ref pMsg);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SetEvent(EventInfoAjaxRapper modelobj)
        {
            CustomAjaxResponse result = new CustomAjaxResponse();
            if (modelobj != null)
            {
                if (_iMaster.SetEvent(modelobj.DataList.FirstOrDefault(), ref pMsg))
                {
                    result.bResponseBool = true;
                }
                else { result.bResponseBool = false; result.sResponseString = pMsg; }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount p)
        {
            try
            {


                if (p.Email == "Admin" && p.Password == "admin")
                {
                    HttpCookie logincookie_llpstudio_Admin = Request.Cookies["logincookie_llpstudio_Admin"];
                    logincookie_llpstudio_Admin = new HttpCookie("logincookie_llpstudio_Admin");
                    logincookie_llpstudio_Admin["UserId"] = "1001";
                    logincookie_llpstudio_Admin["UserTypeId"] = "Admin";
                    logincookie_llpstudio_Admin["EmailId"] = "Admin@gmail.com";
                    logincookie_llpstudio_Admin["FName"] = "Admin";
                    //logincookie_llpstudio_Admin["LName"] = ds.Tables[1].Rows[0]["LastName"].ToString();
                    //logincookie_VaccineRegistry_Admin["UserType"] = ds.Tables[1].Rows[0]["EmployeeType"].ToString();
                    // if (!string.IsNullOrEmpty(ds.Tables[1].Rows[0]["imagefile"].ToString()))
                    //{
                    //   logincookie_llpstudio_Admin["image"] = "~/DataImages/ProfileImages/" + ds.Tables[1].Rows[0]["imagefile"].ToString();
                    //}
                    // else
                    // {
                    logincookie_llpstudio_Admin["image"] = "~/images/dummy.png";
                    // }
                    logincookie_llpstudio_Admin.Expires = System.DateTime.Now.AddDays(1);
                    Response.Cookies.Add(logincookie_llpstudio_Admin);
                    // TempData["successs"] = Logged In;


                    return RedirectToAction("Index", "Admin");


                }
                else
                {
                    TempData["loginerror"] = "Invalid Username or Password";
                }




            }
            catch (Exception ex)
            {
                TempData["loginerror"] = ex;
            }
            return View();
        }

        public ActionResult LogOut()
        {
            HttpCookie logincookie_llpstudio_Admin = Request.Cookies["logincookie_llpstudio_Admin"];


            if (logincookie_llpstudio_Admin != null)
            {
                logincookie_llpstudio_Admin.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Add(logincookie_llpstudio_Admin);
            }
            return RedirectToAction("login", "admin");
        }

        // [HttpPost]
        public void GetProductCategory()
        {
            try
            {
                Product pp = new Product();
                pp.ProductCategoryId = "0";
                DataSet ds = acdl.usp_GetProductCategory(pp);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    List<SelectListItem> lst = new List<SelectListItem>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        SelectListItem p = new SelectListItem();
                        p.Value = ds.Tables[0].Rows[i]["ProductCategoryId"].ToString();
                        p.Text = ds.Tables[0].Rows[i]["ProductCategory"].ToString();
                        lst.Add(p);
                    }
                    ViewBag.ProductCategory = lst;

                }
                else
                {
                    //TempData["ProductError"] = "Driver Not Saved!!";
                    //return RedirectToAction("AddProduct");
                }
            }
            catch (Exception)
            {
                //TempData["ProductError"] = "Oops!! Something went wrong.. Try Again!!";
                //return RedirectToAction("AddDriver");
            }
            //return View();
        }

        public ActionResult AddProduct()
        {
            GetProductCategory();
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            try
            {
                //GetProductCategory();
                //int i = 0;
                DataSet ds = acdl.usp_SetProduct(p);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    string RegisterStatus = ds.Tables[0].Rows[0]["IsSuccess"].ToString();
                    string Message = ds.Tables[0].Rows[0]["Msg"].ToString();
                    if (RegisterStatus == "True")
                    {
                        TempData["ProductSuccess"] = Message;
                        return RedirectToAction("ProductList");
                    }
                    else
                    {
                        TempData["ProductError"] = Message;
                        return RedirectToAction("AddProduct");
                    }
                }
                else
                {
                    TempData["ProductError"] = "Driver Not Saved!!";
                    return RedirectToAction("AddProduct");
                }
            }
            catch (Exception)
            {
                TempData["ProductError"] = "Oops!! Something went wrong.. Try Again!!";
                return RedirectToAction("AddDriver");
            }
            //return View();
        }


        public ActionResult FoodMenuActiveDeactive(string id, string id1, int id2, int id3)
        {
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(id1))
            {
                string status = "", msg = "";
                if (id1 == "True")
                {
                    status = "0";
                    msg = "Food Menu Deactivated Successfully";
                }
                else if (id1 == "False")
                {
                    status = "1";
                    msg = "Food Menu Activated Successfully";
                }
                int i = 0;
                i = acdl.Inline_ExecuteNonQry("UPDATE [MTR].[M13_FoodMenu] SET IsActive='" + status + "' WHERE FoodMenuId='" + id + "' ");
                if (i > 0)
                {
                    TempData["FoodMenuStatusSuccess"] = msg;
                }
                else
                {
                    TempData["FoodMenuStatusError"] = msg;
                }
            }
            if (id2 != 0 && id3 != 0)
            {

                return RedirectToAction("WeeklyFoodList", "Admin", new { id = id2, id1 = id3 });
            }
            else
            {
                return RedirectToAction("WeeklyFoodList", "Admin");
            }
        }


        //public ActionResult DeliveryChargeList()
        //{
        //    DeliveryChargeModel m = new DeliveryChargeModel();
        //    DataSet ds = acdl.usp_getDeliveryCharge(m);
        //    ViewBag.DeliveryChargeList = ds;
        //    return View();
        //}




        public ActionResult GetBookingList()
        {
            BookingModel p = new BookingModel();
            p.CustomerId = 1;
            p.EventId = 1;
            p.PageNumber = 0;
            p.PageSize = 0;
            DataSet ds = acdl.usp_GetBookingList(p);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ViewBag.GetBookingList = ds;
            }
            return View();
        }

        public ActionResult BookingDetails(long id)
        {
            BookingModel p = new BookingModel();
            BookingModel info = new BookingModel();

            List<BookingModel> Booking = new List<BookingModel>();
            List<BookingModel> mlist = new List<BookingModel>();
            p.BookingId = id;
            DataSet ds = acdl.usp_GetBookingDetails(p);

            //if (ds != null && ds.Tables[1].Rows.Count > 0)
            //{
            //    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            //    {
            //        p = new BookingModel();
            //        p.EntryDateTime = Convert.ToDateTime(ds.Tables[1].Rows[i]["EntryDateTime"].ToString());
            //        p.Event = ds.Tables[1].Rows[i]["Event"].ToString();
            //        p.EventImageFile = ds.Tables[1].Rows[i]["EventImageFile"].ToString();
            //        p.NoOfDays = Convert.ToInt16(ds.Tables[1].Rows[i]["NoOfDays"].ToString());
            //        p.TotalPrice = ds.Tables[1].Rows[i]["TotalPrice"].ToString();

            //        Booking.Add(p);
            //    }
            //    ViewBag.Booking = Booking;
            //}

            //-------section Koushik-----------------

            if (ds != null && ds.Tables[1].Rows.Count > 0)
            {
                info.EntryDateTime = Convert.ToDateTime(ds.Tables[1].Rows[0]["EntryDateTime"].ToString()); ;
                info.Event = ds.Tables[1].Rows[0]["Event"].ToString();
                info.EventImageFile = ds.Tables[1].Rows[0]["EventImageFile"].ToString();
                info.NoOfDays = Convert.ToInt16(ds.Tables[1].Rows[0]["NoOfDays"].ToString());
                info.TotalPrice = ds.Tables[1].Rows[0]["TotalPrice"].ToString();

            }

            ViewBag.Booking = info;
            //-------section Koushik end-----------------

            if (ds != null && ds.Tables[2].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                {
                    p = new BookingModel();
                    p.Event = ds.Tables[2].Rows[i]["Event"].ToString();
                    p.Location = ds.Tables[2].Rows[i]["Location"].ToString();
                    p.Price = ds.Tables[2].Rows[i]["Price"].ToString();
                    p.PhotographerType = ds.Tables[2].Rows[i]["PhotographerType"].ToString();
                    p.Component = ds.Tables[2].Rows[i]["Component"].ToString();
                    p.DateEvt = Convert.ToDateTime(ds.Tables[2].Rows[i]["Date"]).ToString("dd/MM/yyyy");
                    mlist.Add(p);
                }
                ViewBag.BookingList = mlist;
            }
            PackageModel pp = new PackageModel();
            List<PackageModel> pplist = new List<PackageModel>();
            if (ds != null && ds.Tables[3].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                {
                    pp = new PackageModel();
                    pp.AlbumType = ds.Tables[3].Rows[i]["AlbumType"].ToString();
                    pp.AlbumQty = Convert.ToInt16(ds.Tables[3].Rows[i]["NoofAlbum"].ToString());
                    pp.eventPrice = ds.Tables[3].Rows[i]["UnitPrice"].ToString();
                    pp.TotalPrice = Convert.ToDecimal(ds.Tables[3].Rows[i]["TotalPrice"].ToString());

                    pplist.Add(pp);
                }
                ViewBag.AlbumList = pplist;
            }

            //-------section Koushik-----------------

            PackageModel pm = new PackageModel();
            List<PackageModel> pmlist = new List<PackageModel>();
            if (ds != null && ds.Tables[3].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                {
                    pp = new PackageModel();
                    pp.AlbumType = ds.Tables[3].Rows[i]["AlbumType"].ToString();
                    pp.AlbumQty = Convert.ToInt16(ds.Tables[3].Rows[i]["NoofAlbum"].ToString());
                    pp.eventPrice = ds.Tables[3].Rows[i]["UnitPrice"].ToString();
                    pp.TotalPrice = Convert.ToDecimal(ds.Tables[3].Rows[i]["TotalPrice"].ToString());

                    pmlist.Add(pp);
                }
                ViewBag.AlbumList = pmlist;
            }

            UserAccount ua = new UserAccount();
            List<UserAccount> ualist = new List<UserAccount>();
            if (ds != null && ds.Tables[4].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
                {
                    ua = new UserAccount();
                    ua.FirstName = ds.Tables[4].Rows[i]["FirstName"].ToString();
                    ua.LastName = ds.Tables[4].Rows[i]["LastName"].ToString();
                    ua.Email = ds.Tables[4].Rows[i]["Email"].ToString();
                    ua.Mobile = ds.Tables[4].Rows[i]["Mobile"].ToString();
                    ua.WhatsApp = ds.Tables[4].Rows[i]["WhatsApp"].ToString();
                    ua.Address = ds.Tables[4].Rows[i]["Address"].ToString();

                    ualist.Add(ua);
                }
                ViewBag.CustomerList = ualist;
            }

            CheckOutCustomerDetails ct = new CheckOutCustomerDetails();
            List<CheckOutCustomerDetails> CheOut = new List<CheckOutCustomerDetails>();

            if (ds != null && ds.Tables[5].Rows.Count > 0)
            {

                for (int i = 0; i < ds?.Tables[5].Rows.Count; i++)
                {
                    ct = new CheckOutCustomerDetails();
                    ct.FName = ds.Tables[5].Rows[i]["Name"].ToString();
                    ct.Phone = ds.Tables[5].Rows[i]["Phone"].ToString();
                    ct.Street1 = ds.Tables[5].Rows[i]["Street1"].ToString();
                    ct.Street2 = ds.Tables[5].Rows[i]["Street2"].ToString();
                    ct.City = ds.Tables[5].Rows[i]["City"].ToString();
                    ct.State = ds.Tables[5].Rows[i]["State"].ToString();
                    ct.Pin = ds.Tables[5].Rows[i]["Pin"].ToString();

                    CheOut.Add(ct);
                }
                ViewBag.CheOut = CheOut;


            }


            //-------section Koushik end-----------------

            if (ds != null && ds.Tables[1].Rows.Count > 0)
            {
                //p.Event = ds.Tables[1].Rows[0]["Event"].ToString();
                p.NoOfDays = Convert.ToInt32(ds.Tables[1].Rows[0]["Noofdays"].ToString());
                p.TotalPrice = ds.Tables[1].Rows[0]["TotalPrice"].ToString();
            }
            return View(p);
        }

        //[HttpPost]
        //public ActionResult ActiveDeliveryChargeType(ActiveDeliveryType p)
        //{
        //    try
        //    {
        //        int i = 0;
        //        i = acdl.usp_ActivateDeliveryChargeType(p);
        //        if (i > 0)
        //        {
        //            TempData["ActiveDeliveryTypeSuccess"] = "Data updated Successfully!!";
        //            //return RedirectToAction("LiftPositionList");
        //        }
        //        else
        //        {
        //            TempData["ActiveDeliveryTypeerror"] = "Data Not Saved!!";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        TempData["ActiveDeliveryTypeerror"] = "Oops!! Something went wrong.. Try Again!!";
        //    }
        //    //return RedirectToAction("DietaryInstruction");
        //    GetDeliveryChargeTypeId();
        //    ActiveDeliveryType m = new ActiveDeliveryType();
        //    DataSet ds = acdl.usp_getdeliverycharge(m);
        //    ViewBag.ActiveDeliveryChargeType = ds;
        //    return View(m);
        //}

        //public ActionResult AddDriver(string id)
        //{
        //    DriverModel m = new DriverModel();
        //    if (!string.IsNullOrEmpty(id))
        //    {
        //        m.DriverId = id;
        //        DataSet ds = acdl.usp_getDriver(m);
        //        if (ds != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            m.DriverId = ds.Tables[0].Rows[0]["DriverId"].ToString();
        //            //m.DriverIdStr = ds.Tables[0].Rows[0]["DriverIdStr"].ToString();
        //            m.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
        //            m.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
        //            m.EmailId = ds.Tables[0].Rows[0]["EmailId"].ToString();
        //            m.Password = ds.Tables[0].Rows[0]["Password"].ToString();
        //            m.Lat = ds.Tables[0].Rows[0]["Lat"].ToString();
        //            m.Long = ds.Tables[0].Rows[0]["Long"].ToString();
        //            m.PhoneNo = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
        //            m.Address = ds.Tables[0].Rows[0]["Address"].ToString();
        //            ViewBag.PhotoImageList = ds.Tables[0].Rows[0]["PhotoIdImage"].ToString();
        //            m.DrivingLicenseNo = ds.Tables[0].Rows[0]["DrivingLicenseNo"].ToString();
        //            ViewBag.DrivingLicenseImageList = ds.Tables[0].Rows[0]["DrivingLicenseImage"].ToString();
        //            ViewBag.ImageFileList = ds.Tables[0].Rows[0]["ImageFile"].ToString();
        //        }

        //    }
        //    return View(m);
        //}
        //[HttpPost]
        //public ActionResult AddDriver(DriverModel p, string id, HttpPostedFileBase PhotoIdImage, HttpPostedFileBase DrivingLicenseImage, HttpPostedFileBase ImageFile)
        //{
        //    try
        //    {
        //        if (ImageFile != null)
        //        {
        //            p.ImageFile = acdl.NewSaveSingleImages("~/DataImages/GiftCardImages/", ImageFile, "");
        //        }
        //        if (PhotoIdImage != null)
        //        {
        //            p.PhotoIdImage = acdl.NewSaveSingleImages("~/DataImages/GiftCardImages/", PhotoIdImage, "");
        //        }
        //        if (DrivingLicenseImage != null)
        //        {
        //            p.DrivingLicenseImage = acdl.NewSaveSingleImages("~/DataImages/GiftCardImages/", DrivingLicenseImage, "");
        //        }
        //        p.DriverId = id;
        //        int i = 0;
        //        DataSet ds = acdl.usp_setDriver(p);
        //        if (ds != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            string RegisterStatus = ds.Tables[0].Rows[0]["RegisterStatus"].ToString();
        //            string Message = ds.Tables[0].Rows[0]["Message"].ToString();
        //            if (RegisterStatus == "True")
        //            {
        //                TempData["DriverSuccess"] = Message;
        //                return RedirectToAction("DriverList");
        //            }
        //            else
        //            {
        //                TempData["DriverError"] = Message;
        //                return RedirectToAction("AddDriver");
        //            }
        //        }
        //        else
        //        {
        //            TempData["DriverError"] = "Driver Not Saved!!";
        //            return RedirectToAction("AddDriver");
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        TempData["DriverError"] = "Oops!! Something went wrong.. Try Again!!";
        //        return RedirectToAction("AddDriver");
        //    }
        //    //return View();
        //}
        ////public ActionResult DriverList()
        //{
        //    DriverModel m = new DriverModel();
        //    DataSet ds = acdl.usp_getDriver(m);
        //    ViewBag.DriverList = ds;
        //    return View();
        //}
        public ActionResult ChangeStatusDriver(string id, string id1, string id2)
        {
            try
            {
                if (id1 == "True")
                {
                    acdl.Inline_ExecuteNonQry("update [USR].[U06_Driver] set isactive=0 where DriverId='" + id + "'");
                    TempData["DriverSuccess"] = "Deactivated!!";
                }
                else
                {
                    acdl.Inline_ExecuteNonQry("update [USR].[U06_Driver] set isactive=1 where DriverId='" + id + "'");
                    TempData["DriverSuccess"] = "Activated!!";
                }
            }
            catch (Exception)
            {
                TempData["DriverError"] = "Oops!! Something went wrong,Try again after sometimes!!";
            }
            return RedirectToAction("DriverList", "Admin");
        }
        
    }
}