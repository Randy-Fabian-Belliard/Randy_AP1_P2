﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Parcial2_AP1_Randy.Server.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231121172301_2")]
    partial class _2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            ClienteId = 1,
                            Nombres = "FERRETERIA GAMA"
                        },
                        new
                        {
                            ClienteId = 2,
                            Nombres = "AVALON DISCO"
                        },
                        new
                        {
                            ClienteId = 3,
                            Nombres = "PRESTAMOS CEFIPROD"
                        });
                });

            modelBuilder.Entity("Cobros", b =>
                {
                    b.Property<int>("CobroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("CobroId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Cobros");
                });

            modelBuilder.Entity("CobrosDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CobroId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ConbroId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Observaciones")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Pagar")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalCobrado")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalFacturas")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VentaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DetalleId");

                    b.HasIndex("ConbroId");

                    b.HasIndex("VentaId");

                    b.ToTable("CobrosDetalle");
                });

            modelBuilder.Entity("Ventas", b =>
                {
                    b.Property<int>("VentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Balance")
                        .HasColumnType("REAL");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("Monto")
                        .HasColumnType("REAL");

                    b.HasKey("VentaId");

                    b.ToTable("Ventas");

                    b.HasData(
                        new
                        {
                            VentaId = 1,
                            Balance = 1000.0,
                            ClienteId = 1,
                            Fecha = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 1000.0
                        },
                        new
                        {
                            VentaId = 2,
                            Balance = 800.0,
                            ClienteId = 1,
                            Fecha = new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 900.0
                        },
                        new
                        {
                            VentaId = 3,
                            Balance = 2000.0,
                            ClienteId = 2,
                            Fecha = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 2000.0
                        },
                        new
                        {
                            VentaId = 4,
                            Balance = 1800.0,
                            ClienteId = 2,
                            Fecha = new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 1900.0
                        },
                        new
                        {
                            VentaId = 5,
                            Balance = 3000.0,
                            ClienteId = 3,
                            Fecha = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 3000.0
                        },
                        new
                        {
                            VentaId = 6,
                            Balance = 1900.0,
                            ClienteId = 3,
                            Fecha = new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 2900.0
                        });
                });

            modelBuilder.Entity("Cobros", b =>
                {
                    b.HasOne("Clientes", null)
                        .WithMany("Cobros")
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("CobrosDetalle", b =>
                {
                    b.HasOne("Cobros", null)
                        .WithMany("CobroDetalles")
                        .HasForeignKey("ConbroId");

                    b.HasOne("Ventas", null)
                        .WithMany("CobrosDetalles")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Clientes", b =>
                {
                    b.Navigation("Cobros");
                });

            modelBuilder.Entity("Cobros", b =>
                {
                    b.Navigation("CobroDetalles");
                });

            modelBuilder.Entity("Ventas", b =>
                {
                    b.Navigation("CobrosDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}
