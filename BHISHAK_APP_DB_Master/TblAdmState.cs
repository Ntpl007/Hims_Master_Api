﻿using System;
using System.Collections.Generic;

#nullable disable

namespace HIMS_MASTERDATA.BHISHAK_APP_DB_Master
{
    public partial class TblAdmState
    {
        public TblAdmState()
        {
            TblAppointmentPatientTemps = new HashSet<TblAppointmentPatientTemp>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Createdby { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Updatedby { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<TblAppointmentPatientTemp> TblAppointmentPatientTemps { get; set; }
    }
}
