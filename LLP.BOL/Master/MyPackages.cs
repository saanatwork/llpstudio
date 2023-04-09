using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BOL.Master
{
    public class MyPackages
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string PackageNameUrl { get; set; }
        public string PackageIcon { get; set; }
        public int EventId { get; set; }
    }
    public class MyPackages4DT: MyPackages 
    {        
        public string EventName { get; set; }
        public int RowNum { get; set; }
        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
    }
}
