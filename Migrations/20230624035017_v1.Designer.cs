﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UberEats.Models;

#nullable disable

namespace UberEats.Migrations
{
    [DbContext(typeof(UberContext))]
    [Migration("20230624035017_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("UberEats.Models.Driver", b =>
                {
                    b.Property<int>("DriverID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DriverID");

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            DriverID = 1,
                            Name = "Restaurent"
                        },
                        new
                        {
                            DriverID = 2,
                            Name = "Grocery"
                        },
                        new
                        {
                            DriverID = 3,
                            Name = "Alcohol"
                        },
                        new
                        {
                            DriverID = 4,
                            Name = "Convienience"
                        },
                        new
                        {
                            DriverID = 5,
                            Name = "Flower shop"
                        },
                        new
                        {
                            DriverID = 6,
                            Name = "Pet Store"
                        },
                        new
                        {
                            DriverID = 7,
                            Name = "retail"
                        });
                });

            modelBuilder.Entity("UberEats.Models.Partner", b =>
                {
                    b.Property<int>("PartnerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BusinessAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BusinessEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BusinessPhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DriverID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LogoImage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PartnerID");

                    b.HasIndex("DriverID");

                    b.ToTable("Partners");

                    b.HasData(
                        new
                        {
                            PartnerID = 1,
                            BusinessAddress = "Chicago, 3001",
                            BusinessEmail = "intial@gmail.com",
                            BusinessName = "intial",
                            BusinessPhone = "123456",
                            DriverID = 1,
                            LogoImage = ""
                        },
                        new
                        {
                            PartnerID = 2,
                            BusinessAddress = "401 North",
                            BusinessEmail = "apple@gmail.com",
                            BusinessName = "apple",
                            BusinessPhone = "234234",
                            DriverID = 1,
                            LogoImage = ""
                        });
                });

            modelBuilder.Entity("UberEats.Models.Partner", b =>
                {
                    b.HasOne("UberEats.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });
#pragma warning restore 612, 618
        }
    }
}