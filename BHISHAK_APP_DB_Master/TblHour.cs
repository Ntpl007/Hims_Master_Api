using System;
using System.Collections.Generic;

#nullable disable

namespace HIMS_MASTERDATA.BHISHAK_APP_DB_Master
{
    public partial class TblHour
    {
        public int Id { get; set; }
        public string Hours { get; set; }
        public int? Htype { get; set; }
    }
}
