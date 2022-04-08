using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class QTheme
    {
        public QTheme()
        {
            Question = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string ThemeName { get; set; }
        public string ThemeDescription { get; set; }

        public virtual ICollection<Question> Question { get; set; }
    }
}
