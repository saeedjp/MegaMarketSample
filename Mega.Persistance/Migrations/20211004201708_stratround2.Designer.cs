﻿// <auto-generated />
using System;
using Mega.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mega.Persistance.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20211004201708_stratround2")]
    partial class stratround2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.3.21201.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mega.Domain.Entity.Products.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Mega.Domain.Entity.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Fulname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InsertTime = new DateTime(2021, 10, 4, 23, 47, 7, 842, DateTimeKind.Local).AddTicks(1100),
                            IsRemoved = false,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            InsertTime = new DateTime(2021, 10, 4, 23, 47, 7, 845, DateTimeKind.Local).AddTicks(6304),
                            IsRemoved = false,
                            Name = "Operator"
                        },
                        new
                        {
                            Id = 3,
                            InsertTime = new DateTime(2021, 10, 4, 23, 47, 7, 845, DateTimeKind.Local).AddTicks(6425),
                            IsRemoved = false,
                            Name = "Customer"
                        });
                });

            modelBuilder.Entity("UserInRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserInRoles");
                });

            modelBuilder.Entity("Mega.Domain.Entity.Products.Category", b =>
                {
                    b.HasOne("Mega.Domain.Entity.Products.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("UserInRole", b =>
                {
                    b.HasOne("Role", "Role")
                        .WithMany("UserInRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mega.Domain.Entity.Users.User", "User")
                        .WithMany("UserInRole")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mega.Domain.Entity.Products.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Mega.Domain.Entity.Users.User", b =>
                {
                    b.Navigation("UserInRole");
                });

            modelBuilder.Entity("Role", b =>
                {
                    b.Navigation("UserInRole");
                });
#pragma warning restore 612, 618
        }
    }
}