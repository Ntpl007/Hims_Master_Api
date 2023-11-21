using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class OpInput
    {
        public long PatientId { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
      //  public DateTime DatOfBirth { get; set; }
        public int Sex { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public int RelationType { get; set; }
        public string RelationName { get; set; }
      //  public string MotherName { get; set; }
        public string Occupation { get; set; }
        public int ReligionId { get; set; }
        public int AreaId { get; set; }//
        public string Address { get; set; }//
        public int SpecialityId { get; set; }
        public int DoctorId { get; set; }
        public int RefDoctorId { get; set; }
        public int NationalityId { get; set; }


        public int CorporateId { get; set; }//
        public string Comments { get; set; }//
       public decimal PaymentAmount { get; set; }
      public int  PaymentModeId { get; set; }




    }
}
