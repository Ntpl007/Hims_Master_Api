using System;
using System.Collections.Generic;

#nullable disable

namespace HIMS_MASTERDATA.BHISHAK_APP_DB_Master
{
    public partial class TblFacilityVitalsign
    {
        public int FacilityVitalsignId { get; set; }
        public int VitalsignId { get; set; }
        public int FacilitySpecialitylnkId { get; set; }
        public int StatusId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? OrderNumber { get; set; }
    }
}
