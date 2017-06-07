using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OnlineShop.Models;

namespace OnlineShop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20170607022039_AddShoppedTour")]
    partial class AddShoppedTour
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("OnlineShop.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<string>("Description");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("OnlineShop.Models.ShoppedTour", b =>
                {
                    b.Property<int>("ShoppedTourId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<string>("TourCartId");

                    b.Property<int?>("TourId");

                    b.HasKey("ShoppedTourId");

                    b.HasIndex("TourId");

                    b.ToTable("ShoppedTours");
                });

            modelBuilder.Entity("OnlineShop.Models.Tour", b =>
                {
                    b.Property<int>("TourId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("ImageThumbnailUrl");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsTourOfTheWeek");

                    b.Property<string>("LongDescription");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<bool>("SeatsAvailable");

                    b.Property<string>("ShortDescription");

                    b.HasKey("TourId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("OnlineShop.Models.ShoppedTour", b =>
                {
                    b.HasOne("OnlineShop.Models.Tour", "Tour")
                        .WithMany()
                        .HasForeignKey("TourId");
                });

            modelBuilder.Entity("OnlineShop.Models.Tour", b =>
                {
                    b.HasOne("OnlineShop.Models.Category", "Category")
                        .WithMany("Tours")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
