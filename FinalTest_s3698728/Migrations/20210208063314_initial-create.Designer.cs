// <auto-generated />
using System;
using FinalTest_s3698728.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinalTest_s3698728.Migrations
{
    [DbContext(typeof(BookingContext))]
    [Migration("20210208063314_initial-create")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("FinalTest_s3698728.Models.Bookings", b =>
                {
                    b.Property<string>("RoomID")
                        .HasColumnType("nvarchar(8)");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StaffID")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.HasKey("RoomID");

                    b.HasIndex("StaffID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("FinalTest_s3698728.Models.Rooms", b =>
                {
                    b.Property<string>("RoomID")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<bool>("HasProjector")
                        .HasColumnType("bit");

                    b.HasKey("RoomID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("FinalTest_s3698728.Models.Staff", b =>
                {
                    b.Property<string>("StaffID")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("MobilePhone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("StaffID");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("FinalTest_s3698728.Models.Bookings", b =>
                {
                    b.HasOne("FinalTest_s3698728.Models.Rooms", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalTest_s3698728.Models.Staff", "Staff")
                        .WithMany("Bookings")
                        .HasForeignKey("StaffID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("FinalTest_s3698728.Models.Rooms", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("FinalTest_s3698728.Models.Staff", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
