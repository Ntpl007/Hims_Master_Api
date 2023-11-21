using System;
using System.Collections.Generic;

#nullable disable

namespace HIMS_MASTERDATA.BHISHAK_APP_DB_Master
{
    public partial class TblAdmPatientBillType
    {
        public int BillTypeId { get; set; }
        public string BillType { get; set; }
        public int? StatusId { get; set; }
        public string CreatedBy { get; set; }
    }
}
