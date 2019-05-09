﻿// <auto-generated />
using System;
using DotNetCoreEFAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNetCoreEFAPI.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20190509083433_DotNetCoreEFAPI.Models.AddConstraintsOnColumns")]
    partial class DotNetCoreEFAPIModelsAddConstraintsOnColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNetCoreEFAPI.Models.Employee", b =>
                {
                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new { EmployeeId = 1L, DateOfBirth = new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "uncle.bob@gmail.com", FirstName = "Uncle", LastName = "Bob", PhoneNumber = "999-888-7777" },
                        new { EmployeeId = 2L, DateOfBirth = new DateTime(1981, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "jan.kirsten@gmail.com", FirstName = "Jan", LastName = "Kirsten", PhoneNumber = "111-222-3333" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
