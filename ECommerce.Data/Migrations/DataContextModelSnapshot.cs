﻿// <auto-generated />
using System;
using ECommerce.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommerce.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ECommerce.Data.Entities.OutgoingEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Body");

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("Deleted");

                    b.Property<int>("OutgoingEmailStateId");

                    b.Property<string>("Subject");

                    b.Property<string>("To");

                    b.Property<int>("TryCount");

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("OutgoingEmails");
                });

            modelBuilder.Entity("ECommerce.Data.Entities.Title", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("Titles");

                    b.HasData(
                        new { Id = 1, Active = true, CreateDate = new DateTime(2020, 4, 11, 16, 1, 36, 387, DateTimeKind.Utc), Deleted = false, Name = "Müşteri" },
                        new { Id = 2, Active = true, CreateDate = new DateTime(2020, 4, 11, 16, 1, 36, 387, DateTimeKind.Utc), Deleted = false, Name = "Yönetici" }
                    );
                });

            modelBuilder.Entity("ECommerce.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<bool>("Admin");

                    b.Property<Guid?>("AutoLoginKey");

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(350);

                    b.Property<bool>("EmailVerified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("TitleId");

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("Id");

                    b.HasIndex("TitleId");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, Active = true, Admin = true, CreateDate = new DateTime(2020, 4, 11, 16, 1, 36, 387, DateTimeKind.Utc), Deleted = false, Email = "admin@admin.com", EmailVerified = false, Name = "Admin", Password = "7C222FB2927D828AF22F592134E8932480637C0D", Surname = "Admin", TitleId = 2 }
                    );
                });

            modelBuilder.Entity("ECommerce.Data.Entities.User", b =>
                {
                    b.HasOne("ECommerce.Data.Entities.Title", "Title")
                        .WithMany("Users")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
