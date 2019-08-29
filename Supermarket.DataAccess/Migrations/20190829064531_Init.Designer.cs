﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Supermarket.DataAccess.Data;

namespace Supermarket.DataAccess.Migrations
{
    [DbContext(typeof(SupermarketContext))]
    [Migration("20190829064531_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Supermarket.Domain.Models.Company", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("Address")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CooperationTime");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(10);

                    b.Property<string>("Director")
                        .HasMaxLength(20);

                    b.Property<string>("Fax")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Supermarket.Domain.Models.Goods", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<int>("AlarmNum");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(10);

                    b.Property<int>("GoodNum");

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.Property<string>("Norm")
                        .HasMaxLength(20);

                    b.Property<string>("Remarks")
                        .HasMaxLength(500);

                    b.Property<decimal>("SellPrice");

                    b.Property<string>("TypeId")
                        .HasMaxLength(50);

                    b.Property<string>("Unit")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("Supermarket.Domain.Models.GoodsType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(10);

                    b.Property<string>("TypeName")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("GoodsType");
                });

            modelBuilder.Entity("Supermarket.Domain.Models.Sell", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(10);

                    b.Property<string>("GoodsId")
                        .HasMaxLength(50);

                    b.Property<int>("GoodsNum");

                    b.Property<int>("Operator");

                    b.Property<string>("Remarks")
                        .HasMaxLength(500);

                    b.Property<decimal>("SellPrice");

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Sell");
                });

            modelBuilder.Entity("Supermarket.Domain.Models.Stock", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("ConmpanyId")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(10);

                    b.Property<string>("GoodsId")
                        .HasMaxLength(50);

                    b.Property<int>("GoodsNum");

                    b.Property<int>("Operator");

                    b.Property<decimal>("Price");

                    b.Property<string>("Remark")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("Supermarket.Domain.Models.StockPrice", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("ConmpanyId")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(10);

                    b.Property<string>("GoodsId")
                        .HasMaxLength(50);

                    b.Property<decimal>("GoodsSellPrice");

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("StockPrice");
                });

            modelBuilder.Entity("Supermarket.Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(10);

                    b.Property<string>("Password")
                        .HasMaxLength(30);

                    b.Property<string>("RealName")
                        .HasMaxLength(10);

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .HasMaxLength(10);

                    b.Property<string>("UserName")
                        .HasMaxLength(30);

                    b.Property<string>("UserRight")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
