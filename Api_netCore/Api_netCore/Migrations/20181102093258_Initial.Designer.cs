﻿// <auto-generated />
using System;
using Api_netCore.Controllers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api_netCore.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20181102093258_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api_netCore.Controllers.Models.SClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Slot");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("SClasses");
                });

            modelBuilder.Entity("Api_netCore.Controllers.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("ClassId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.Property<int?>("SClassId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("SClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Api_netCore.Controllers.Models.Student", b =>
                {
                    b.HasOne("Api_netCore.Controllers.Models.SClass", "SClass")
                        .WithMany("Students")
                        .HasForeignKey("SClassId");
                });
#pragma warning restore 612, 618
        }
    }
}
