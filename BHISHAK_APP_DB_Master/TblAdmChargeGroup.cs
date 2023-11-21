using System;
using System.Collections.Generic;

#nullable disable

namespace HIMS_MASTERDATA.BHISHAK_APP_DB_Master
{
    public partial class TblAdmChargeGroup
    {
        public int ChargeGroupId { get; set; }
        public string ChargeGroup { get; set; }
        public int? ParentId { get; set; }
        public int? SequenceOrder { get; set; }
        public int? StatusId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? SchedulerTypeId { get; set; }
    }
}
