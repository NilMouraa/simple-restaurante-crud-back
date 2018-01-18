﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RestauranteBack.Infraestrutura.Data.Contexto;
using System;

namespace RestauranteBack.Infraestrutura.Data.Migrations
{
    [DbContext(typeof(RestauranteBackContext))]
    [Migration("20180113231936_RestauranteBackMigration0")]
    partial class RestauranteBackMigration0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestauranteBack.Dominio.Entidades.Prato", b =>
                {
                    b.Property<int>("PratoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<decimal>("Preco");

                    b.Property<int>("RestauranteId");

                    b.HasKey("PratoId");

                    b.HasIndex("RestauranteId");

                    b.ToTable("Prato");
                });

            modelBuilder.Entity("RestauranteBack.Dominio.Entidades.Restaurante", b =>
                {
                    b.Property<int>("RestauranteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("RestauranteId");

                    b.ToTable("Restaurante");
                });

            modelBuilder.Entity("RestauranteBack.Dominio.Entidades.Prato", b =>
                {
                    b.HasOne("RestauranteBack.Dominio.Entidades.Restaurante", "Restaurante")
                        .WithMany("Pratos")
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}