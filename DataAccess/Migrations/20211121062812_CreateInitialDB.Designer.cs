﻿// <auto-generated />
using System;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211121062812_CreateInitialDB")]
    partial class CreateInitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("DataAccess.Data.CrimeCity", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CityId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("CrimeCities");
                });

            modelBuilder.Entity("DataAccess.Data.CrimeDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("City_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CrimeDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("CrimeType_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsMarkerAdded")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsTrueCrime")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MyLat")
                        .HasColumnType("REAL");

                    b.Property<double>("MyLng")
                        .HasColumnType("REAL");

                    b.Property<int>("Province_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<int>("Suburb_Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CrimeDetails");
                });

            modelBuilder.Entity("DataAccess.Data.CrimeProvince", b =>
                {
                    b.Property<int>("ProvinceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProvinceId");

                    b.ToTable("CrimeProvinces");
                });

            modelBuilder.Entity("DataAccess.Data.CrimeSuburb", b =>
                {
                    b.Property<int>("SuburbId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("SuburbId");

                    b.HasIndex("CityId");

                    b.ToTable("CrimeSuburbs");
                });

            modelBuilder.Entity("DataAccess.Data.CrimeType", b =>
                {
                    b.Property<int>("CrimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CrimeId");

                    b.ToTable("CrimeTypes");
                });

            modelBuilder.Entity("DataAccess.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsEmailNotification")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPushNotification")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsTermsAccepted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RegistationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetName")
                        .HasColumnType("TEXT");

                    b.Property<int>("SuburbId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataAccess.Data.CrimeCity", b =>
                {
                    b.HasOne("DataAccess.Data.CrimeProvince", "CrimeProvince")
                        .WithMany()
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CrimeProvince");
                });

            modelBuilder.Entity("DataAccess.Data.CrimeSuburb", b =>
                {
                    b.HasOne("DataAccess.Data.CrimeCity", "CrimeCity")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CrimeCity");
                });
#pragma warning restore 612, 618
        }
    }
}