using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class GetAppointmentFiltersVo
    {
        public DateTime? FromDate { get; set; } = null;
        public DateTime? ToDate { get; set; } = null;
        public string PatientName { get; set; } = null;
        public string MobileNumber { get; set; } = null;
        public int? DoctorId { get; set; } = null;
        public int? AppointmentStatusId { get; set; } = null;
        public int OrganizationId { get; set; }
        public int FacilityId { get; set; }

    }
}
