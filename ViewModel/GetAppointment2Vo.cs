using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class GetAppointment2Vo
    {
        public string Appointment_Date { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }
        //  public string Patient_Mrn { get; set; }
        //  public int Patient_Id { get; set; }
        public string Patient_Name { get; set; }
        public string Mobile_Number { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Doctor_Name { get; set; }
        // public string Appointment_Type { get; set; }
        public string Appointment_status { get; set; }
        //  public int PatientId { get; set; }
        //  public int PatientMrn { get; set; }
        public int PatientTempId { get; set; }
        public string isTemp { get; set; } = null;
        public int AppointmentId { get; set; }
        public string AgeModeId { get; set; }
        public int PatientId { get; set; }

    }
}
