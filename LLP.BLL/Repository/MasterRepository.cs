using LLP.BLL.IRepository;
using LLP.BOL.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BLL.Repository
{
    public class MasterRepository : IMasterRepository
    {
        public IEnumerable<CustomComboOptions> getEmployeeList(int centreCode, int functionalDesg, int isOtherStaff, ref string pMsg)
        {
            throw new NotImplementedException();
        }
    }
}
