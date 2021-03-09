﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RelationalDatabases.Persistent;

namespace RelationalDatabases.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210309095224_AddedPets")]
    partial class AddedPets
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CaretakerPet", b =>
                {
                    b.Property<long>("caretakersId")
                        .HasColumnType("bigint");

                    b.Property<long>("petsId")
                        .HasColumnType("bigint");

                    b.HasKey("caretakersId", "petsId");

                    b.HasIndex("petsId");

                    b.ToTable("CaretakerPet");
                });

            modelBuilder.Entity("RelationalDatabases.DataModels.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("cityId")
                        .HasColumnType("bigint");

                    b.Property<string>("housenumber")
                        .HasColumnType("text");

                    b.Property<string>("street")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("cityId");

                    b.ToTable("addresses");
                });

            modelBuilder.Entity("RelationalDatabases.DataModels.Caretaker", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("addressId")
                        .HasColumnType("bigint");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("addressId");

                    b.ToTable("caretakers");
                });

            modelBuilder.Entity("RelationalDatabases.DataModels.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("city")
                        .HasColumnType("text");

                    b.Property<int>("zip")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("RelationalDatabases.DataModels.Pet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("age")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<long?>("vetId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("vetId");

                    b.ToTable("pets");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pet");
                });

            modelBuilder.Entity("RelationalDatabases.DataModels.Vet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("addressId")
                        .HasColumnType("bigint");

                    b.Property<string>("cvr")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("addressId");

                    b.ToTable("vets");
                });

            modelBuilder.Entity("RelationalDatabases.DataModels.Cat", b =>
                {
                    b.HasBaseType("RelationalDatabases.DataModels.Pet");

                    b.Property<int>("lifeCount")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("Cat");
                });

            modelBuilder.Entity("RelationalDatabases.DataModels.Dog", b =>
                {
                    b.HasBaseType("RelationalDatabases.DataModels.Pet");

                    b.Property<string>("barkPitch")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Dog");
                });

            modelBuilder.Entity("CaretakerPet", b =>
                {
                    b.HasOne("RelationalDatabases.DataModels.Caretaker", null)
                        .WithMany()
                        .HasForeignKey("caretakersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RelationalDatabases.DataModels.Pet", null)
                        .WithMany()
                        .HasForeignKey("petsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RelationalDatabases.DataModels.Address", b =>
                {
                    b.HasOne("RelationalDatabases.DataModels.City", "city")
                        .WithMany("addresses")
                        .HasForeignKey("cityId");

                    b.Navigation("city");
                });

            modelBuilder.Entity("RelationalDatabases.DataModels.Caretaker", b =>
                {
                    b.HasOne("RelationalDatabases.DataModels.Address", "address")
                        .WithMany("caretakers")
                        .HasForeignKey("addressId");

                    b.Navigation("address");
                });

            modelBuilder.Entity("RelationalDatabases.DataModels.Pet", b =>
                {
                    b.HasOne("RelationalDatabases.DataModels.Vet", "vet")
                        .WithMany("pets")
                        .HasForeignKey("vetId");

                    b.Navigation("vet");
                });

            modelBuilder.Entity("RelationalDatabases.DataModels.Vet", b =>
                {
                    b.HasOne("RelationalDatabases.DataModels.Address", "address")
                        .WithMany("vets")
                        .HasForeignKey("addressId");

                    b.Navigation("address");
                });

            modelBuilder.Entity("RelationalDatabases.DataModels.Address", b =>
                {
                    b.Navigation("caretakers");

                    b.Navigation("vets");
                });

            modelBuilder.Entity("RelationalDatabases.DataModels.City", b =>
                {
                    b.Navigation("addresses");
                });

            modelBuilder.Entity("RelationalDatabases.DataModels.Vet", b =>
                {
                    b.Navigation("pets");
                });
#pragma warning restore 612, 618
        }
    }
}
