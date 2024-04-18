﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SearchEngine.Database;

#nullable disable

namespace SearchEngine.Migrations
{
    [DbContext(typeof(DbContextRandom))]
    partial class DbContextRandomModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("SearchEngine.Database.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TyreSize")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Brand1",
                            FuelType = "Petrol",
                            Model = "Model1",
                            TyreSize = 18,
                            Year = 2020
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Brand2",
                            FuelType = "Diesel",
                            Model = "Model2",
                            TyreSize = 18,
                            Year = 2021
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Brand3",
                            FuelType = "Petrol",
                            Model = "Model3",
                            TyreSize = 18,
                            Year = 2022
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Brand4",
                            FuelType = "Diesel",
                            Model = "Model4",
                            TyreSize = 18,
                            Year = 2023
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Brand5",
                            FuelType = "Petrol",
                            Model = "Model5",
                            TyreSize = 18,
                            Year = 2024
                        });
                });

            modelBuilder.Entity("SearchEngine.Database.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("YearBorn")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Height = 170,
                            Name = "Person 1",
                            Sex = "Male",
                            YearBorn = "1990"
                        },
                        new
                        {
                            Id = 2,
                            Height = 170,
                            Name = "Person 2",
                            Sex = "Female",
                            YearBorn = "1990"
                        },
                        new
                        {
                            Id = 3,
                            Height = 170,
                            Name = "Person 3",
                            Sex = "Male",
                            YearBorn = "1990"
                        },
                        new
                        {
                            Id = 4,
                            Height = 170,
                            Name = "Person 4",
                            Sex = "Female",
                            YearBorn = "1990"
                        },
                        new
                        {
                            Id = 5,
                            Height = 170,
                            Name = "Person 5",
                            Sex = "Male",
                            YearBorn = "1990"
                        });
                });

            modelBuilder.Entity("SearchEngine.Database.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DocumentFormat")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorName = "Author 1",
                            DocumentFormat = "PDF",
                            Name = "Project 1",
                            Year = 2020
                        },
                        new
                        {
                            Id = 2,
                            AuthorName = "Author 2",
                            DocumentFormat = "DOCX",
                            Name = "Project 2",
                            Year = 2021
                        },
                        new
                        {
                            Id = 3,
                            AuthorName = "Author 3",
                            DocumentFormat = "PDF",
                            Name = "Project 3",
                            Year = 2022
                        },
                        new
                        {
                            Id = 4,
                            AuthorName = "Author 4",
                            DocumentFormat = "DOCX",
                            Name = "Project 4",
                            Year = 2023
                        },
                        new
                        {
                            Id = 5,
                            AuthorName = "Author 5",
                            DocumentFormat = "PDF",
                            Name = "Project 5",
                            Year = 2024
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
