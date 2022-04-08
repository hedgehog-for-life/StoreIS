using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class Review
    {
        public int Id { get; set; }
        public int GoodId { get; set; }
        public int? UserId { get; set; }
        public float Assessment { get; set; }
        public string ReviewText { get; set; }
        public DateTime PublishDate { get; set; }

        public virtual Good Good { get; set; }
        public virtual Person User { get; set; }
    }
}
