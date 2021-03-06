﻿// <auto-generated />
using System;
using BlocXChange.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlocXChange.Migrations
{
    [DbContext(typeof(BlocXChangeDBContext))]
    [Migration("20181025131900_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlocXChange.Models.Exchange", b =>
                {
                    b.Property<int>("ExchangeDataNo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Buyer");

                    b.Property<int>("Seller");

                    b.Property<int>("Value");

                    b.HasKey("ExchangeDataNo");

                    b.ToTable("Exchanges");
                });

            modelBuilder.Entity("BlocXChange.Models.Fluctuation", b =>
                {
                    b.Property<int>("FlucNo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("FlucTimeTicks");

                    b.Property<int>("FlucValue");

                    b.Property<int>("GameNo");

                    b.HasKey("FlucNo");

                    b.HasIndex("GameNo");

                    b.ToTable("Fluctuations");
                });

            modelBuilder.Entity("BlocXChange.Models.Game", b =>
                {
                    b.Property<int>("GameNO")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GameID")
                        .IsRequired();

                    b.Property<string>("GameKey")
                        .IsRequired();

                    b.Property<DateTime>("InitialTime");

                    b.Property<long>("SuspendedTicks");

                    b.HasKey("GameNO");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BlocXChange.Models.Stock", b =>
                {
                    b.Property<int>("StockNo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyNo");

                    b.Property<int>("GameNo");

                    b.Property<int>("StockValue");

                    b.HasKey("StockNo");

                    b.HasIndex("GameNo");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("BlocXChange.Models.Fluctuation", b =>
                {
                    b.HasOne("BlocXChange.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameNo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlocXChange.Models.Stock", b =>
                {
                    b.HasOne("BlocXChange.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameNo")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
