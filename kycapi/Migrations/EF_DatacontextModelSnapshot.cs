﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace kycapi.Migrations
{
    [DbContext(typeof(EF_Datacontext))]
    partial class EF_DatacontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<bool>("Deceased")
                        .HasColumnType("boolean");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("Entity", b =>
                {
                    b.OwnsMany("Address", "Addresses", b1 =>
                        {
                            b1.Property<string>("EntityId")
                                .HasColumnType("text");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<string>("AddressLine")
                                .HasColumnType("text");

                            b1.Property<string>("City")
                                .HasColumnType("text");

                            b1.Property<string>("Country")
                                .HasColumnType("text");

                            b1.HasKey("EntityId", "Id");

                            b1.ToTable("Address");

                            b1.WithOwner()
                                .HasForeignKey("EntityId");
                        });

                    b.OwnsMany("Date", "Dates", b1 =>
                        {
                            b1.Property<string>("EntityId")
                                .HasColumnType("text");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<string>("DateType")
                                .HasColumnType("text");

                            b1.Property<DateTime?>("DateValue")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("EntityId", "Id");

                            b1.ToTable("Date");

                            b1.WithOwner()
                                .HasForeignKey("EntityId");
                        });

                    b.OwnsMany("Name", "Names", b1 =>
                        {
                            b1.Property<string>("EntityId")
                                .HasColumnType("text");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<string>("FirstName")
                                .HasColumnType("text");

                            b1.Property<string>("MiddleName")
                                .HasColumnType("text");

                            b1.Property<string>("Surname")
                                .HasColumnType("text");

                            b1.HasKey("EntityId", "Id");

                            b1.ToTable("Name");

                            b1.WithOwner()
                                .HasForeignKey("EntityId");
                        });

                    b.Navigation("Addresses");

                    b.Navigation("Dates");

                    b.Navigation("Names");
                });
#pragma warning restore 612, 618
        }
    }
}
