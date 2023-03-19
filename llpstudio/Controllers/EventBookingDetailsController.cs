using LLP.BLL.IRepository;
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
    public class EventBookingDetailsController : Controller
    {
        AccountDataLayer acdl = new AccountDataLayer();
        
        
        // GET: EventBookingForm
        public ActionResult Index(int id,int id1)
        {
            GetEventType();
            GetPhotographerType();
            PackageModel pm = new PackageModel();
            DataSet dsComponent = acdl.Inline_Process("select * from [MTR].[udf_getComponent](0)");
            ViewBag.ComponentList = dsComponent;

            GetAlbumType();

            getPackageDetails(id, id1);

            return View();
        }

        public JsonResult eventBooking(List<PackageModel> modeldata)
        {
            Session["AllData"] = modeldata;
            return Json(modeldata,JsonRequestBehavior.AllowGet);
        }

        public void getPackageDetails(int id,int id1)
        {
            PackageModel pm = new PackageModel();
            pm.PackageId = Convert.ToInt16(id);
            pm.EventId = Convert.ToInt16(id1);
            DataSet ds = acdl.usp_GetPackageDetails(pm);
            ViewBag.PackageList = ds;
        }

        public void GetAlbumType()
        {
            try
            {
                DataSet ds = acdl.Inline_Process("select * from [MTR].[udf_getAlbumType](0)");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    List<SelectListItem> lst = new List<SelectListItem>();
                    SelectListItem p = new SelectListItem();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        p = new SelectListItem();
                        p.Value = ds.Tables[0].Rows[i]["AlbumTypeId"].ToString()+"_"+ ds.Tables[0].Rows[i]["UnitPrice"].ToString();
                        p.Text = ds.Tables[0].Rows[i]["AlbumType"].ToString();
                        lst.Add(p);
                    }
                    ViewBag.AlbumType = lst;

                    //List<SelectListItem> lsts = new List<SelectListItem>();
                    //SelectListItem ps = new SelectListItem();
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    ps = new SelectListItem();
                    //    ps.Value = ds.Tables[0].Rows[i]["UnitPrice"].ToString();
                    //    ps.Text = ds.Tables[0].Rows[i]["UnitPrice"].ToString();
                    //    lsts.Add(ps);
                    //}
                    //ViewBag.AlbumPrice = lsts;
                }
            }
            catch (Exception)
            {
            }
        }

        public void GetPhotographerType()
        {
            try
            {
                //Product pp = new Product();
                DataSet ds = acdl.Inline_Process("SELECT [PhotographerTypeId],[PhotographerType],[Description],[IsActive] FROM [dbllpstudio].[MTR].[M10_PhotographerType]");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    List<SelectListItem> lst = new List<SelectListItem>();
                    SelectListItem p = new SelectListItem();
                  
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        p = new SelectListItem();
                        p.Value = ds.Tables[0].Rows[i]["PhotographerTypeId"].ToString();
                        p.Text = ds.Tables[0].Rows[i]["PhotographerType"].ToString();
                        lst.Add(p);
                    }
                    ViewBag.PhotographerType = lst;

                }
                else
                {
                }
            }
            catch (Exception)
            {
            }
        }




        //public void GetEventType()
        //{
        //    try
        //    {
        //        //Product pp = new Product();
        //        DataSet ds = acdl.Inline_Process("SELECT [EventId],[EventName],[M01_EventId],[ImageFile],[IsActive] FROM [dbllpstudio].[MTR].[M01_Event]");
        //        if (ds != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            List<SelectListItem> lst = new List<SelectListItem>();
        //            SelectListItem p = new SelectListItem();

        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                p = new SelectListItem();
        //                p.Value = ds.Tables[0].Rows[i]["EventId"].ToString();
        //                p.Text = ds.Tables[0].Rows[i]["EventName"].ToString();
        //                lst.Add(p);
        //            }
        //            ViewBag.EventType = lst;

        //        }
        //        else
        //        {
        //            //TempData["ProductError"] = "Driver Not Saved!!";
        //            //return RedirectToAction("AddProduct");
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //TempData["ProductError"] = "Oops!! Something went wrong.. Try Again!!";
        //        //return RedirectToAction("AddDriver");
        //    }
        //    //return View();
        //}


        public void GetEventType()
        {
            try
            {
                //Product pp = new Product();
                //DataSet ds = acdl.Inline_Process("SELECT [EventId],[EventName],[M01_EventId],[ImageFile],[IsActive] FROM [dbllpstudio].[MTR].[M01_Event]");
               

                EventModel em = new EventModel();
                em.ParentEventId = 1;
                em.Type = 2;
                DataSet ds = acdl.usp_GetEvent(em);
                if (ds != null && ds.Tables[1].Rows.Count > 0)
                {
                    List<SelectListItem> lst = new List<SelectListItem>();
                    SelectListItem p = new SelectListItem();

                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        p = new SelectListItem();
                        p.Value = ds.Tables[1].Rows[i]["EventId"].ToString();
                        p.Text = ds.Tables[1].Rows[i]["EventName"].ToString();
                        lst.Add(p);
                    }
                    ViewBag.EventType = lst;

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


    }
}