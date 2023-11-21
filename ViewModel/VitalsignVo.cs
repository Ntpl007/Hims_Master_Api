using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class VitalsignVo
    {
        public int VITAL_SIGN_ID { get; set; }
        public string VITAL_SIGN { get; set; }
        public string MIN_VALUE { get; set; }
        public string MAX_VALUE { get; set; }
        public string UNIT_OF_MEASURE { get; set; }
        
    }
}
