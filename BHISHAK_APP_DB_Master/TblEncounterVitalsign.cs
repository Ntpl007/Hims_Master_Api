﻿using System;
using System.Collections.Generic;

#nullable disable

namespace HIMS_MASTERDATA.BHISHAK_APP_DB_Master
{
    public partial class TblEncounterVitalsign
    {
        public int EncounterVitalsignId { get; set; }
        public long EncounterId { get; set; }
        public int VitalsignId { get; set; }
        public decimal Value { get; set; }
        public int StatusId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
