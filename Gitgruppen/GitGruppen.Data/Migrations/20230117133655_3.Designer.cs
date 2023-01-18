﻿// <auto-generated />
using System;
using Gitgruppen.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GitGruppen.Data.Migrations
{
    [DbContext(typeof(GitgruppenContext))]
    [Migration("20230117133655_3")]
    partial class _3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GitGruppen.Core.Member", b =>
                {
                    b.Property<string>("PersNr")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersNr");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("GitGruppen.Core.ParkingSpot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SpotNo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ParkingSpot");
                });

            modelBuilder.Entity("GitGruppen.Core.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MemberPersNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("TimeArrival")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeDeparture")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalCost")
                        .HasColumnType("float");

                    b.Property<string>("VehicleLicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MemberPersNr");

                    b.HasIndex("VehicleLicensePlate");

                    b.ToTable("Receipt");
                });

            modelBuilder.Entity("GitGruppen.Core.Vehicle", b =>
                {
                    b.Property<string>("LicensePlate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Arrived")
                        .HasColumnType("datetime2");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberPersNr")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfWheels")
                        .HasColumnType("int");

                    b.Property<int?>("ParkingSpotId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.HasKey("LicensePlate");

                    b.HasIndex("MemberPersNr");

                    b.HasIndex("ParkingSpotId")
                        .IsUnique()
                        .HasFilter("[ParkingSpotId] IS NOT NULL");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("GitGruppen.Core.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NrOfSpaces")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleType");
                });

            modelBuilder.Entity("GitGruppen.Core.Receipt", b =>
                {
                    b.HasOne("GitGruppen.Core.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberPersNr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GitGruppen.Core.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleLicensePlate")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("GitGruppen.Core.Vehicle", b =>
                {
                    b.HasOne("GitGruppen.Core.Member", "Member")
                        .WithMany("Vehicles")
                        .HasForeignKey("MemberPersNr");

                    b.HasOne("GitGruppen.Core.ParkingSpot", "ParkingSpot")
                        .WithOne("Vehicle")
                        .HasForeignKey("GitGruppen.Core.Vehicle", "ParkingSpotId");

                    b.HasOne("GitGruppen.Core.VehicleType", "VehicleType")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("ParkingSpot");

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("GitGruppen.Core.Member", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("GitGruppen.Core.ParkingSpot", b =>
                {
                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("GitGruppen.Core.VehicleType", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}