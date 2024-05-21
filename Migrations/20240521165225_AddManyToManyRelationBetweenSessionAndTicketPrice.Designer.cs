﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftServe_Practice.Data;

#nullable disable

namespace SoftServe_Practice.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240521165225_AddManyToManyRelationBetweenSessionAndTicketPrice")]
    partial class AddManyToManyRelationBetweenSessionAndTicketPrice
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SoftServe_Practice.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("SoftServe_Practice.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("SoftServe_Practice.Models.SessionTicketPrice", b =>
                {
                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int>("TicketPriceId")
                        .HasColumnType("int");

                    b.HasKey("SessionId", "TicketPriceId");

                    b.HasIndex("TicketPriceId");

                    b.ToTable("SessionTicketPrice");
                });

            modelBuilder.Entity("SoftServe_Practice.Models.TicketPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TicketPrices");
                });

            modelBuilder.Entity("SoftServe_Practice.Models.Session", b =>
                {
                    b.HasOne("SoftServe_Practice.Models.Movie", "Movie")
                        .WithMany("Sessions")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("SoftServe_Practice.Models.SessionTicketPrice", b =>
                {
                    b.HasOne("SoftServe_Practice.Models.Session", "Session")
                        .WithMany("SessionTicketPrices")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftServe_Practice.Models.TicketPrice", "TicketPrice")
                        .WithMany("SessionTicketPrices")
                        .HasForeignKey("TicketPriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");

                    b.Navigation("TicketPrice");
                });

            modelBuilder.Entity("SoftServe_Practice.Models.Movie", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("SoftServe_Practice.Models.Session", b =>
                {
                    b.Navigation("SessionTicketPrices");
                });

            modelBuilder.Entity("SoftServe_Practice.Models.TicketPrice", b =>
                {
                    b.Navigation("SessionTicketPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
