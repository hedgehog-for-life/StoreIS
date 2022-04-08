using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class Country
    {
        public Country()
        {
            Region = new HashSet<Region>();
        }

        public int Id { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Region> Region { get; set; }
    }
}
