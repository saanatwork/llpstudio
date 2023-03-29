using LLP.BLL.IRepository;
using LLP.BOL.BookingForm;
using LLP.BOL.CustomModels;
using LLP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BLL.Repository
{
    public class BookingRepository : IBookingRepository
    {
        BookingEntity _BookingEntity;
        public BookingRepository()
        {
            _BookingEntity = new BookingEntity();
        }
        public List<Album> GetAlbumType(int AlbumTypeID, bool IsActive, ref string pMsg)
        {
            return _BookingEntity.GetAlbumType(AlbumTypeID, IsActive, ref pMsg);
        }
        public List<Component> GetComponents(int ComponentID, bool IsActive, ref string pMsg)
        {
            return _BookingEntity.GetComponents(ComponentID, IsActive, ref pMsg);
        }
        public List<CustomComboOptions> GetEventTypes(int ParentEventID, ref string pMsg)
        {
            return _BookingEntity.GetEventTypes(ParentEventID,ref pMsg);
        }
        public List<BookingDtl> GetPackageDetails(int PackageID, int ParentEventID, ref string pMsg)
        {
            List<Component> ComponentList = _BookingEntity.GetComponents(0, true, ref pMsg);
            List<BookingDtl> result = new List<BookingDtl>();
            List<BookingDtlFromDB> bd = _BookingEntity.GetPackageDetails(PackageID, ParentEventID,ref pMsg);
            var newlist = bd.Select(o => new { o.EventDay, o.PhotoGrapherTypeID, o.PhotoGrapherTypeDesc }).Distinct().ToList();
            foreach (var item in newlist)
            {
                List<Component> lc = ComponentList;
                BookingDtl obj1 = new BookingDtl();
                obj1.EventDay = item.EventDay;
                obj1.PhotoGrapherTypeID = item.PhotoGrapherTypeID;
                obj1.PhotoGrapherTypeDesc = item.PhotoGrapherTypeDesc;
                foreach (var Comp in lc) 
                {
                    var sComp = bd.Where(o => o.EventDay == item.EventDay && o.PhotoGrapherTypeID == item.PhotoGrapherTypeID && o.ComponentID == Comp.ID).FirstOrDefault();
                    if (sComp != null) 
                    {
                        Comp.UnitPrice = sComp.CompUnitPrice;
                        Comp.IsInPackage = sComp.CompIsInPackage;
                        Comp.PhotographerTypeComponentLinkID = sComp.PhotographerTypeComponentLinkID;
                    }
                    
                }
                obj1.Components = lc;
                result.Add(obj1);
            }
            return result;
        }
        public bool SetCustomer(Customer customer, ref string pMsg, ref int CostomerID)
        {
            return _BookingEntity.SetCustomer(customer,ref pMsg,ref CostomerID);
        }
    }
}
