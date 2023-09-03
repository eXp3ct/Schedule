﻿// <auto-generated />
using System;
using Expect.Schedule.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Expect.Schedule.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230902153915_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Expect.Schedule.Domain.Models.Additional", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Additionals");
                });

            modelBuilder.Entity("Expect.Schedule.Domain.Models.Classroom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Hull")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Classrooms");
                });

            modelBuilder.Entity("Expect.Schedule.Domain.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AdditionalId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClassroomId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("DayId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<TimeSpan>("TimeEnd")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("TimeStart")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalId");

                    b.HasIndex("ClassroomId");

                    b.HasIndex("DayId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Expect.Schedule.Domain.Models.Day", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer");

                    b.Property<Guid?>("TimetableId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TimetableId");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("Expect.Schedule.Domain.Models.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Expect.Schedule.Domain.Models.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Institute")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Expect.Schedule.Domain.Models.Timetable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Timetables");
                });

            modelBuilder.Entity("Expect.Schedule.Domain.Models.Course", b =>
                {
                    b.HasOne("Expect.Schedule.Domain.Models.Additional", "Additional")
                        .WithMany()
                        .HasForeignKey("AdditionalId");

                    b.HasOne("Expect.Schedule.Domain.Models.Classroom", "Classroom")
                        .WithMany()
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Expect.Schedule.Domain.Models.Day", null)
                        .WithMany("Courses")
                        .HasForeignKey("DayId");

                    b.HasOne("Expect.Schedule.Domain.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Expect.Schedule.Domain.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Additional");

                    b.Navigation("Classroom");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Expect.Schedule.Domain.Models.Day", b =>
                {
                    b.HasOne("Expect.Schedule.Domain.Models.Timetable", null)
                        .WithMany("Days")
                        .HasForeignKey("TimetableId");
                });

            modelBuilder.Entity("Expect.Schedule.Domain.Models.Day", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Expect.Schedule.Domain.Models.Timetable", b =>
                {
                    b.Navigation("Days");
                });
#pragma warning restore 612, 618
        }
    }
}
