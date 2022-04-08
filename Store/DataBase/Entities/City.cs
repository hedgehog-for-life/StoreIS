using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class City
    {
        public City()
        {
            Street = new HashSet<Street>();
        }

        public int Id { get; set; }
        public int RegionId { get; set; }
        public string CityName { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Street> Street { get; set; }
    }
}
