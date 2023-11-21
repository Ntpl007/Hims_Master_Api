using System;
using System.Collections.Generic;

#nullable disable

namespace HIMS_MASTERDATA.BHISHAK_APP_DB_Master
{
    public partial class TempTable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int? Count { get; set; }
        public int? DoctorId { get; set; }
    }
}
