using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class ChargeItemVo
    {
        public int ChargeItemId { set; get; }

        public string ChargeItem { set; get; }

        public decimal? UnitCost { set; get; }
    }
}

