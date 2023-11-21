using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class GetPatientDetailsbyAppointment
    {
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public DateTime DATE_OF_BIRTH { get; set; }
        public decimal AGE { get; set; }
        public int SEX { get; set; }
        public int Age_mode { get; set; }
        public string MOBILE_NUMBER { get; set; }
        public string AADHAR_NO { get; set; }
        public int STATE_ID { get; set; }
        public int DISTRICT_ID { get; set; }
        public string CITY { get; set; }
        public string DOOR_NO { get; set; }
        public string VILLAGE { get; set; }
        public string Prefix { get; set; }
        public int NATIONALITY_ID { get; set; }
        public int RELIGION_ID { get; set; }
        public int PINCODE { get; set; }
        public string Email { get; set; }
        public int PATIENT_ID { get; set; }
        public int DOCTOR_ID { get; set; }
        public int SPECIALITY_ID { get; set; }
 
    }
}
