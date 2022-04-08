using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Store.DataBase.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.DataBase.Context
{
    public partial class stuff_shopContext : DbContext
    {
        public stuff_shopContext()
        {
        }

        public stuff_shopContext(DbContextOptions<stuff_shopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Code> Code { get; set; }
        public virtual DbSet<Collection> Collection { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<EmploymentApp> EmploymentApp { get; set; }
        public virtual DbSet<Good> Good { get; set; }
        public virtual DbSet<GoodCollection> GoodCollection { get; set; }
        public virtual DbSet<GoodPromotion> GoodPromotion { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderGood> OrderGood { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<QTheme> QTheme { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<Street> Street { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<WriteOff> WriteOff { get; set; }
        public virtual DbSet<WriteOffReason> WriteOffReason { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=127.0.0.1;uid=root;pwd=195sunshine90f;database=stuff_shop");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.HasIndex(e => e.StreetId)
                    .HasName("street_ind");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddIndex)
                    .IsRequired()
                    .HasColumnName("add_index")
                    .HasMaxLength(30);

                entity.Property(e => e.AddType).HasColumnName("add_type");

                entity.Property(e => e.ApartmentNum)
                    .HasColumnName("apartment_num")
                    .HasMaxLength(5);

                entity.Property(e => e.House)
                    .IsRequired()
                    .HasColumnName("house")
                    .HasMaxLength(5);

                entity.Property(e => e.StreetId).HasColumnName("street_id");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.StreetId)
                    .HasConstraintName("address_ibfk_1");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.HasIndex(e => e.CName)
                    .HasName("c_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CDescription).HasColumnName("c_description");

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasColumnName("c_name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.HasIndex(e => e.RegionId)
                    .HasName("region_ind");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasColumnName("city_name")
                    .HasMaxLength(255);

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("city_ibfk_1");
            });

            modelBuilder.Entity<Code>(entity =>
            {
                entity.ToTable("code");

                entity.HasIndex(e => e.CodeString)
                    .HasName("code_string")
                    .IsUnique();

                entity.HasIndex(e => e.RoleId)
                    .HasName("role_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodeString)
                    .IsRequired()
                    .HasColumnName("code_string")
                    .HasMaxLength(255);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Code)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("code_ibfk_1");
            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.ToTable("collection");

                entity.HasIndex(e => e.ColName)
                    .HasName("col_name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColName)
                    .IsRequired()
                    .HasColumnName("col_name")
                    .HasMaxLength(255);

                entity.Property(e => e.ColStatus).HasColumnName("col_status");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnName("country_name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<EmploymentApp>(entity =>
            {
                entity.ToTable("employment_app");

                entity.HasIndex(e => e.ApplicantId)
                    .HasName("applicant_ind");

                entity.HasIndex(e => e.HrId)
                    .HasName("hr_ind");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AppStatus).HasColumnName("app_status");

                entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");

                entity.Property(e => e.ContactEmail)
                    .HasColumnName("contact_email")
                    .HasMaxLength(255);

                entity.Property(e => e.ContactNumber)
                    .HasColumnName("contact_number")
                    .HasMaxLength(10);

                entity.Property(e => e.HrId).HasColumnName("hr_id");

                entity.Property(e => e.Resume)
                    .IsRequired()
                    .HasColumnName("resume")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.Seniority).HasColumnName("seniority");

                entity.HasOne(d => d.Applicant)
                    .WithMany(p => p.EmploymentAppApplicant)
                    .HasForeignKey(d => d.ApplicantId)
                    .HasConstraintName("employment_app_ibfk_1");

                entity.HasOne(d => d.Hr)
                    .WithMany(p => p.EmploymentAppHr)
                    .HasForeignKey(d => d.HrId)
                    .HasConstraintName("employment_app_ibfk_2");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.ToTable("good");

                entity.HasIndex(e => e.Article)
                    .HasName(" article_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.CategoryId)
                    .HasName("category_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Article)
                    .IsRequired()
                    .HasColumnName(" article")
                    .HasMaxLength(15);

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Characteristic)
                    .HasColumnName("characteristic")
                    .HasMaxLength(45);

                entity.Property(e => e.GoodDescription).HasColumnName("good_description");

                entity.Property(e => e.GoodName)
                    .IsRequired()
                    .HasColumnName("good_name")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodNum).HasColumnName("good_num");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(9,2)");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnName("release_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Good)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("good_ibfk_1");
            });

            modelBuilder.Entity<GoodCollection>(entity =>
            {
                entity.HasKey(e => new { e.GoodId, e.ColId })
                    .HasName("PRIMARY");

                entity.ToTable("good_collection");

                entity.HasIndex(e => e.ColId)
                    .HasName("col_ind");

                entity.HasIndex(e => e.GoodId)
                    .HasName("good_ind");

                entity.Property(e => e.GoodId).HasColumnName("good_id");

                entity.Property(e => e.ColId).HasColumnName("col_id");

                entity.HasOne(d => d.Col)
                    .WithMany(p => p.GoodCollection)
                    .HasForeignKey(d => d.ColId)
                    .HasConstraintName("good_collection_ibfk_2");

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.GoodCollection)
                    .HasForeignKey(d => d.GoodId)
                    .HasConstraintName("good_collection_ibfk_1");
            });

            modelBuilder.Entity<GoodPromotion>(entity =>
            {
                entity.HasKey(e => new { e.GoodId, e.PromotionId })
                    .HasName("PRIMARY");

                entity.ToTable("good_promotion");

                entity.HasIndex(e => e.GoodId)
                    .HasName("good_ind");

                entity.HasIndex(e => e.PromotionId)
                    .HasName("promotion_ind");

                entity.Property(e => e.GoodId).HasColumnName("good_id");

                entity.Property(e => e.PromotionId).HasColumnName("promotion_id");

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.GoodPromotion)
                    .HasForeignKey(d => d.GoodId)
                    .HasConstraintName("good_promotion_ibfk_1");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.GoodPromotion)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("good_promotion_ibfk_2");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.HasIndex(e => e.AddressId)
                    .HasName("address_ind");

                entity.HasIndex(e => e.CourierId)
                    .HasName("courier_ind");

                entity.HasIndex(e => e.OrderNumber)
                    .HasName("order_number_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserId)
                    .HasName("user_ind");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.CourierId).HasColumnName("courier_id");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnName("delivery_date")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryMethod).HasColumnName("delivery_method");

                entity.Property(e => e.DeliveryPrice)
                    .HasColumnName("delivery_price")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasColumnName("order_number")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'XXXXXXXX-XXXX'");

                entity.Property(e => e.OrderStatus).HasColumnName("order_status");

                entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");

                entity.Property(e => e.TotalCost)
                    .HasColumnName("total_cost")
                    .HasColumnType("decimal(9,2)");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Verified).HasColumnName("verified");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_ibfk_3");

                entity.HasOne(d => d.Courier)
                    .WithMany(p => p.OrderCourier)
                    .HasForeignKey(d => d.CourierId)
                    .HasConstraintName("order_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("order_ibfk_1");
            });

            modelBuilder.Entity<OrderGood>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.GoodId })
                    .HasName("PRIMARY");

                entity.ToTable("order_good");

                entity.HasIndex(e => e.GoodId)
                    .HasName("good_ind");

                entity.HasIndex(e => e.OrderId)
                    .HasName("order_ind");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.GoodId).HasColumnName("good_id");

                entity.Property(e => e.Characteristic)
                    .HasColumnName("characteristic")
                    .HasMaxLength(45);

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.FreeGoodNum).HasColumnName("free_good_num");

                entity.Property(e => e.GoodNum).HasColumnName("good_num");

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.OrderGood)
                    .HasForeignKey(d => d.GoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_good_ibfk_2");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderGood)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("order_good_ibfk_1");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.HasIndex(e => e.Email)
                    .HasName("email")
                    .IsUnique();

                entity.HasIndex(e => e.RoleId)
                    .HasName("role_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.PersonName)
                    .IsRequired()
                    .HasColumnName("person_name")
                    .HasMaxLength(50);

                entity.Property(e => e.PersonPatronymic)
                    .HasColumnName("person_patronymic")
                    .HasMaxLength(50);

                entity.Property(e => e.PersonSurname)
                    .IsRequired()
                    .HasColumnName("person_surname")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(10);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("user_password");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("person_ibfk_1");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.ToTable("promotion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateBegin)
                    .HasColumnName("date_begin")
                    .HasColumnType("date");

                entity.Property(e => e.DateEnd)
                    .HasColumnName("date_end")
                    .HasColumnType("date");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.FreeGoodNum).HasColumnName("free_good_num");

                entity.Property(e => e.GoodNum).HasColumnName("good_num");

                entity.Property(e => e.PromotionName)
                    .IsRequired()
                    .HasColumnName("promotion_name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<QTheme>(entity =>
            {
                entity.ToTable("q_theme");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ThemeDescription).HasColumnName("theme_description");

                entity.Property(e => e.ThemeName)
                    .IsRequired()
                    .HasColumnName("theme_name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("question");

                entity.HasIndex(e => e.ConsultantId)
                    .HasName("consultant_ind");

                entity.HasIndex(e => e.ThemeId)
                    .HasName("theme_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_ind");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AText).HasColumnName("a_text");

                entity.Property(e => e.ConsultantId).HasColumnName("consultant_id");

                entity.Property(e => e.PublishADate)
                    .HasColumnName("publish_a_date")
                    .HasColumnType("date");

                entity.Property(e => e.PublishQDate)
                    .HasColumnName("publish_q_date")
                    .HasColumnType("date");

                entity.Property(e => e.QStatus).HasColumnName("q_status");

                entity.Property(e => e.QText)
                    .IsRequired()
                    .HasColumnName("q_text");

                entity.Property(e => e.ThemeId).HasColumnName("theme_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Consultant)
                    .WithMany(p => p.QuestionConsultant)
                    .HasForeignKey(d => d.ConsultantId)
                    .HasConstraintName("question_ibfk_3");

                entity.HasOne(d => d.Theme)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.ThemeId)
                    .HasConstraintName("question_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.QuestionUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("question_ibfk_1");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("region");

                entity.HasIndex(e => e.CountryId)
                    .HasName("country_ind");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasColumnName("region_name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Region)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("region_ibfk_1");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("review");

                entity.HasIndex(e => e.GoodId)
                    .HasName("good_ind");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_ind");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Assessment).HasColumnName("assessment");

                entity.Property(e => e.GoodId).HasColumnName("good_id");

                entity.Property(e => e.PublishDate)
                    .HasColumnName("publish_date")
                    .HasColumnType("date");

                entity.Property(e => e.ReviewText)
                    .IsRequired()
                    .HasColumnName("review_text");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.GoodId)
                    .HasConstraintName("review_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("review_ibfk_2");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.ToTable("shopping_cart");

                entity.HasIndex(e => e.GoodId)
                    .HasName("good_ind");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_ind");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Characteristic)
                    .HasColumnName("characteristic")
                    .HasMaxLength(45);

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("decimal(9,2)");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.FreeGoods).HasColumnName("free_goods");

                entity.Property(e => e.GoodId).HasColumnName("good_id");

                entity.Property(e => e.GoodNum).HasColumnName("good_num");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.ShoppingCart)
                    .HasForeignKey(d => d.GoodId)
                    .HasConstraintName("shopping_cart_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShoppingCart)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("shopping_cart_ibfk_2");
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.ToTable("street");

                entity.HasIndex(e => e.CityId)
                    .HasName("city_ind");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasColumnName("street_name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Street)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("street_ibfk_1");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_role");

                entity.HasIndex(e => e.RoleName)
                    .HasName("role_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("role_name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<WriteOff>(entity =>
            {
                entity.ToTable("write_off");

                entity.HasIndex(e => e.GoodId)
                    .HasName("good_ind");

                entity.HasIndex(e => e.ReasonId)
                    .HasName("reason_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GoodId).HasColumnName("good_id");

                entity.Property(e => e.GoodNum).HasColumnName("good_num");

                entity.Property(e => e.ReasonId).HasColumnName("reason_id");

                entity.Property(e => e.WriteOffDate)
                    .HasColumnName("write_off_date")
                    .HasColumnType("date");

                entity.Property(e => e.WriteOffStatus).HasColumnName("write_off_status");

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.WriteOff)
                    .HasForeignKey(d => d.GoodId)
                    .HasConstraintName("write_off_ibfk_1");

                entity.HasOne(d => d.Reason)
                    .WithMany(p => p.WriteOff)
                    .HasForeignKey(d => d.ReasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("write_off_ibfk_2");
            });

            modelBuilder.Entity<WriteOffReason>(entity =>
            {
                entity.ToTable("write_off_reason");

                entity.HasIndex(e => e.ReasonName)
                    .HasName("reason_name_2")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ReasonName)
                    .IsRequired()
                    .HasColumnName("reason_name")
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
