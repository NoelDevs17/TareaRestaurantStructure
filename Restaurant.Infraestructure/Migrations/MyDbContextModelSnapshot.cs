﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurant.Infraestructure.Context;

#nullable disable

namespace Restaurant.Infraestructure.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Restaurant.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.DetallePedido", b =>
                {
                    b.Property<int>("IdDetallePedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetallePedido"), 1L, 1);

                    b.Property<int?>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int>("IdPlato")
                        .HasColumnType("int");

                    b.Property<decimal?>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdDetallePedido");

                    b.HasIndex("IdPedido");

                    b.HasIndex("IdPlato");

                    b.ToTable("DetallePedido", (string)null);
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empleado", (string)null);
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.Factura", b =>
                {
                    b.Property<int>("IdFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFactura"), 1L, 1);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdPedido")
                        .HasColumnType("int");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdFactura");

                    b.HasIndex("IdPedido");

                    b.ToTable("Factura", (string)null);
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.Menu", b =>
                {
                    b.Property<int>("IdPlato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPlato"), 1L, 1);

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPlato");

                    b.ToTable("Menu", (string)null);
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.Mesa", b =>
                {
                    b.Property<int>("IdMesa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMesa"), 1L, 1);

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMesa");

                    b.ToTable("Mesa", (string)null);
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPedido"), 1L, 1);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdMesa")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPedido");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdMesa");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.DetallePedido", b =>
                {
                    b.HasOne("Restaurant.Domain.Entities.Pedido", "Pedido")
                        .WithMany("DetallesPedido")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurant.Domain.Entities.Menu", "Menu")
                        .WithMany("DetallePedidos")
                        .HasForeignKey("IdPlato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.Factura", b =>
                {
                    b.HasOne("Restaurant.Domain.Entities.Pedido", "Pedido")
                        .WithMany("Facturas")
                        .HasForeignKey("IdPedido");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("Restaurant.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurant.Domain.Entities.Mesa", "Mesa")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdMesa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Mesa");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.Menu", b =>
                {
                    b.Navigation("DetallePedidos");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.Mesa", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Restaurant.Domain.Entities.Pedido", b =>
                {
                    b.Navigation("DetallesPedido");

                    b.Navigation("Facturas");
                });
#pragma warning restore 612, 618
        }
    }
}
