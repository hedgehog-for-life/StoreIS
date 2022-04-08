using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class Code
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public string CodeString { get; set; }

        public virtual UserRole Role { get; set; }
    }
}
