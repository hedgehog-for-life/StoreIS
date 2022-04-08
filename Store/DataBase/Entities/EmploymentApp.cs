using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class EmploymentApp
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public int? HrId { get; set; }
        public byte[] Resume { get; set; }
        public int? Seniority { get; set; }
        public short AppStatus { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }

        public virtual Person Applicant { get; set; }
        public virtual Person Hr { get; set; }
    }
}
