using System;
using System.Collections.Generic;

#nullable disable

namespace HIMS_MASTERDATA.BHISHAK_APP_DB_Master
{
    public partial class TblAdmSpeciality
    {
        public TblAdmSpeciality()
        {
            TblFacilities = new HashSet<TblFacility>();
            TblFacilitySpecialityLnks = new HashSet<TblFacilitySpecialityLnk>();
            TblProviders = new HashSet<TblProvider>();
        }

        public int SpecialityId { get; set; }
        public string Speciality { get; set; }
        public string SpecialityDesc { get; set; }
        public int StatusId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual TblAdmStatus Status { get; set; }
        public virtual ICollection<TblFacility> TblFacilities { get; set; }
        public virtual ICollection<TblFacilitySpecialityLnk> TblFacilitySpecialityLnks { get; set; }
        public virtual ICollection<TblProvider> TblProviders { get; set; }
    }
}
