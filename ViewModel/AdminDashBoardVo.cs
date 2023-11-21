using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class AdminDashBoardVo
    {
        public int TotalPatientsCount { get; set; }
        public int TodayPatientsCount { get; set; }
        public int TotalVisitCount { get; set; }
        public int TotalFacilities { get; set; }

    }
}
