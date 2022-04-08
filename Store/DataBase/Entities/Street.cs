using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class Street
    {
        public Street()
        {
            Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public int CityId { get; set; }
        public string StreetName { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }
}
