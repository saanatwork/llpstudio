using LLP.BOL.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.DAL.ParamMapper
{
    public class MasterParamMapper
    {
        public SqlParameter[] MapParam_GetEvent(int EventID,int ParentID,int TypeID,ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[5];
            try
            {
                para[paracount] = new SqlParameter("@EventId", SqlDbType.Int);
                para[paracount++].Value = EventID;
                para[paracount] = new SqlParameter("@ParentEventId", SqlDbType.Int);
                para[paracount++].Value = ParentID;
                para[paracount] = new SqlParameter("@Type", SqlDbType.Int);
                para[paracount++].Value = TypeID;
                para[paracount] = new SqlParameter("@PageNumber", SqlDbType.Int);
                para[paracount++].Value = 0;
                para[paracount] = new SqlParameter("@PageSize", SqlDbType.Int);
                para[paracount++].Value = 0;
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_SetEvent(MyEvent data, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[5];
            try
            {
                para[paracount] = new SqlParameter("@EventId", SqlDbType.Int);
                para[paracount++].Value = data.EventId;
                para[paracount] = new SqlParameter("@EventName", SqlDbType.NVarChar,200);
                para[paracount++].Value = data.EventName;
                para[paracount] = new SqlParameter("@ParentEventId", SqlDbType.Int);
                para[paracount++].Value = data.ParentEventID;
                para[paracount] = new SqlParameter("@ImageFile", SqlDbType.NVarChar,50);
                para[paracount++].Value = data.ImageFile;
                para[paracount] = new SqlParameter("@IsActive", SqlDbType.Bit);
                para[paracount++].Value = data.IsActive;
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_SetEventImage(int EventID,string ImageFile,ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[2];
            try
            {
                para[paracount] = new SqlParameter("@EventId", SqlDbType.Int);
                para[paracount++].Value = EventID;                
                para[paracount] = new SqlParameter("@ImageFile", SqlDbType.NVarChar, 50);
                para[paracount++].Value = ImageFile;
                
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_SetPackage(MyPackages data, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[4];
            try
            {
                para[paracount] = new SqlParameter("@PackageId", SqlDbType.Int);
                para[paracount++].Value = data.PackageId;
                para[paracount] = new SqlParameter("@PackageName", SqlDbType.NVarChar, 50);
                para[paracount++].Value = data.PackageName;
                para[paracount] = new SqlParameter("@PackageIcon", SqlDbType.NVarChar, 50);
                para[paracount++].Value = data.PackageIcon;
                para[paracount] = new SqlParameter("@EventId", SqlDbType.Int);
                para[paracount++].Value = data.EventId;                
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_SetPackageIcon(int PackageID, string ImageFile, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[2];
            try
            {
                para[paracount] = new SqlParameter("@PackageId", SqlDbType.Int);
                para[paracount++].Value = PackageID;
                para[paracount] = new SqlParameter("@ImageFile", SqlDbType.NVarChar, 50);
                para[paracount++].Value = ImageFile;

            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_SetAlbumType(Album data, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[5];
            try
            {
                para[paracount] = new SqlParameter("@AlbumTypeId", SqlDbType.Int);
                para[paracount++].Value = data.AlbumTypeId;
                para[paracount] = new SqlParameter("@AlbumType", SqlDbType.NVarChar, 100);
                para[paracount++].Value = data.AlbumType;
                para[paracount] = new SqlParameter("@Description", SqlDbType.NVarChar, 4000);
                para[paracount++].Value = data.Description;
                para[paracount] = new SqlParameter("@IsActive", SqlDbType.Bit);
                para[paracount++].Value = data.IsActive;
                para[paracount] = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
                para[paracount++].Value = data.UnitPrice;
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
            return para;
        }





    }
}
