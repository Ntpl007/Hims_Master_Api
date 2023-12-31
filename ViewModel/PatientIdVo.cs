﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.ViewModel
{
    public class PatientIdVo
    {
        public long PatientId { get; set; }
        //public string PatientMrn { get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public decimal? Age { get; set; }
        public int? Sex { get; set; }
        public string Gender { get; set; }
        public string prefix { get; set; }
        public DateTime? dob { get; set; }
        public int? relationtype { get; set; }
        public string relationname { get; set; }
        public string occupation { get; set; }
        public int? religionid { get; set; }
        public int? nationalityid { get; set; }
        public int? areaid { get; set; }
        public string emailid { get; set; }
        public string address { get; set; }
    }
}
