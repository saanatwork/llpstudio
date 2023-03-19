using LLP.BOL.CustomModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.DAL
{
    public class CommonTable
    {
        public DataTable UDTable { get; set; }
        public CommonTable(List<CustomCheckBoxOption> customoptions)
        {
            UDTable = new DataTable();
            UDTable.Columns.Add("iCommonID", typeof(Int32));
            UDTable.Columns.Add("bCommonStatus", typeof(Boolean));
            UDTable.Columns.Add("sCommonValue1", typeof(string));
            UDTable.Columns.Add("sCommonValue2", typeof(string));
            UDTable.Columns.Add("sCommonValue3", typeof(string));
            UDTable.Columns.Add("sCommonValue4", typeof(string));

            customoptions = customoptions.Where(o => o.IsSelected == true).ToList();
            if (customoptions != null && customoptions.Count > 0)
            {
                foreach (CustomCheckBoxOption obj in customoptions)
                {
                    DataRow dr = UDTable.NewRow();
                    dr["iCommonID"] = obj.ID;
                    UDTable.Rows.Add(dr);
                }
            }
        }
        
    }
}
