using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using LLP.BOL.CustomModels;

namespace llpstudio.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile()
        {
            FileUploadResponse result = new FileUploadResponse();
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);
                    string extName = _ext.ToString().ToUpper();
                    if (extName == ".PNG" || extName == ".JPG" || extName == ".JPEG")
                    {
                        _imgname = Guid.NewGuid().ToString();
                        var _comPath = Server.MapPath("/assets/img/custom/") + _imgname + _ext;
                        _imgname = _imgname + _ext;
                        ViewBag.Msg = _comPath;
                        var path = _comPath;
                        pic.SaveAs(path);
                        result.ResponseStat = 1;
                        result.ResponseMsg = "File Successfully Uploaded.";
                    }
                    else
                    {
                        result.ResponseMsg = "Only PNG,JPEG & JPG Files Can Be Uploaded.";
                    }
                    // Saving Image in Original Mode

                    //_imagePath=
                    //// resizing image
                    //MemoryStream ms = new MemoryStream();
                    //WebImage img = new WebImage(_comPath);

                    //if (img.Width > 200)
                    //    img.Resize(200, 200);
                    //img.Save(_comPath);
                    //// end resize
                }
            }
            result.FileName = _imgname;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}