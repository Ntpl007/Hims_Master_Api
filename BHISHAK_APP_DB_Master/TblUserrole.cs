﻿using System;
using System.Collections.Generic;

#nullable disable

namespace HIMS_MASTERDATA.BHISHAK_APP_DB_Master
{
    public partial class TblUserrole
    {
        public int UserRoleId { get; set; }
        public int? UserId { get; set; }
        public int? Roleid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
