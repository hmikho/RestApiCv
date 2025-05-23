﻿// <auto-generated />
using System;
using Backend_Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend_Api.Migrations
{
    [DbContext(typeof(CvDBContext))]
    [Migration("20250312132355_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend_Api.Models.Arbetserfarenhet", b =>
                {
                    b.Property<int>("JobbID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobbID"));

                    b.Property<string>("Beskrivning")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Företag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Jobbtitel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("PersonID_FK")
                        .HasColumnType("int");

                    b.Property<string>("Startår")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobbID");

                    b.HasIndex("PersonID");

                    b.ToTable("Arbetserfarenheter");
                });

            modelBuilder.Entity("Backend_Api.Models.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonID"));

                    b.Property<string>("Beskrivning")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefonnummer")
                        .HasColumnType("int");

                    b.HasKey("PersonID");

                    b.ToTable("Personer");
                });

            modelBuilder.Entity("Backend_Api.Models.Utbildning", b =>
                {
                    b.Property<int>("UtbildningID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UtbildningID"));

                    b.Property<string>("Examen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("PersonID_FK")
                        .HasColumnType("int");

                    b.Property<string>("Skola")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SlutDatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("UtbildningID");

                    b.HasIndex("PersonID");

                    b.ToTable("Utbildningar");
                });

            modelBuilder.Entity("Backend_Api.Models.Arbetserfarenhet", b =>
                {
                    b.HasOne("Backend_Api.Models.Person", "Person")
                        .WithMany("Arbetserfarenheter")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Backend_Api.Models.Utbildning", b =>
                {
                    b.HasOne("Backend_Api.Models.Person", "Person")
                        .WithMany("Utbildningar")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Backend_Api.Models.Person", b =>
                {
                    b.Navigation("Arbetserfarenheter");

                    b.Navigation("Utbildningar");
                });
#pragma warning restore 612, 618
        }
    }
}
