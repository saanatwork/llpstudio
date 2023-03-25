using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace llpstudio.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Details(int productId)
        {            
            var product = "product-descr-"+productId;
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
        
        public ActionResult index() 
        {
            return View();
        }

    }
}