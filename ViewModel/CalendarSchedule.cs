using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class CalendarSchedule
    {
        public int providerId { get; set; }
        public DateTime selectedDate { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public TimeSpan startTime { get; set; }
        public TimeSpan endTime { get; set; }
        public int? scheduleInterval { get; set; }
        public string providerscheduletime { get; set; }
        public int scheduleTemplatePeriodId { get; set; }


    }
}
