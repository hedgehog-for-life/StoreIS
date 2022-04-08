using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Entities
{
    public partial class Person
    {
        public Person()
        {
            EmploymentAppApplicant = new HashSet<EmploymentApp>();
            EmploymentAppHr = new HashSet<EmploymentApp>();
            OrderCourier = new HashSet<Order>();
            OrderUser = new HashSet<Order>();
            QuestionConsultant = new HashSet<Question>();
            QuestionUser = new HashSet<Question>();
            Review = new HashSet<Review>();
            ShoppingCart = new HashSet<ShoppingCart>();
        }

        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string PersonSurname { get; set; }
        public string PersonName { get; set; }
        public string PersonPatronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }

        public virtual UserRole Role { get; set; }
        public virtual ICollection<EmploymentApp> EmploymentAppApplicant { get; set; }
        public virtual ICollection<EmploymentApp> EmploymentAppHr { get; set; }
        public virtual ICollection<Order> OrderCourier { get; set; }
        public virtual ICollection<Order> OrderUser { get; set; }
        public virtual ICollection<Question> QuestionConsultant { get; set; }
        public virtual ICollection<Question> QuestionUser { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
    }
}
