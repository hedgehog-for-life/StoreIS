using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class Category
    {
        public Category()
        {
            Good = new HashSet<Good>();
        }

        public int Id { get; set; }
        public string CName { get; set; }
        public string CDescription { get; set; }

        public virtual ICollection<Good> Good { get; set; }
    }
}
