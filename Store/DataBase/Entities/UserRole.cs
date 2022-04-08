using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class UserRole
    {
        public UserRole()
        {
            Code = new HashSet<Code>();
            Person = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Code> Code { get; set; }
        public virtual ICollection<Person> Person { get; set; }
    }
}
