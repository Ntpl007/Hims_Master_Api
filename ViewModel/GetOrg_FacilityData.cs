using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class GetOrg_FacilityData
    {
        public string OrganizationName { get; set; }
        public int OrganizationId { get; set; }
        public string Address { get; set; } = null;
        public int FacilityCount { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }

    }
}
