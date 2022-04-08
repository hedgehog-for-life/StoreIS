using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderGood = new HashSet<OrderGood>();
        }

        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int UserId { get; set; }
        public int? CourierId { get; set; }
        public int AddressId { get; set; }
        public short PaymentMethod { get; set; }
        public short DeliveryMethod { get; set; }
        public decimal DeliveryPrice { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalCost { get; set; }
        public bool Verified { get; set; }
        public short OrderStatus { get; set; }

        public virtual Address Address { get; set; }
        public virtual Person Courier { get; set; }
        public virtual Person User { get; set; }
        public virtual ICollection<OrderGood> OrderGood { get; set; }
    }
}
