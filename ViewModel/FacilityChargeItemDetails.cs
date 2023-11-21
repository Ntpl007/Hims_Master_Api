using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class FacilityChargeItemDetails

    {
        public int?     FacilityChargeId { get; set; }
        public int      Organization { get; set; }
        public int      FacilityId  { get; set; }
        public int      ChargeItemId { get; set; }
        public decimal  BasePrice { get; set; }
        public decimal   UnitPrice { get; set; }
        public string   CreatedBy { get; set; }
    }
}
