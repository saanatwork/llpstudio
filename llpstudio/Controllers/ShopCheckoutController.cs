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
    public class ShopCheckoutController : Controller
    {
        AccountDataLayer acdl = new AccountDataLayer();
        // GET: ShopCheckout
        public ActionResult Index(int id)
        {
            CheckOutCustomerDetails model = new CheckOutCustomerDetails();
            HttpCookie logincookie_llpstudio_User = Request.Cookies["logincookie_llpstudio_User"];
            if (logincookie_llpstudio_User != null)
            {
                model.CustomerId = Convert.ToInt64(logincookie_llpstudio_User["CustomerID"]);
                DataSet ds = acdl.usp_GetCustomer(model.CustomerId);
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsSuccess"]))
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        model.FName = ds.Tables[1].Rows[0]["FirstName"].ToString();
                        model.LName = ds.Tables[1].Rows[0]["LastName"].ToString();
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        model.Phone = ds.Tables[2].Rows[0]["Phone"].ToString();
                        model.Street1 = ds.Tables[2].Rows[0]["Street1"].ToString();
                        model.Street2 = ds.Tables[2].Rows[0]["Street2"].ToString();
                        model.City = ds.Tables[2].Rows[0]["City"].ToString();
                        model.State = ds.Tables[2].Rows[0]["State"].ToString();
                        model.Pin = ds.Tables[2].Rows[0]["Pin"].ToString();
                    }
                }
            }

            return View(model);
        }

        DataTable dt = new DataTable();
        DataColumn dtcol;
        DataRow dtrow;


        [HttpPost]
        public ActionResult Index(CheckOutCustomerDetails model, int id)
        {
            PackageModel m = new PackageModel();
            List<PackageModel> modelData = Session["AllData"] as List<PackageModel>;

            int len = 0;
            dtcol = new DataColumn();
            dtcol.ColumnName = "CommonId";
            dt.Columns.Add(dtcol);

            dtcol = new DataColumn();
            dtcol.ColumnName = "CommonValue1";
            dt.Columns.Add(dtcol);

            dtcol = new DataColumn();
            dtcol.ColumnName = "CommonValue2";
            dt.Columns.Add(dtcol);

            dtcol = new DataColumn();
            dtcol.ColumnName = "CommonValue3";
            dt.Columns.Add(dtcol);

            dtcol = new DataColumn();
            dtcol.ColumnName = "CommonValue4";
            dt.Columns.Add(dtcol);

            dtcol = new DataColumn();
            dtcol.ColumnName = "CommonValue5";
            dt.Columns.Add(dtcol);

            dtcol = new DataColumn();
            dtcol.ColumnName = "CommonValue6";
            dt.Columns.Add(dtcol);

            dtcol = new DataColumn();
            dtcol.ColumnName = "CommonValue7";
            dt.Columns.Add(dtcol);


            DataTable dtBookingDetails;
            foreach (var item in modelData)
            {
                dtBookingDetails = dtFunction(item);
            }
            DataTable dtAlbum = new DataTable();
            DataColumn dtcolAlbum;
            DataRow dtrowAlbum;

            dtcolAlbum = new DataColumn();
            dtcolAlbum.ColumnName = "CommonId";
            dtAlbum.Columns.Add(dtcolAlbum);

            dtcolAlbum = new DataColumn();
            dtcolAlbum.ColumnName = "CommonValue1";
            dtAlbum.Columns.Add(dtcolAlbum);

            dtcolAlbum = new DataColumn();
            dtcolAlbum.ColumnName = "CommonValue2";
            dtAlbum.Columns.Add(dtcolAlbum);

            dtcolAlbum = new DataColumn();
            dtcolAlbum.ColumnName = "CommonValue3";
            dtAlbum.Columns.Add(dtcolAlbum);

            dtcolAlbum = new DataColumn();
            dtcolAlbum.ColumnName = "CommonValue4";
            dtAlbum.Columns.Add(dtcolAlbum);

            dtcolAlbum = new DataColumn();
            dtcolAlbum.ColumnName = "CommonValue5";
            dtAlbum.Columns.Add(dtcolAlbum);

            dtcolAlbum = new DataColumn();
            dtcolAlbum.ColumnName = "CommonValue6";
            dtAlbum.Columns.Add(dtcolAlbum);

            dtcolAlbum = new DataColumn();
            dtcolAlbum.ColumnName = "CommonValue7";
            dtAlbum.Columns.Add(dtcolAlbum);

            dtrowAlbum = dtAlbum.NewRow();

            dtrowAlbum["CommonId"] = 0;
            dtrowAlbum["CommonValue1"] = modelData[0].AlbumTypeId;
            dtrowAlbum["CommonValue2"] = modelData[0].AlbumQty;
            dtrowAlbum["CommonValue3"] = modelData[0].TotalPrice;
            dtrowAlbum["CommonValue4"] = (modelData[0].AlbumQty * modelData[0].TotalPrice);
            dtrow["CommonValue5"] = "";
            dtrow["CommonValue6"] = "";
            dtrow["CommonValue7"] = "";
            dtAlbum.Rows.Add(dtrowAlbum);

            m.EventId = id;
            UserAccount p = new UserAccount();
            DataSet dsCustAddress = new DataSet();
            HttpCookie logincookie_llpstudio_User = Request.Cookies["logincookie_llpstudio_User"];
            if (logincookie_llpstudio_User != null)
            {
                m.CustomerId = Convert.ToInt64(logincookie_llpstudio_User["CustomerID"]);
                model.CustomerId = m.CustomerId;
            }
            else
            {
                p.CustomerId = 0;
                DataSet ds = new DataSet();
                p.FirstName = model.FName;
                p.LastName = model.LName;
                p.Mobile = model.Phone;
                p.Email = "";
                p.Address = model.Street1 + "," + model.Street2;
                p.Password = "";
                p.WhatsApp = "";
                ds = acdl.usp_SetCustomer(p);
                model.CustomerAddressId = 0;
                model.CustomerId = Convert.ToInt64(ds.Tables[0].Rows[0]["CustomerId"].ToString());
                dsCustAddress = acdl.usp_SetCustomerAddress(model);
            }
            m.Details = model.OrderNotes;
            m.UDTAlbumType = dtAlbum;
            m.UDTBookingDetails = dt;


            //m.CustomerId = model.CustomerId;
            DataSet dsBooking = acdl.usp_SetBooking(m);


            return View();
        }

        public DataTable dtFunction(PackageModel m)
        {
            foreach (var compitem in m.PhotographerTypeCompomentLinkId.Split(','))
            {
                if (compitem != "")
                {
                    dtrow = dt.NewRow();
                    dtrow["CommonId"] = 0;
                    dtrow["CommonValue1"] = m.EventTypeId;
                    dtrow["CommonValue2"] = compitem;
                    dtrow["CommonValue3"] = m.Location;
                    dtrow["CommonValue4"] = m.eventDate.ToString("MM-dd-yyyy");
                
                    foreach (var priceitem in m.eventPrice.Split(','))
                    {
                        //if (priceitem != "")
                        //{
                        dtrow["CommonValue5"] = priceitem;
                        m.eventPrice = m.eventPrice.Replace(priceitem + ",", "");
                        break;
                        //}
                    }

                    dtrow["CommonValue6"] = "";
                    dtrow["CommonValue7"] = "";
                    dt.Rows.Add(dtrow);
                }
            }


            return dt;
        }
    }
}