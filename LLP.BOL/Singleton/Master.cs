using LLP.BOL.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BOL.Singleton
{
    public sealed class Master
    {
        private static readonly Lazy<Master> instance = new Lazy<Master>();
        public static Master GetInstance
        {
            get { return instance.Value; }
        }
        public Master()
        {
            getVehicletypes();           
        }        
        private void getVehicletypes()
        {
            VehicleTypes = new List<CustomComboOptions>()
            {
                new CustomComboOptions{ ID = 1, DisplayText = "LV" },
                new CustomComboOptions{ ID = 2, DisplayText = "2 Wheeler" }
            };
        }
        public List<CustomComboOptions> VehicleTypes { get; set; }

    }
}
