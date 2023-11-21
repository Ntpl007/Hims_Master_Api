using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class GetUserDetailsForUpdateVo
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null;
        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        public int RoleId { get; set; }
        public int FacilityId { get; set; }
        public int? OrganizationId { get; set; } 
        public int? isProvider { get; set; } = null;
        public int? SpecialityId { get; set; } = null;
        public string MobileNumber { get; set; } = null;

    }
}
