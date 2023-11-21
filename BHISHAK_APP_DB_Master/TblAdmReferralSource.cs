using System;
using System.Collections.Generic;

#nullable disable

namespace HIMS_MASTERDATA.BHISHAK_APP_DB_Master
{
    public partial class TblAdmReferralSource
    {
        public TblAdmReferralSource()
        {
            TblAdmReferralSourceNames = new HashSet<TblAdmReferralSourceName>();
        }

        public int ReferralSourceId { get; set; }
        public string ReferralSourceCode { get; set; }
        public string ReferralSourceDesc { get; set; }
        public int StatusId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual TblAdmStatus Status { get; set; }
        public virtual ICollection<TblAdmReferralSourceName> TblAdmReferralSourceNames { get; set; }
    }
}
