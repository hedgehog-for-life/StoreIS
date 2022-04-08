using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class Good
    {
        public Good()
        {
            GoodCollection = new HashSet<GoodCollection>();
            GoodPromotion = new HashSet<GoodPromotion>();
            OrderGood = new HashSet<OrderGood>();
            Review = new HashSet<Review>();
            ShoppingCart = new HashSet<ShoppingCart>();
            WriteOff = new HashSet<WriteOff>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string GoodName { get; set; }
        public string Article { get; set; }
        public int GoodNum { get; set; }
        public string GoodDescription { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte[] Image { get; set; }
        public string Characteristic { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<GoodCollection> GoodCollection { get; set; }
        public virtual ICollection<GoodPromotion> GoodPromotion { get; set; }
        public virtual ICollection<OrderGood> OrderGood { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
        public virtual ICollection<WriteOff> WriteOff { get; set; }
    }
}
