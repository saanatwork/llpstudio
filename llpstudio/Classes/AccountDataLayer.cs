using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using llpstudio.Models;
using llpstudio.Classes;
using System.Text.RegularExpressions;

namespace llpstudio.Classes
{
    public class AccountDataLayer : DataLayerFunctions
    {
        //-----------------------Check Email Exists--------------------------
        public bool checkExists(string Table, string Column, string Value)
        {
            DataSet ds = Inline_Process("select " + Column + " from " + Table + " where " + Column + "='" + Value + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkUserEmailExists(string email)
        {
            try
            {
                DataSet ds = Inline_Process("select EmailId from  usr.U01_User where EmailId='" + email + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        //-------------End Check Email Exists-------------------

        public DataSet usp_CustomerLogin(UserAccount p)
        {
            try
            {
                string[] paraname = { "@LoginName", "@Password","@Guid" };
                string[] paravalue = { p.Email, p.Password, p.Guid };
                return Ds_Process("[CUS].[usp_CustomerLogin]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataSet usp_SetCustomer(UserAccount p)
        {
            try
            {
                string[] paraname = { "@CustomerId", "@FirstName", "@LastName", "@Email", "@Address","@Mobile","@WhatsApp","@Password" };
                string[] paravalue = { p.CustomerId.ToString(), p.FirstName,p.LastName,p.Email,p.Address,p.Mobile,p.WhatsApp,p.Password };
                return Ds_Process("[BKN].[usp_SetCustomer]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet usp_sendOTP(ForgotPasswordModel p)
        {
            try
            {
                string[] paraname = { "@EmailId", "@OTP" };
                string[] paravalue = { p.EmailId, p.OTP };
                return Ds_Process("[USR].[usp_sendOTP]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet usp_ResetPassword(ForgotPasswordModel p)
        {
            try
            {
                string[] paraname = { "@EmailId", "@OTP", "@NewPassword" };
                string[] paravalue = { p.EmailId, p.OTP,p.Password };
                return Ds_Process("[USR].[usp_ResetPassword]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


       



        public string GenerateItemNameAsParam(string id,string name)
        {
            //string phrase = string.Format("{0}-{1}", id, name);// Creates in the specific pattern  
            string phrase = string.Format("{0}", name);// Creates in the specific pattern  
            string str = GetByteArray(phrase).ToLower();
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");// Remove invalid characters for param  
            str = Regex.Replace(str, @"\s+", "-").Trim(); // convert multiple spaces into one hyphens   
            str = str.Substring(0, str.Length <= 30 ? str.Length : 30).Trim(); //Trim to max 30 char  
            str = Regex.Replace(str, @"\s", "-"); // Replaces spaces with hyphens     
            return str;
        }

        private string GetByteArray(string text)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(text);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

       

        public DataSet usp_getFoodMenuAddOnItems(string foodmenuid,string addonitemid)
        {
            try
            {
                string[] paraname = { "@FoodMenuId", "@AddOnItemId" };
                string[] paravalue = { foodmenuid, addonitemid };
                return Ds_Process("[MTR].[usp_getFoodMenuAddOnItem]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataSet usp_getUser(SignUpModel p)
        {
            try
            {
                string[] paraname = { "@UserId" };
                string[] paravalue = { p.UserId };
                return Ds_Process("[USR].[usp_getUser]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataSet usp_getTotalAmount()
        {
            try
            {
                string[] paraname = { };
                string[] paravalue = {  };
                return Ds_Process("[TRN].[usp_getTotalAmount]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public DataSet usp_setUser(SignUpModel p)
        {
            try
            {
                string[] paraname = { "@UserId", "@UserTypeId", "@MemberShipId", "@FirstName", "@LastName", "@EmailId", "@PhoneNo", "@Address", "@Lat", "@Long", "@PinCode", "@ImageFile", "@Password" };
                string[] paravalue = { p.UserId, p.U01_UserTypeId, p.M10_MemberShipId, p.FirstName, p.LastName, p.EmailId, p.PhoneNo, p.Address, p.Lat, p.Long, p.PinCode, p.ImageFile, p.Password };
                return Ds_Process("[USR].[usp_setUser]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }


        }


        public DataSet usp_setFoodMenuOrderCart(AddToCartModel p)
        {
            try
            {
                string[] paraname = { "@FoodMenuOrderCartId", "@FoodMenuId", "@Quantity", "@AdditionalQuantity", "@DietaryInstructionId", "@UserId", "@Guid" };
                string[] paravalue = { p.FoodMenuOrderCartId, p.FoodMenuId, p.Quantity, p.AdditionalQuantity, p.DietaryInstructionId, p.UserId, p.Guid};
                return Ds_Process("[TRN].[usp_setFoodMenuOrderCart]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet usp_setFoodAddOnItemOrderCart(AddToCartModel p)
        {
            try
            {
                string[] paraname = { "@FoodAddOnItemOrderCartId", "@FoodMenuId", "@Quantity", "@AddOnItemId", "@UserId", "@Guid" };
                string[] paravalue = { p.FoodAddOnItemOrdercartId, p.FoodMenuId, p.Quantity, p.AddOnItemId, p.UserId, p.Guid };
                return Ds_Process("[TRN].[usp_setFoodAddOnItemOrderCart]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet usp_getFoodMenuOrderCart(AddToCartModel p)
        {
            try
            {
                string[] paraname = { "@FoodMenuOrderCartId", "@FoodMenuId", "@UserId", "@Guid" };
                string[] paravalue = { p.FoodMenuOrderCartId, p.FoodMenuId, p.UserId, p.Guid };
                return Ds_Process("[TRN].[usp_getFoodMenuOrderCart]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int usp_deleteFoodMenuOrder_AddOnOrderCart(AddToCartModel p)
        {
            try
            {
                string[] paraname = { "@FoodMenuOrderCartId", "@FoodAddOnItemOrdercartId", "@ItemType", "@GiftCardOrderCartId" };
                string[] paravalue = { p.FoodMenuOrderCartId, p.FoodAddOnItemOrdercartId,p.ItemType,p.GiftCardOrderCartId };
                return ExecuteNonproc("[TRN].[usp_deleteFoodMenuOrder_AddOnOrderCart]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int usp_UpdateFoodMenu_AddOnOrderCart(AddToCartModel p)
        {
            try
            {
                string[] paraname = { "@FoodMenuOrderCartId", "@AddOnItemOrderCartId", "@Quantity", "@AdditionalQty", "@ItemType", "@GiftCardOrderCartId", "@UserId", "@Guid" };
                string[] paravalue = { p.FoodMenuOrderCartId, p.FoodAddOnItemOrdercartId,p.Quantity,p.AdditionalQuantity, p.ItemType,p.GiftCardOrderCartId,p.UserId,p.Guid };
                return ExecuteNonproc("[TRN].[usp_UpdateFoodMenu_AddOnOrderCart]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        

      

        public DataSet usp_GetBookingList(BookingModel p)
        {
            try
            {
                string[] paraname = { "@CustomerId", "@EventId", "@PageNumber", "@PageSize" };
                string[] paravalue = { p.CustomerId.ToString(), p.EventId.ToString(), p.PageNumber.ToString(), p.PageSize.ToString() };
                return Ds_Process("[BKN].[usp_GetBookingList]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet usp_GetBookingDetails(BookingModel p)
        {
            try
            {
                string[] paraname = { "@BookingId" };
                string[] paravalue = { p.BookingId.ToString() };
                return Ds_Process("[BKN].[usp_GetBookingDetails]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet usp_GetCustomer(long custid)
        {
            try
            {
                string[] paraname = { "@CustomerId" };
                string[] paravalue = { custid.ToString() };
                return Ds_Process("[CUS].[usp_GetCustomer]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public DataSet usp_GetEvent(EventModel p)
        {
            try
            {
                string[] paraname = { "@ParentEventId", "@EventId","@Type", "@PageNumber", "@PageSize" };
                string[] paravalue = { p.ParentEventId.ToString(), p.EventId.ToString(),p.Type.ToString(), p.PageNumber.ToString(), p.PageSize.ToString() };
                return Ds_Process("[MTR].[usp_GetEvent]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataSet usp_GetBookingList(EventBookingModel p)
        {
            try
            {
                string[] paraname = { "@CustomerId", "@EventId", "@PageNumber", "@PageSize" };
                string[] paravalue = { p.CustomerId, p.EventId.ToString(), p.PageNumber.ToString(),p.PageSize.ToString() };
                return Ds_Process("[BKN].[usp_GetBookingList]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet usp_GetPackageDetails(PackageModel p)
        {
            try
            {
                string[] paraname = { "@PackageId", "@ParentEventId" };
                string[] paravalue = { p.PackageId.ToString(), p.EventId.ToString() };
                return Ds_Process("[MTR].[usp_GetPackageDetails]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet usp_SetBooking(PackageModel p)
        {
            try
            {
                string[] paraname = { "@BookingId", "@CustomerId","@EventId","@Details", "UDTBookingDetails", "UDTAlbumType" };
                string[] paravalue = { p.BookingId.ToString(), p.CustomerId.ToString(),p.EventId.ToString(),p.Details,p.UDTBookingDetails.ToString(),p.UDTAlbumType.ToString() };
                return Ds_Process("[BKN].[usp_SetBooking]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet usp_SetCustomerAddress(CheckOutCustomerDetails p)
        {
            try
            {
                string[] paraname = { "@CustomerAddressId", "@CustomerId", "@Name", "@Phone", "@Street1", "@Street2", "@City", "@State", "@Pin" };
                string[] paravalue = { p.CustomerAddressId.ToString(), p.CustomerId.ToString(), p.FName+" "+p.LName, p.Phone, p.Street1,p.Street2,p.City,p.State,p.Pin };
                return Ds_Process("[BKN].[usp_SetCustomerAddress]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public DataSet usp_SetCustomer(UserAccount p)
        //{
        //    try
        //    {
        //        string[] paraname = {"@CustomerId", "@FirstName","@LastName", "@Email", "@Address", "@Mobile", "@WhatsApp", "@Password" };
        //        string[] paravalue = {p.CustomerId.ToString(), p.FirstName , p.LastName, p.Email, p.Address, p.Mobile, p.WhatsApp, p.Password };
        //        return Ds_Process("[BKN].[usp_SetCustomer]", paraname, paravalue);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}


        public DataSet usp_GetProductCategory(Product p)
        {
            try
            {
                string[] paraname = {"@ProductCategoryId" };
                string[] paravalue = {p.ProductCategoryId };
                return Ds_Process("select * from [MTR].[udf_getProductCategory](@ProductCategoryId=0)", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet usp_SetProduct(Product p)
        {
            try
            {
                string[] paraname = { "@ProductId", "@ProductName", "@ProductCategoryId", "@ProductDescription", "@IsActive" };
                string[] paravalue = { p.ProductId, p.ProductName, p.ProductCategoryId, p.ProductDescription, p.IsActive };
                return Ds_Process("[PDT].[usp_SetProduct]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataSet usp_getProduct(Product p)
        {
            try
            {
                string[] paraname = { "@DriverId" };
                string[] paravalue = { p.ProductId };
                return Ds_Process("[USR].[usp_getDriver]", paraname, paravalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}



