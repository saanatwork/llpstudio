using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace llpstudio.Models
{

    public class AccountModel
    {
    }

    public class ForgotPasswordModel
    {
        public string EmailId { get; set; }
        public string OTP { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }

    }


    public class UserAccount
    {

        public string Email { get; set; }

        public string Password { get; set; }
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string WhatsApp { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Guid { get; set; }

    }




    public class SignUpModel
    {
        public string UserId { get; set; }
        public string U01_UserTypeId { get; set; }
        public string M10_MemberShipId { get; set; }
        public string MemberShipName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string LatLong { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string PinCode { get; set; }
        public string ImageFile { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class AddToCartModel
    {
        public string FoodMenuOrderCartId { get; set; }
        public string FoodMenuId { get; set; }
        public List<string> FoodMenuIds { get; set; }
        public string FoodMenu { get; set; }
        public string AdditionalQuantity { get; set; }
        public string DietaryInstructionId { get; set; }
        public string DietaryInstruction { get; set; }
        public string Quantity { get; set; }
        public string Guid { get; set; }
        public string UserId { get; set; }
        public string Price { get; set; }
        public string SubTotal { get; set; }
        public string WeekDays { get; set; }
        public string WeekDaysNo { get; set; }
        public string FoodAddOnItemOrdercartId { get; set; }
        public string ItemType { get; set; }

        public string AddOnItemId { get; set; }
        public string AddOnItem { get; set; }
        public string UserName { get; set; }
        public string GiftCardOrderCartId { get; set; }

    }

   

    public class BookingModel
    {
        public long BookingId { get; set; }
        public long CustomerId { get; set; }
        public string Contact { get; set; }
        public string Customer { get; set; }
        public DateTime EntryDateTime { get; set; }
        public string DateEvt { get; set; }
        public int EventId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Event { get; set; }
        public string PhotographerType { get; set; }
        public string Component { get; set; }
        public string Price { get; set; }
        public string Location { get; set; }
        public string EventImageFile { get; set; }
        public int NoOfDays { get; set; }
        public string TotalPrice { get; set; }
        public long RowNo { get; set; }

        
    }
    public class CheckOutCustomerDetails
    {
        public long CustomerAddressId { get; set; }
        public long CustomerId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pin { get; set; }
        public string OrderNotes { get; set; }

    }
    public class PackageModel
    {
        //koushik
        public int ParentEventId { get; set; }
        public int Type { get; set; }

        //koushik end


        public short PackageId { get; set; }
        public int EventId { get; set; }
        public long BookingId { get; set; }
        public long CustomerId { get; set; }
        public int ComponentId { get; set; }
        public string Details { get; set; }
        public DataTable UDTBookingDetails { get; set; }
        public DataTable UDTAlbumType { get; set; }
        public string PhotographerTypeId { get; set; }
        public string AlbumType { get; set; }
        public int AlbumTypeId { get; set; }
        public short AlbumQty { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Price { get; set; }


        public List<string> lstPhotographerTypeId { get; set; }

        public string PhotographerTypeCompomentLinkId { get; set; }
        public List<string> lstPhotographerTypeCompomentLinkId { get; set; }
        public string eventPrice { get; set; }
        public List<string> lsteventPrice { get; set; }
        public string EventTypeId { get; set; }
        public List<string> lstEventTypeId { get; set; }
        public List<string> lstLocation { get; set; }
        public string Location { get; set; }
        public int DayNo { get; set; }
        public DateTime eventDate { get; set; }
        public List<DateTime> lsteventDate { get; set; }
        
    }

    //public class PhotographerTypeModel
    //{
    //    public short PackageId { get; set; }
    //    public short EventId { get; set; }
    //    public int ComponentId { get; set; }

    //}

    public class Product
    {
        public string ProductId { get; set; }
        public string ProductCategoryId { get; set; }
        public string ProductCategory { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string IsActive { get; set; }
    }

    public class ChangePasswordModel
    {

        public string oldpswd { get; set; }
        public string newpswd { get; set; }
        public string confirmpswd { get; set; }

    }

    
    public class EventBookingModel
    {
        public string CustomerId { get; set; }
        public int EventId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class EventModel
    {
        public int ParentEventId { get; set; }
        public int EventId { get; set; }
        public short Type { get; set; }
        public string Description { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

}