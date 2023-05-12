﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructue.Migrations
{
    [DbContext(typeof(AMContext))]
    [Migration("20230512135456_database")]
    partial class database
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationCore.Domain.CentreVaccination", b =>
                {
                    b.Property<int>("CentreVaccinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CentreVaccinationId"));

                    b.Property<int>("Capacite")
                        .HasColumnType("int");

                    b.Property<int>("NbChaises")
                        .HasColumnType("int");

                    b.Property<int>("NumTelephone")
                        .HasColumnType("int");

                    b.Property<string>("ResponsableCentre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VaccinFK")
                        .HasColumnType("int");

                    b.HasKey("CentreVaccinationId");

                    b.ToTable("CentreVaccination");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Citoyen", b =>
                {
                    b.Property<string>("CIN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CitoyenId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroEvax")
                        .HasColumnType("int");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telephone")
                        .HasColumnType("int");

                    b.HasKey("CIN");

                    b.ToTable("Citoyen");
                });

            modelBuilder.Entity("ApplicationCore.Domain.RendezVous", b =>
                {
                    b.Property<DateTime>("DateVaccination")
                        .HasColumnType("datetime2");

                    b.Property<int>("VaccinId")
                        .HasColumnType("int");

                    b.Property<string>("CitoyenId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodeInfirmiere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NbrDoses")
                        .HasColumnType("int");

                    b.HasKey("DateVaccination", "VaccinId", "CitoyenId");

                    b.HasIndex("CitoyenId");

                    b.HasIndex("VaccinId");

                    b.ToTable("RendezVous");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Vaccin", b =>
                {
                    b.Property<int>("VaccinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VaccinId"));

                    b.Property<int>("CentreDeVacId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateValidite")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fournisseur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.Property<int>("TypeVaccin")
                        .HasColumnType("int");

                    b.HasKey("VaccinId");

                    b.HasIndex("CentreDeVacId");

                    b.ToTable("Vaccin");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Citoyen", b =>
                {
                    b.OwnsOne("ApplicationCore.Domain.Addresse", "Addresse", b1 =>
                        {
                            b1.Property<string>("CitoyenCIN")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("CodePostal")
                                .HasColumnType("int");

                            b1.Property<int>("Rue")
                                .HasColumnType("int");

                            b1.Property<string>("Ville")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CitoyenCIN");

                            b1.ToTable("Citoyen");

                            b1.WithOwner()
                                .HasForeignKey("CitoyenCIN");
                        });

                    b.Navigation("Addresse")
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationCore.Domain.RendezVous", b =>
                {
                    b.HasOne("ApplicationCore.Domain.Citoyen", "Citoyen")
                        .WithMany("RendezVous")
                        .HasForeignKey("CitoyenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Domain.Vaccin", "Vaccin")
                        .WithMany("RendezVous")
                        .HasForeignKey("VaccinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Citoyen");

                    b.Navigation("Vaccin");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Vaccin", b =>
                {
                    b.HasOne("ApplicationCore.Domain.CentreVaccination", "CentreVaccination")
                        .WithMany("Vaccins")
                        .HasForeignKey("CentreDeVacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CentreVaccination");
                });

            modelBuilder.Entity("ApplicationCore.Domain.CentreVaccination", b =>
                {
                    b.Navigation("Vaccins");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Citoyen", b =>
                {
                    b.Navigation("RendezVous");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Vaccin", b =>
                {
                    b.Navigation("RendezVous");
                });
#pragma warning restore 612, 618
        }
    }
}
