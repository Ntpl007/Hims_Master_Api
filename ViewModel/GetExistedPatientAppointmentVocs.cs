using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class GetExistedPatientAppointmentVocs
    {

        public long PATIENT_ID { get;set;}
        public string FIRST_NAME { get; set; } = null;
        public string LAST_NAME { get; set; } = null;
        public string MOBILE_NUMBER { get; set; } = null;
        public string AADHAR_NO { get; set; } = null;
        public int? AGE { get; set; } = null;
        public int? AGE_MODE { get; set; } = null;
        public int? GENDER { get; set; } = null;
        public string PREFIX { get; set; } = null;
        public string DATE_OF_BIRTH { get; set; } = null;
        public int? RELIGION_ID { get; set; } = null;
        public int? NATIONALITY_ID { get; set; } = null;
        public int? STATE_ID { get; set; } = null;
        public int? DISTRICT_ID { get; set; } = null;
        public string CITY { get; set; } = null;
        public string VILLAGE { get; set; } = null;
        public string PINCODE { get; set; } = null;
        public string HOUSENUMBER { get; set; } = null;

}
}
