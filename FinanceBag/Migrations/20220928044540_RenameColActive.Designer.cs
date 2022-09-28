﻿// <auto-generated />
using System;
using FinanceBag.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinanceBag.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220928044540_RenameColActive")]
    partial class RenameColActive
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FinanceBag.Models.Active", b =>
                {
                    b.Property<string>("ISIN_id")
                        .HasColumnType("text");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TradingMode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TypeOfActive_id")
                        .HasColumnType("integer");

                    b.HasKey("ISIN_id");

                    b.HasIndex("TypeOfActive_id");

                    b.ToTable("Actives");
                });

            modelBuilder.Entity("FinanceBag.Models.Deal", b =>
                {
                    b.Property<int>("Deal_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Deal_id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DT")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ISIN_id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Sum")
                        .HasColumnType("numeric");

                    b.HasKey("Deal_id");

                    b.HasIndex("ISIN_id");

                    b.ToTable("Deals");
                });

            modelBuilder.Entity("FinanceBag.Models.TypeOfActive", b =>
                {
                    b.Property<int>("TypeOfActive_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TypeOfActive_id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TypeOfActive_id");

                    b.ToTable("TypeOfActives");
                });

            modelBuilder.Entity("FinanceBag.Models.Active", b =>
                {
                    b.HasOne("FinanceBag.Models.TypeOfActive", "TypeOfActive")
                        .WithMany("Actives")
                        .HasForeignKey("TypeOfActive_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeOfActive");
                });

            modelBuilder.Entity("FinanceBag.Models.Deal", b =>
                {
                    b.HasOne("FinanceBag.Models.Active", "Actives")
                        .WithMany("Deals")
                        .HasForeignKey("ISIN_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actives");
                });

            modelBuilder.Entity("FinanceBag.Models.Active", b =>
                {
                    b.Navigation("Deals");
                });

            modelBuilder.Entity("FinanceBag.Models.TypeOfActive", b =>
                {
                    b.Navigation("Actives");
                });
#pragma warning restore 612, 618
        }
    }
}
