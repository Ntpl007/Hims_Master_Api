﻿using System;
using System.Collections.Generic;

#nullable disable

namespace HIMS_MASTERDATA.BHISHAK_APP_DB_Master
{
    public partial class TblAdmVitalsign
    {
        public int VitalSignId { get; set; }
        public string VitalSign { get; set; }
        public int StatusId { get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }
        public string UnitOfMeasure { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
