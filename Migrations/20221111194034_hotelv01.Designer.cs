﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using hotel.Models;

#nullable disable

namespace hotel.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20221111194034_hotelv01")]
    partial class hotelv01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("hotel.Models.Parceiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("atividade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("juridicaId")
                        .HasColumnType("integer");

                    b.Property<string>("tipopessoa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("juridicaId");

                    b.ToTable("parceiro");
                });

            modelBuilder.Entity("hotel.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Fone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pessoa");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pessoa");
                });

            modelBuilder.Entity("hotel.Models.ReservaHotel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int?>("FisicaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("datareserva")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("numeroreserva")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("valor")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("FisicaId");

                    b.ToTable("reservaHotel");
                });

            modelBuilder.Entity("hotel.Models.Fisica", b =>
                {
                    b.HasBaseType("hotel.Models.Pessoa");

                    b.Property<int>("ParceiroId")
                        .HasColumnType("integer");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("nascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("rg")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasIndex("ParceiroId");

                    b.HasDiscriminator().HasValue("Fisica");
                });

            modelBuilder.Entity("hotel.Models.juridica", b =>
                {
                    b.HasBaseType("hotel.Models.Pessoa");

                    b.Property<string>("cnpj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("fundacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("inscricaoestadual")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("juridica");
                });

            modelBuilder.Entity("hotel.Models.Parceiro", b =>
                {
                    b.HasOne("hotel.Models.juridica", null)
                        .WithMany("Parceiro")
                        .HasForeignKey("juridicaId");
                });

            modelBuilder.Entity("hotel.Models.ReservaHotel", b =>
                {
                    b.HasOne("hotel.Models.Fisica", null)
                        .WithMany("ReservaHotel")
                        .HasForeignKey("FisicaId");
                });

            modelBuilder.Entity("hotel.Models.Fisica", b =>
                {
                    b.HasOne("hotel.Models.Parceiro", "Parceiro")
                        .WithMany()
                        .HasForeignKey("ParceiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parceiro");
                });

            modelBuilder.Entity("hotel.Models.Fisica", b =>
                {
                    b.Navigation("ReservaHotel");
                });

            modelBuilder.Entity("hotel.Models.juridica", b =>
                {
                    b.Navigation("Parceiro");
                });
#pragma warning restore 612, 618
        }
    }
}
