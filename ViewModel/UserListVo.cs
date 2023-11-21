using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class UserListVo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Role_Name { get; set; }
        public string FacilityName { get; set; }
        public string OrganizationName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created_Date { get; set; }
    }
}
