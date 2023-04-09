using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BOL.Master
{
    public class Album
    {
        public int AlbumTypeId { get; set; }
        public string AlbumType { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public double UnitPrice { get; set; }
    }
    public class Album4DT : Album 
    {
        public string IsActiveStr { get; set; }
        public int RowNum { get; set; }
        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
    }
}
