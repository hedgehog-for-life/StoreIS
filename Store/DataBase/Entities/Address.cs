using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class Address
    {
        public Address()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int StreetId { get; set; }
        public string AddIndex { get; set; }
        public string House { get; set; }
        public string ApartmentNum { get; set; }
        public short AddType { get; set; }

        public virtual Street Street { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
