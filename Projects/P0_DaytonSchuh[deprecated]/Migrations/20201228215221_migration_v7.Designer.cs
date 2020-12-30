﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P0_DaytonSchuh;

namespace P0_DaytonSchuh.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20201228215221_migration_v7")]
    partial class migration_v7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("P0_DaytonSchuh.Customer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("P0_DaytonSchuh.Inventory", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<Guid>("InventoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Key");

                    b.ToTable("inventories");
                });

            modelBuilder.Entity("P0_DaytonSchuh.Location", b =>
                {
                    b.Property<Guid>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InventoryKey")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationID");

                    b.HasIndex("InventoryKey");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("P0_DaytonSchuh.Order", b =>
                {
                    b.Property<Guid>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RequestedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("P0_DaytonSchuh.OrderLog", b =>
                {
                    b.Property<Guid>("LocationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrdersOrderID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LocationID");

                    b.HasIndex("OrdersOrderID");

                    b.ToTable("OrderLog");
                });

            modelBuilder.Entity("P0_DaytonSchuh.Product", b =>
                {
                    b.Property<Guid>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductID");

                    b.ToTable("products");
                });

            modelBuilder.Entity("P0_DaytonSchuh.Location", b =>
                {
                    b.HasOne("P0_DaytonSchuh.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryKey");

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("P0_DaytonSchuh.Order", b =>
                {
                    b.HasOne("P0_DaytonSchuh.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("P0_DaytonSchuh.OrderLog", b =>
                {
                    b.HasOne("P0_DaytonSchuh.Location", null)
                        .WithOne("Orders")
                        .HasForeignKey("P0_DaytonSchuh.OrderLog", "LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P0_DaytonSchuh.Order", "Orders")
                        .WithMany()
                        .HasForeignKey("OrdersOrderID");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("P0_DaytonSchuh.Location", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
