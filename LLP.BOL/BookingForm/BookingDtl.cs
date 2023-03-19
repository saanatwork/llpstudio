using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BOL.BookingForm
{
    public class BookingDtlFromDB
    {
        public int EventDay { get; set; }
        public int PhotoGrapherTypeID { get; set; }
        public string PhotoGrapherTypeDesc { get; set; }
        public int ComponentID { get; set; }
        public string ComponentDesc { get; set; }
        public int CompUnitPrice { get; set; }
        public bool CompIsInPackage { get; set; }
        public int PhotographerTypeComponentLinkID { get; set; }
    }
    public class BookingDtl 
    {
        public int EventDay { get; set; }
        public int PhotoGrapherTypeID { get; set; }
        public string PhotoGrapherTypeDesc { get; set; }
        public List<Component> Components { get; set; }
    }
}
