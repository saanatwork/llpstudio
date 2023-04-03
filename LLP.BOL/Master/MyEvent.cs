using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BOL.Master
{
    public class MyEvent
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventNameUrl { get; set; }
        public int ParentEventID { get; set; }
        public string ImageFile { get; set; }
        public string EventLongText { get; set; }
        public bool IsActive { get; set; }
    }
    public class MyEvent4DT : MyEvent 
    {
        public int RowNum { get; set; }
        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
        public string IsActiveStr { get; set; }
        public string ParrentEventName { get; set; }
    }
}
