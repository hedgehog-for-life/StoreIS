using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class WriteOff
    {
        public int Id { get; set; }
        public int GoodId { get; set; }
        public int ReasonId { get; set; }
        public DateTime WriteOffDate { get; set; }
        public int GoodNum { get; set; }
        public short WriteOffStatus { get; set; }

        public virtual Good Good { get; set; }
        public virtual WriteOffReason Reason { get; set; }
    }
}
