using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class PatientVo
    {
        public long PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }

        public string PatienTMrn { get; set; }
        public decimal? Age { get; set; }
        public string GENDER { get; set; }
        public string AadhaarNumber { get; set; }


    }
}
