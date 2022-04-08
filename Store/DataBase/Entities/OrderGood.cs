using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class OrderGood
    {
        public int OrderId { get; set; }
        public int GoodId { get; set; }
        public int GoodNum { get; set; }
        public short Discount { get; set; }
        public short FreeGoodNum { get; set; }
        public string Characteristic { get; set; }

        public virtual Good Good { get; set; }
        public virtual Order Order { get; set; }
    }
}
