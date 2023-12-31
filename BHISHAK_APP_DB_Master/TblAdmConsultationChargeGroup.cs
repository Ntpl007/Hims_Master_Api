﻿using System;
using System.Collections.Generic;

#nullable disable

namespace HIMS_MASTERDATA.BHISHAK_APP_DB_Master
{
    public partial class TblAdmConsultationChargeGroup
    {
        public int ConsultationChargeGroupId { get; set; }
        public string ConsultationChargeGroup { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreatedBy { get; set; }

        public virtual TblAdmStatus Status { get; set; }
    }
}
