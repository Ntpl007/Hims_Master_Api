using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class GetVitalSignsListToBindByspecialityVo
    {
        public int FacilityVitalSignId { get; set; }
        public int VitalSignId { get; set; }
        public string VitalSign { get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }
        public int? OrderNumber { get; set; } 
        public string UnitOfMeasure { get; set; }

    }
}
