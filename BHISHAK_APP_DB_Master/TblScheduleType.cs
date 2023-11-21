﻿using System;
using System.Collections.Generic;

#nullable disable

namespace HIMS_MASTERDATA.BHISHAK_APP_DB_Master
{
    public partial class TblScheduleType
    {
        public TblScheduleType()
        {
            TblAppointments = new HashSet<TblAppointment>();
        }

        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int ScheduleTypeId { get; set; }
        public string ScheduleTypeName { get; set; }

        public virtual ICollection<TblAppointment> TblAppointments { get; set; }
    }
}
