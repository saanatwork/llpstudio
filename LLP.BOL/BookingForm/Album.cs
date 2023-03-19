using LLP.BOL.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BOL.BookingForm
{
    public class Album : CustomComboOptions
    {
        public bool IsActive { get; set; }
        public int UnitPrice { get; set; }
    }
}
