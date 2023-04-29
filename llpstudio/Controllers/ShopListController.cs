using LLP.BLL.IRepository;
using llpstudio.ViewModel.ECommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace llpstudio.Controllers
{
    public class ShopListController : Controller
    {
        IECommerceRepository _iEcommerce;
        string pMsg = "";
        public ShopListController(IECommerceRepository iEcom)
        {
            _iEcommerce = iEcom;
        }
        // GET: ShopList
        public ActionResult Index()
        {
            ProductListVM model = new ProductListVM();
            model.CategoryList = _iEcommerce.GetProductCategory(0, ref pMsg);
            model.FrameList = _iEcommerce.GetFrameSize(0, ref pMsg);
            model.ProductList = _iEcommerce.GetProductList(0, 0, 1, ref pMsg);
            return View(model);
        }
    }
}