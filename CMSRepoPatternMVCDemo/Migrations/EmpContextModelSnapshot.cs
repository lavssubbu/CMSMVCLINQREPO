﻿// <auto-generated />
using System;
using CMSRepoPatternMVCDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CMSRepoPatternMVCDemo.Migrations
{
    [DbContext(typeof(EmpContext))]
    partial class EmpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CMSRepoPatternMVCDemo.Models.Department", b =>
                {
                    b.Property<int>("DepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepId"));

                    b.Property<string>("DepName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("CMSRepoPatternMVCDemo.Models.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmployeeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpId"));

                    b.Property<int?>("DepId")
                        .HasColumnType("int");

                    b.Property<string>("Desig")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("EmpName")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EmpId");

                    b.HasIndex("DepId");

                    b.ToTable("EmployeeTable");
                });

            modelBuilder.Entity("CMSRepoPatternMVCDemo.Models.Employee", b =>
                {
                    b.HasOne("CMSRepoPatternMVCDemo.Models.Department", "department")
                        .WithMany("Employees")
                        .HasForeignKey("DepId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("department");
                });

            modelBuilder.Entity("CMSRepoPatternMVCDemo.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
