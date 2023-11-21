using System;
using System.Collections.Generic;

#nullable disable

namespace HIMS_MASTERDATA.BHISHAK_APP_DB_Master
{
    public partial class TblAdmProviderType
    {
        public TblAdmProviderType()
        {
            TblProviders = new HashSet<TblProvider>();
        }

        public int ProviderTypeId { get; set; }
        public string ProviderType { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual TblAdmStatus Status { get; set; }
        public virtual ICollection<TblProvider> TblProviders { get; set; }
    }
}
