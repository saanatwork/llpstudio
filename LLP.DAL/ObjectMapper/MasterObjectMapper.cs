using LLP.BOL.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.DAL.ObjectMapper
{
    public class MasterObjectMapper
    {
        public MyEvent4DT Map_MyEvent4DT(DataRow dr)
        {
            MyEvent4DT result = new MyEvent4DT();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["EventId"]))
                    result.EventId = int.Parse(dr["EventId"].ToString());
                if (!DBNull.Value.Equals(dr["EventName"]))
                    result.EventName = dr["EventName"].ToString();
                if (!DBNull.Value.Equals(dr["EventNameUrl"]))
                    result.EventNameUrl = dr["EventNameUrl"].ToString();
                if (!DBNull.Value.Equals(dr["M01_EventId"]))
                    result.ParentEventID =int.Parse(dr["M01_EventId"].ToString());
                if (!DBNull.Value.Equals(dr["ImageFile"]))
                    result.ImageFile = dr["ImageFile"].ToString();
                if (!DBNull.Value.Equals(dr["Description"]))
                    result.EventLongText = dr["Description"].ToString();
                if (!DBNull.Value.Equals(dr["IsActive"]))
                    result.IsActive =bool.Parse(dr["IsActive"].ToString());
                if (!DBNull.Value.Equals(dr["RowNum"]))
                    result.RowNum = int.Parse(dr["RowNum"].ToString());
                if (!DBNull.Value.Equals(dr["TotalCount"]))
                    result.TotalCount = int.Parse(dr["TotalCount"].ToString());
                if (!DBNull.Value.Equals(dr["TotalRecords"]))
                    result.TotalRecords = int.Parse(dr["TotalRecords"].ToString());
                if (!DBNull.Value.Equals(dr["ParrentEventName"]))
                    result.ParrentEventName = dr["ParrentEventName"].ToString();
                result.IsActiveStr = result.IsActive ? "Yes" : "No";
            }
            return result;
        }
        public MyEvent Map_MyEvent(DataRow dr) 
        {
            MyEvent4DT result = new MyEvent4DT();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["EventId"]))
                    result.EventId = int.Parse(dr["EventId"].ToString());
                if (!DBNull.Value.Equals(dr["EventName"]))
                    result.EventName = dr["EventName"].ToString();
                if (!DBNull.Value.Equals(dr["EventNameUrl"]))
                    result.EventNameUrl = dr["EventNameUrl"].ToString();
                if (!DBNull.Value.Equals(dr["M01_EventId"]))
                    result.ParentEventID = int.Parse(dr["M01_EventId"].ToString());
                if (!DBNull.Value.Equals(dr["ImageFile"]))
                    result.ImageFile = dr["ImageFile"].ToString();
                if (!DBNull.Value.Equals(dr["Description"]))
                    result.EventLongText = dr["Description"].ToString();
                if (!DBNull.Value.Equals(dr["IsActive"]))
                    result.IsActive = bool.Parse(dr["IsActive"].ToString());
                
            }
            return result;
        }
        public MyPackages4DT Map_MyPackages4DT(DataRow dr)
        {
            MyPackages4DT result = new MyPackages4DT();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["PackageId"]))
                    result.PackageId = int.Parse(dr["PackageId"].ToString());
                if (!DBNull.Value.Equals(dr["PackageName"]))
                    result.PackageName = dr["PackageName"].ToString();
                if (!DBNull.Value.Equals(dr["PackageNameUrl"]))
                    result.PackageNameUrl = dr["PackageNameUrl"].ToString();
                if (!DBNull.Value.Equals(dr["PackageIcon"]))
                    result.PackageIcon = dr["PackageIcon"].ToString();
                if (!DBNull.Value.Equals(dr["M01_EventId"]))
                    result.EventId =int.Parse(dr["M01_EventId"].ToString());
                if (!DBNull.Value.Equals(dr["EventName"]))
                    result.EventName = dr["EventName"].ToString();                
                if (!DBNull.Value.Equals(dr["RowNum"]))
                    result.RowNum = int.Parse(dr["RowNum"].ToString());
                if (!DBNull.Value.Equals(dr["TotalCount"]))
                    result.TotalCount = int.Parse(dr["TotalCount"].ToString());
                if (!DBNull.Value.Equals(dr["TotalRecords"]))
                    result.TotalRecords = int.Parse(dr["TotalRecords"].ToString());                
            }
            return result;
        }
        public MyPackages Map_MyPackages(DataRow dr)
        {
            MyPackages result = new MyPackages();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["PackageId"]))
                    result.PackageId = int.Parse(dr["PackageId"].ToString());
                if (!DBNull.Value.Equals(dr["PackageName"]))
                    result.PackageName = dr["PackageName"].ToString();
                if (!DBNull.Value.Equals(dr["PackageNameUrl"]))
                    result.PackageNameUrl = dr["PackageNameUrl"].ToString();
                if (!DBNull.Value.Equals(dr["PackageIcon"]))
                    result.PackageIcon = dr["PackageIcon"].ToString();
                if (!DBNull.Value.Equals(dr["M01_EventId"]))
                    result.EventId = int.Parse(dr["M01_EventId"].ToString());
            }
            return result;
        }
        public Album4DT Map_Album4DT(DataRow dr)
        {
            Album4DT result = new Album4DT();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["AlbumTypeId"]))
                    result.AlbumTypeId = int.Parse(dr["AlbumTypeId"].ToString());
                if (!DBNull.Value.Equals(dr["AlbumType"]))
                    result.AlbumType = dr["AlbumType"].ToString();
                if (!DBNull.Value.Equals(dr["Description"]))
                    result.Description = dr["Description"].ToString();
                if (!DBNull.Value.Equals(dr["IsActive"]))
                    result.IsActive =bool.Parse(dr["IsActive"].ToString());
                if (!DBNull.Value.Equals(dr["UnitPrice"]))
                    result.UnitPrice = double.Parse(dr["UnitPrice"].ToString());                
                if (!DBNull.Value.Equals(dr["RowNum"]))
                    result.RowNum = int.Parse(dr["RowNum"].ToString());
                if (!DBNull.Value.Equals(dr["TotalCount"]))
                    result.TotalCount = int.Parse(dr["TotalCount"].ToString());
                if (!DBNull.Value.Equals(dr["TotalRecords"]))
                    result.TotalRecords = int.Parse(dr["TotalRecords"].ToString());
                result.IsActiveStr = result.IsActive ? "Yes" : "No";
            }
            return result;
        }
        public Album Map_Album(DataRow dr)
        {
            Album result = new Album();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["AlbumTypeId"]))
                    result.AlbumTypeId = int.Parse(dr["AlbumTypeId"].ToString());
                if (!DBNull.Value.Equals(dr["AlbumType"]))
                    result.AlbumType = dr["AlbumType"].ToString();
                if (!DBNull.Value.Equals(dr["Description"]))
                    result.Description = dr["Description"].ToString();
                if (!DBNull.Value.Equals(dr["IsActive"]))
                    result.IsActive = bool.Parse(dr["IsActive"].ToString());
                if (!DBNull.Value.Equals(dr["UnitPrice"]))
                    result.UnitPrice = double.Parse(dr["UnitPrice"].ToString());
                
            }
            return result;
        }



    }
}
