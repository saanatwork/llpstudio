﻿using LLP.BOL.CustomModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.DAL.ObjectMapper
{
    public class DBResponseMapper
    {
        public void Map_DBResponse(DataTable dt, ref string pMsg, ref bool IsSuccess)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                if (!DBNull.Value.Equals(dt.Rows[0]["IsSuccess"]))
                    IsSuccess = bool.Parse(dt.Rows[0]["IsSuccess"].ToString());
                if (!DBNull.Value.Equals(dt.Rows[0]["Msg"]))
                    pMsg = dt.Rows[0]["Msg"].ToString();
            }
        }
        public CustomComboOptions Map_CustomComboOptions(DataRow dr)
        {
            CustomComboOptions result = new CustomComboOptions();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["ID"]))
                    result.ID = int.Parse(dr["ID"].ToString());
                if (!DBNull.Value.Equals(dr["DisplayText"]))
                    result.DisplayText = result.ID + " / " + dr["DisplayText"].ToString();
            }
            return result;
        }
        public CustomComboOptions Map_CustomComboOptionsForEmployees(DataRow dr)
        {
            CustomComboOptions result = new CustomComboOptions();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["EmployeeNumber"]))
                    result.ID = int.Parse(dr["EmployeeNumber"].ToString());
                if (!DBNull.Value.Equals(dr["EmployeeName"]))
                    result.DisplayText = result.ID + " / " + dr["EmployeeName"].ToString();
            }
            return result;
        }
        public CustomComboOptions Map_CustomComboOptionsForDrivers(DataRow dr)
        {
            CustomComboOptions result = new CustomComboOptions();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["ID"]))
                    result.ID = int.Parse(dr["ID"].ToString());
                if (!DBNull.Value.Equals(dr["DisplayText"]))
                    result.DisplayText = dr["DisplayText"].ToString();
                if (result.DisplayText.IndexOf("/") < 0)
                {
                    result.DisplayText = result.ID + " / " + dr["DisplayText"].ToString();
                }
            }
            return result;
        }
        public CustomCheckBoxOption Map_CustomCheckBoxOption(DataRow dr)
        {
            CustomCheckBoxOption result = new CustomCheckBoxOption();
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["ID"]))
                    result.ID = int.Parse(dr["ID"].ToString());
                if (!DBNull.Value.Equals(dr["DisplayText"]))
                    result.DisplayText = dr["DisplayText"].ToString();
                if (!DBNull.Value.Equals(dr["IsSelected"]))
                    result.IsSelected = bool.Parse(dr["IsSelected"].ToString());
            }
            return result;
        }        
    }
}
