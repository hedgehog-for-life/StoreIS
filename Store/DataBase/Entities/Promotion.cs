using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class Promotion
    {
        public Promotion()
        {
            GoodPromotion = new HashSet<GoodPromotion>();
        }

        public int Id { get; set; }
        public string PromotionName { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public short GoodNum { get; set; }
        public short Discount { get; set; }
        public short FreeGoodNum { get; set; }

        public virtual ICollection<GoodPromotion> GoodPromotion { get; set; }
    }
}
