using LLP.BLL.IRepository;
using LLP.BOL.CustomModels;
using LLP.BOL.Master;
using LLP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BLL.Repository
{
    public class MasterRepository : IMasterRepository
    {
        MasterEntity _MasterEntity;
        public MasterRepository()
        {
            _MasterEntity = new MasterEntity();
        }
        public MyEvent GetEvent(int EventID, ref string pMsg)
        {
            return _MasterEntity.GetEvents(EventID, -1, 2, ref pMsg).FirstOrDefault();
        }
        public List<MyEvent4DT> GetEventsForDataTable(int DisplayLength, int DisplayStart, int SortColumn, string SortDirection, string SearchText, ref string pMsg)
        {
            return _MasterEntity.GetEventsForDataTable(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg);
        }
        public List<MyEvent> GetParentEvents(ref string pMsg)
        {
            return _MasterEntity.GetEvents(0,-1,1,ref pMsg);
        }
        public List<MyEvent> GetSubEventsOfaParrent(int ParrentEventID, ref string pMsg)
        {
            return _MasterEntity.GetEvents(0, ParrentEventID, 2, ref pMsg);
        }
        public bool SetEvent(MyEvent data, ref string pMsg)
        {
            data.ImageFile = string.IsNullOrEmpty(data.ImageFile) ? " " : data.ImageFile;
            return _MasterEntity.SetEvent(data, ref pMsg);
        }
        public bool SetEventImage(int EventID, string ImageFile, ref string pMsg)
        {
            return _MasterEntity.SetEventImage(EventID, ImageFile, ref pMsg);
        }
    }
}
