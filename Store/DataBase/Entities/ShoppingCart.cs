using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class ShoppingCart
    {
        public int Id { get; set; }
        public int GoodId { get; set; }
        public int UserId { get; set; }
        public int GoodNum { get; set; }
        public short Discount { get; set; }
        public short FreeGoods { get; set; }
        public string Characteristic { get; set; }
        public decimal Cost { get; set; }

        public virtual Good Good { get; set; }
        public virtual Person User { get; set; }
    }
}
