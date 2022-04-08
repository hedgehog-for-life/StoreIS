using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class GoodCollection
    {
        public int GoodId { get; set; }
        public int ColId { get; set; }

        public virtual Collection Col { get; set; }
        public virtual Good Good { get; set; }
    }
}
