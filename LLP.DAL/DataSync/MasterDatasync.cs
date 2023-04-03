﻿using LLP.BOL.Master;
using LLP.DAL.ParamMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.DAL.DataSync
{
    public class MasterDatasync
    {
        CommonParamMapper _CommonParamMapper;
        MasterParamMapper _MasterParamMapper;
        public MasterDatasync()
        {
            _CommonParamMapper = new CommonParamMapper();
            _MasterParamMapper = new MasterParamMapper();
        }
        public DataTable GetEventsForDataTable(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[MTR].[usp_GetEventsForDataTable]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_CommonParamMapper.MapParam_DIsplayList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
        }
        public DataSet GetEvents(int EventID, int ParrentEventID, int TypeID,ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[MTR].[usp_GetEvent]", CommandType.StoredProcedure))
                {
                    return sql.GetDataSet(_MasterParamMapper.MapParam_GetEvent(EventID, ParrentEventID,TypeID, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
        }
        public DataTable SetEvent(MyEvent data,ref string pMsg) 
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[MTR].[usp_SetEvent]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_MasterParamMapper.MapParam_SetEvent(data, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
        }
        public DataTable SetEventImage(int EventID, string ImageFile, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[MTR].[usp_SetEventImage]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_MasterParamMapper.MapParam_SetEventImage(EventID, ImageFile, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = ex.Message; return null; }
        }




    }
}
