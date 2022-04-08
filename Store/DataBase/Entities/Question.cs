using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class Question
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ThemeId { get; set; }
        public int? ConsultantId { get; set; }
        public string QText { get; set; }
        public DateTime PublishQDate { get; set; }
        public string AText { get; set; }
        public DateTime? PublishADate { get; set; }
        public short QStatus { get; set; }

        public virtual Person Consultant { get; set; }
        public virtual QTheme Theme { get; set; }
        public virtual Person User { get; set; }
    }
}
