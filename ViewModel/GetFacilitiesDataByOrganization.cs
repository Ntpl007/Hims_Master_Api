using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class GetFacilitiesDataByOrganization
    {
        public int FacilityMappingId { get; set; }
        public string Facility { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string Address { get; set; }
        public int FacilityId { get; set; }
        
    }
}
