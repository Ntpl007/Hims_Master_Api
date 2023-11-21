using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class ReqUserListVo
    {
        public string Username { get; set; } = null;
        public int Role { get; set; }
        public int Facility { get; set; }
        public int Organization { get; set; }
    }
}
