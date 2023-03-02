﻿// <auto-generated />
using System;
using EducationalInstitutions.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EducationalInstitutions.Migrations
{
    [DbContext(typeof(EducationalInstitutionsContext))]
    partial class EducationalInstitutionsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClassRoomStudent", b =>
                {
                    b.Property<int>("ClassRoomsId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("ClassRoomsId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("ClassRoomStudent");
                });

            modelBuilder.Entity("EducationalInstitutions.Models.ClassRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("bit");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("EducationalInstitutions.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "SoftWare"
                        },
                        new
                        {
                            Id = 2,
                            Name = "HardWare"
                        });
                });

            modelBuilder.Entity("EducationalInstitutions.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EducationalInstitutions.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Hamed",
                            LastName = "Fakori"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Sohrab",
                            LastName = "Amiri"
                        });
                });

            modelBuilder.Entity("ClassRoomStudent", b =>
                {
                    b.HasOne("EducationalInstitutions.Models.ClassRoom", null)
                        .WithMany()
                        .HasForeignKey("ClassRoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EducationalInstitutions.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EducationalInstitutions.Models.ClassRoom", b =>
                {
                    b.HasOne("EducationalInstitutions.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EducationalInstitutions.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
