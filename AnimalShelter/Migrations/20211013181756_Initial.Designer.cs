﻿// <auto-generated />
using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimalShelter.Migrations
{
    [DbContext(typeof(AnimalShelterContext))]
    [Migration("20211013181756_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AnimalShelter.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("AnimalId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("AnimalShelter.Models.AnimalTrick", b =>
                {
                    b.Property<int>("AnimalTrickId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("TrickId")
                        .HasColumnType("int");

                    b.HasKey("AnimalTrickId");

                    b.HasIndex("AnimalId");

                    b.HasIndex("TrickId");

                    b.ToTable("AnimalTrick");
                });

            modelBuilder.Entity("AnimalShelter.Models.Trick", b =>
                {
                    b.Property<int>("TrickId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TrickName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("TrickId");

                    b.ToTable("Tricks");
                });

            modelBuilder.Entity("AnimalShelter.Models.AnimalTrick", b =>
                {
                    b.HasOne("AnimalShelter.Models.Animal", "Animal")
                        .WithMany("JoinEntities")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimalShelter.Models.Trick", "Trick")
                        .WithMany("JoinEntities")
                        .HasForeignKey("TrickId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Trick");
                });

            modelBuilder.Entity("AnimalShelter.Models.Animal", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("AnimalShelter.Models.Trick", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}