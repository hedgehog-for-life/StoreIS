using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class Collection
    {
        public Collection()
        {
            GoodCollection = new HashSet<GoodCollection>();
        }

        public int Id { get; set; }
        public string ColName { get; set; }
        public short ColStatus { get; set; }

        public virtual ICollection<GoodCollection> GoodCollection { get; set; }
    }
}
