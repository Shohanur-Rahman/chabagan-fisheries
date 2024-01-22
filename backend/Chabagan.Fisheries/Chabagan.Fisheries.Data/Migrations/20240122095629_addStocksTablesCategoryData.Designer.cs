﻿// <auto-generated />
using System;
using Chabagan.Chabagan.Fisheries.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Chabagan.Fisheries.Data.Migrations
{
    [DbContext(typeof(FisheriesDbContext))]
    [Migration("20240122095629_addStocksTablesCategoryData")]
    partial class addStocksTablesCategoryData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Chabagan.Chabagan.Fisheries.Models.User.DbUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ForgetPasswordToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLock")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PasswordRequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedDate = new DateTime(2024, 1, 22, 15, 56, 25, 399, DateTimeKind.Local).AddTicks(3948),
                            Email = "admin@gmail.com",
                            IsDeleted = false,
                            IsLock = false,
                            Name = "Admin User",
                            Password = "qYoY0I43OQxxEowDdKKcwybAtBa5puzQtcUwpirku44=",
                            PasswordSalt = "m7U/J0PykrCb/eUIUDZ2UQ==",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2L,
                            CreatedDate = new DateTime(2024, 1, 22, 15, 56, 25, 413, DateTimeKind.Local).AddTicks(8987),
                            Email = "manager@gmail.com",
                            IsDeleted = false,
                            IsLock = false,
                            Name = "Site Manager",
                            Password = "eLMi63dOBmtp9bawOoz+rtoMx6tcUtG37m8PeV2MT7E=",
                            PasswordSalt = "m7U/J0PykrCb/eUIUDZ2UQ==",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3L,
                            CreatedDate = new DateTime(2024, 1, 22, 15, 56, 25, 428, DateTimeKind.Local).AddTicks(3928),
                            Email = "user@gmail.com",
                            IsDeleted = false,
                            IsLock = false,
                            Name = "Field User",
                            Password = "qYoY0I43OQxxEowDdKKcwybAtBa5puzQtcUwpirku44=",
                            PasswordSalt = "m7U/J0PykrCb/eUIUDZ2UQ==",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Chabagan.Fisheries.Entities.Models.Stock.DbBrand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            IsDeleted = false,
                            Name = "Squre"
                        },
                        new
                        {
                            Id = 2L,
                            IsDeleted = false,
                            Name = "Beximco"
                        },
                        new
                        {
                            Id = 3L,
                            IsDeleted = false,
                            Name = "Ibn Sina"
                        });
                });

            modelBuilder.Entity("Chabagan.Fisheries.Entities.Models.Stock.DbProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("MRP")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Chabagan.Fisheries.Entities.Models.Stock.DbPurchase", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("ApprovalStatus")
                        .HasColumnType("bit");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Dues")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GrandTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PaidAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("SupplierId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("Chabagan.Fisheries.Entities.Models.Stock.DbPurchaseItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProdSlNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProductID")
                        .HasColumnType("bigint");

                    b.Property<long>("PurchaseId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Qty")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductID");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchaseItems");
                });

            modelBuilder.Entity("Chabagan.Fisheries.Entities.Models.Stock.DbStockCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("StockCategories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            IsDeleted = false,
                            Name = "Medicine"
                        },
                        new
                        {
                            Id = 2L,
                            IsDeleted = false,
                            Name = "Feed"
                        },
                        new
                        {
                            Id = 3L,
                            IsDeleted = false,
                            Name = "Accessories"
                        });
                });

            modelBuilder.Entity("Chabagan.Fisheries.Entities.Models.User.DbRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "System Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Business Manager"
                        },
                        new
                        {
                            Id = 3,
                            Name = "General User"
                        });
                });

            modelBuilder.Entity("Chabagan.Chabagan.Fisheries.Models.User.DbUser", b =>
                {
                    b.HasOne("Chabagan.Fisheries.Entities.Models.User.DbRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Chabagan.Fisheries.Entities.Models.Stock.DbPurchaseItem", b =>
                {
                    b.HasOne("Chabagan.Fisheries.Entities.Models.Stock.DbProduct", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chabagan.Fisheries.Entities.Models.Stock.DbPurchase", "Purchase")
                        .WithMany()
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Purchase");
                });
#pragma warning restore 612, 618
        }
    }
}
