using LLP.BOL.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BOL.BookingForm
{    
    public class Component: CustomComboOptions
    {
        public bool IsActive { get; set; }
        public bool IsInPackage { get; set; }
        public int UnitPrice { get; set; }
        public int PhotographerTypeComponentLinkID { get; set; }
    }
}
