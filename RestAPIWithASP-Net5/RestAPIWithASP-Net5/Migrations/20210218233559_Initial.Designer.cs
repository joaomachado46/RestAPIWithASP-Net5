﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestAPIWithASP_Net5.Model.DataContext;

namespace RestAPIWithASP_Net5.Migrations
{
    [DbContext(typeof(MySqlContext))]
    [Migration("20210218233559_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RestAPIWithASP_Net5.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasColumnName("author")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("LaunchDate")
                        .HasColumnName("launch_date")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Price")
                        .HasColumnName("price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("books");
                });

            modelBuilder.Entity("RestAPIWithASP_Net5.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnName("address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Gender")
                        .HasColumnName("gender")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("person");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Famalicão",
                            FirstName = "João",
                            Gender = "Masculino",
                            LastName = "Machado"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Famalicão",
                            FirstName = "Francisca",
                            Gender = "Feminino",
                            LastName = "Machado"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Famalicão",
                            FirstName = "Vânia",
                            Gender = "Feminino",
                            LastName = "Silva"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Famalicão",
                            FirstName = "Manel",
                            Gender = "Masculino",
                            LastName = "Antonio"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
