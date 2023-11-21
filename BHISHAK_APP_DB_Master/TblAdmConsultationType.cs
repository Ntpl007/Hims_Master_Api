using System;
using System.Collections.Generic;

#nullable disable

namespace HIMS_MASTERDATA.BHISHAK_APP_DB_Master
{
    public partial class TblAdmConsultationType
    {
        public int ConsultationTypeId { get; set; }
        public string ConsultationType { get; set; }
        public int? StatusId { get; set; }

        public virtual TblAdmStatus Status { get; set; }
    }
}
