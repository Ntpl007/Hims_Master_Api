using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class GetFacilityTariffDatacs
    {
        public int Facility_Tariff_Id { get; set; }
        public int Charge_Item_Id { get; set; }

        public string Display_Name { get; set; }

        public int Oraganisation_Id { get; set; }


        public int Facility_Id { get; set; }

        public decimal Base_Price { get; set; }

        public decimal Unit_Price { get; set; }

        public string CREATED_BY { get; set; }

        public string CHARGE_ITEM { get; set; }


        public string facility_name { get; set; }

        public string organization_name { get; set; }

        public DateTime CREATED_DATE_TIME { get; set; }

    }
}
