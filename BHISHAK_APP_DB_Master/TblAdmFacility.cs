using System;
using System.Collections.Generic;

#nullable disable

namespace HIMS_MASTERDATA.BHISHAK_APP_DB_Master
{
    public partial class TblAdmFacility
    {
        public TblAdmFacility()
        {
            TblAppointments = new HashSet<TblAppointment>();
            TblProviderScheduleTemplates = new HashSet<TblProviderScheduleTemplate>();
        }

        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Createdby { get; set; }

        public virtual ICollection<TblAppointment> TblAppointments { get; set; }
        public virtual ICollection<TblProviderScheduleTemplate> TblProviderScheduleTemplates { get; set; }
    }
}
