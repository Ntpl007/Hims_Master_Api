﻿using System;
using System.Collections.Generic;

#nullable disable

namespace HIMS_MASTERDATA.BHISHAK_APP_DB_Master
{
    public partial class TblAdmScheduleSlotsStatus
    {
        public TblAdmScheduleSlotsStatus()
        {
            TblProviderScheduleTemplatePeriods = new HashSet<TblProviderScheduleTemplatePeriod>();
            TblProviderSchedules = new HashSet<TblProviderSchedule>();
        }

        public int ScheduleSlotStatusId { get; set; }
        public string ScheduleSlotStatusName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<TblProviderScheduleTemplatePeriod> TblProviderScheduleTemplatePeriods { get; set; }
        public virtual ICollection<TblProviderSchedule> TblProviderSchedules { get; set; }
    }
}
