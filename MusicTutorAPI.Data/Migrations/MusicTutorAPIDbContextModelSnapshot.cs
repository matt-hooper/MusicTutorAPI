﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicTutorAPI.Data;

namespace MusicTutorAPI.Data.Migrations
{
    [DbContext(typeof(MusicTutorAPIDbContext))]
    partial class MusicTutorAPIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MusicTutorAPI.Core.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("MusicTutorAPI.Core.Models.Instrument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Instruments");
                });

            modelBuilder.Entity("MusicTutorAPI.Core.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("InstrumentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPlanned")
                        .HasColumnType("bit");

                    b.Property<int>("PupilId")
                        .HasColumnType("int");

                    b.Property<int?>("PupilId1")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("InstrumentId");

                    b.HasIndex("PupilId");

                    b.HasIndex("PupilId1");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("MusicTutorAPI.Core.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PupilId")
                        .HasColumnType("int");

                    b.Property<int?>("PupilId1")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PupilId");

                    b.HasIndex("PupilId1");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("MusicTutorAPI.Core.Models.Pupil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AccountBalance")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<int>("ContactID")
                        .HasColumnType("int");

                    b.Property<decimal>("CurrentLessonRate")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<int>("FrequencyInDays")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("ContactID");

                    b.ToTable("Pupils");
                });

            modelBuilder.Entity("MusicTutorAPI.Core.Models.PupilInstrument", b =>
                {
                    b.Property<int>("PupilId")
                        .HasColumnType("int");

                    b.Property<int>("InstrumentId")
                        .HasColumnType("int");

                    b.HasKey("PupilId", "InstrumentId");

                    b.HasIndex("InstrumentId");

                    b.ToTable("PupilInstrument");
                });

            modelBuilder.Entity("MusicTutorAPI.Core.Models.Lesson", b =>
                {
                    b.HasOne("MusicTutorAPI.Core.Models.Instrument", "Instrument")
                        .WithMany()
                        .HasForeignKey("InstrumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicTutorAPI.Core.Models.Pupil", null)
                        .WithMany("Lessons")
                        .HasForeignKey("PupilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicTutorAPI.Core.Models.Pupil", "Pupil")
                        .WithMany()
                        .HasForeignKey("PupilId1");
                });

            modelBuilder.Entity("MusicTutorAPI.Core.Models.Payment", b =>
                {
                    b.HasOne("MusicTutorAPI.Core.Models.Pupil", null)
                        .WithMany("Payments")
                        .HasForeignKey("PupilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicTutorAPI.Core.Models.Pupil", "Pupil")
                        .WithMany()
                        .HasForeignKey("PupilId1");
                });

            modelBuilder.Entity("MusicTutorAPI.Core.Models.Pupil", b =>
                {
                    b.HasOne("MusicTutorAPI.Core.Models.Contact", "Contact")
                        .WithMany("Pupils")
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MusicTutorAPI.Core.Models.PupilInstrument", b =>
                {
                    b.HasOne("MusicTutorAPI.Core.Models.Instrument", "Instrument")
                        .WithMany("PupilInstruments")
                        .HasForeignKey("InstrumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicTutorAPI.Core.Models.Pupil", "Pupil")
                        .WithMany("PupilInstruments")
                        .HasForeignKey("PupilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}