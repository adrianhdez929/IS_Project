﻿// <auto-generated />
using System;
using APIAeropuerto.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIAeropuerto.Persistence.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    partial class CoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIAeropuerto.Persistence.Entities.AirportPersistence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("GeographicPosition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("APIAeropuerto.Persistence.Entities.ClientPersistence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("APIAeropuerto.Persistence.Entities.ClientServicesPersistence", b =>
                {
                    b.Property<Guid>("IdClient")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IdService")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("IdClient", "IdService");

                    b.HasIndex("IdService");

                    b.ToTable("ClientServices");
                });

            modelBuilder.Entity("APIAeropuerto.Persistence.Entities.InstallationsPersistence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AirportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AirportId");

                    b.ToTable("Installations");
                });

            modelBuilder.Entity("APIAeropuerto.Persistence.Entities.ServicesPersistence", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InstallationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Code");

                    b.HasIndex("InstallationId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("APIAeropuerto.Persistence.Entities.ClientServicesPersistence", b =>
                {
                    b.HasOne("APIAeropuerto.Persistence.Entities.ClientPersistence", "Client")
                        .WithMany("ClientServices")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIAeropuerto.Persistence.Entities.ServicesPersistence", "Service")
                        .WithMany("ClientServices")
                        .HasForeignKey("IdService")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("APIAeropuerto.Persistence.Entities.InstallationsPersistence", b =>
                {
                    b.HasOne("APIAeropuerto.Persistence.Entities.AirportPersistence", "Airport")
                        .WithMany("Installations")
                        .HasForeignKey("AirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airport");
                });

            modelBuilder.Entity("APIAeropuerto.Persistence.Entities.ServicesPersistence", b =>
                {
                    b.HasOne("APIAeropuerto.Persistence.Entities.InstallationsPersistence", "Installation")
                        .WithMany("Services")
                        .HasForeignKey("InstallationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Installation");
                });

            modelBuilder.Entity("APIAeropuerto.Persistence.Entities.AirportPersistence", b =>
                {
                    b.Navigation("Installations");
                });

            modelBuilder.Entity("APIAeropuerto.Persistence.Entities.ClientPersistence", b =>
                {
                    b.Navigation("ClientServices");
                });

            modelBuilder.Entity("APIAeropuerto.Persistence.Entities.InstallationsPersistence", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("APIAeropuerto.Persistence.Entities.ServicesPersistence", b =>
                {
                    b.Navigation("ClientServices");
                });
#pragma warning restore 612, 618
        }
    }
}
