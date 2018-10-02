﻿// <auto-generated />
using InsideAirBNB.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace InsideAirBNB.App.Migrations
{
    [DbContext(typeof(InsideAirBNBContext))]
    [Migration("20180615203127_AddRoomTypeReferenceToSummaryListing")]
    partial class AddRoomTypeReferenceToSummaryListing
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InsideAirBNB.App.Models.Calendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Available");

                    b.Property<DateTime>("Date");

                    b.Property<int>("ListingId");

                    b.Property<string>("Price");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.ToTable("Calendars");
                });

            modelBuilder.Entity("InsideAirBNB.App.Models.Host", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About");

                    b.Property<string>("AcceptanceRate");

                    b.Property<string>("HasProfilePic");

                    b.Property<string>("IdentityVerified");

                    b.Property<string>("IsSuperhost");

                    b.Property<int?>("ListingsCount");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<string>("Neighbourhood");

                    b.Property<string>("PictureUrl");

                    b.Property<string>("ResponseRate");

                    b.Property<string>("ResponseTime");

                    b.Property<DateTime?>("Since");

                    b.Property<string>("ThumbnailUrl");

                    b.Property<int?>("TotalListingsCount");

                    b.Property<string>("Url");

                    b.Property<string>("Verifications");

                    b.HasKey("Id");

                    b.ToTable("Hosts");
                });

            modelBuilder.Entity("InsideAirBNB.App.Models.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("InsideAirBNB.App.Models.Listing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Access");

                    b.Property<int?>("Accommodates");

                    b.Property<string>("Amenities");

                    b.Property<int?>("Availability30");

                    b.Property<int?>("Availability365");

                    b.Property<int?>("Availability60");

                    b.Property<int?>("Availability90");

                    b.Property<double?>("Bathrooms");

                    b.Property<string>("BedType");

                    b.Property<int?>("Bedrooms");

                    b.Property<int?>("Beds");

                    b.Property<int>("CalculatedHostListingsCount");

                    b.Property<DateTime?>("CalendarLastScraped");

                    b.Property<string>("CalendarUpdated");

                    b.Property<string>("CancellationPolicy");

                    b.Property<string>("City");

                    b.Property<string>("CleaningFee");

                    b.Property<string>("Country");

                    b.Property<string>("CountryCode");

                    b.Property<string>("Description");

                    b.Property<string>("ExperiencesOffered");

                    b.Property<string>("ExtraPeople");

                    b.Property<DateTime?>("FirstReview");

                    b.Property<int?>("GuestsIncluded");

                    b.Property<string>("HasAvailability");

                    b.Property<int>("HostId");

                    b.Property<string>("HouseRules");

                    b.Property<string>("InstantBookable");

                    b.Property<string>("Interaction");

                    b.Property<string>("IsBusinessTravelReady");

                    b.Property<string>("IsLocationExact");

                    b.Property<string>("JurisdictionNames");

                    b.Property<DateTime?>("LastReview");

                    b.Property<DateTime>("LastScraped");

                    b.Property<double?>("Latitude");

                    b.Property<string>("License");

                    b.Property<string>("ListingUrl");

                    b.Property<double?>("Longitude");

                    b.Property<string>("Market");

                    b.Property<int?>("MaximumNights");

                    b.Property<string>("MediumUrl");

                    b.Property<int?>("MinimumNights");

                    b.Property<string>("MonthlyPrice");

                    b.Property<string>("Name");

                    b.Property<string>("NeighborhoodOverview");

                    b.Property<string>("Neighbourhood");

                    b.Property<string>("NeighbourhoodCleansed");

                    b.Property<string>("NeighbourhoodGroupCleansed");

                    b.Property<string>("Notes");

                    b.Property<int?>("NumberOfReviews");

                    b.Property<string>("PictureUrl");

                    b.Property<string>("Price");

                    b.Property<string>("PropertyType");

                    b.Property<string>("RequireGuestPhoneVerification");

                    b.Property<string>("RequireGuestProfilePicture");

                    b.Property<string>("RequiresLicense");

                    b.Property<int?>("ReviewScoresAccuracy");

                    b.Property<int?>("ReviewScoresCheckin");

                    b.Property<int?>("ReviewScoresCleanliness");

                    b.Property<int?>("ReviewScoresCommunication");

                    b.Property<int?>("ReviewScoresLocation");

                    b.Property<int?>("ReviewScoresRating");

                    b.Property<int?>("ReviewScoresValue");

                    b.Property<double?>("ReviewsPerMonth");

                    b.Property<int>("RoomTypeId");

                    b.Property<double>("ScrapeId");

                    b.Property<string>("SecurityDeposit");

                    b.Property<string>("SmartLocation");

                    b.Property<string>("Space");

                    b.Property<string>("SquareFeet");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<string>("Summary");

                    b.Property<string>("ThumbnailUrl");

                    b.Property<string>("Transit");

                    b.Property<string>("WeeklyPrice");

                    b.Property<string>("XlPictureUrl");

                    b.Property<string>("Zipcode");

                    b.HasKey("Id");

                    b.HasIndex("HostId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("InsideAirBNB.App.Models.Neighbourhood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("NeighbourhoodGroupID");

                    b.HasKey("Id");

                    b.HasIndex("NeighbourhoodGroupID");

                    b.ToTable("Neighbourhoods");
                });

            modelBuilder.Entity("InsideAirBNB.App.Models.NeighbourhoodGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("NeighbourhoodGroups");
                });

            modelBuilder.Entity("InsideAirBNB.App.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments");

                    b.Property<DateTime>("Date");

                    b.Property<int>("ListingId");

                    b.Property<int>("ReviewerId");

                    b.Property<string>("ReviewerName");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("InsideAirBNB.App.Models.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("InsideAirBNB.App.Models.SummaryListing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Availability365");

                    b.Property<int?>("CalculatedHostListingsCount");

                    b.Property<int>("HostId");

                    b.Property<string>("HostName");

                    b.Property<DateTime?>("LastReview");

                    b.Property<double?>("Latitude");

                    b.Property<double?>("Longitude");

                    b.Property<int?>("MinimumNights");

                    b.Property<string>("Name");

                    b.Property<string>("Neighbourhood");

                    b.Property<string>("NeighbourhoodGroup");

                    b.Property<int?>("NumberOfReviews");

                    b.Property<int?>("Price");

                    b.Property<double?>("ReviewsPerMonth");

                    b.Property<int>("RoomTypeId");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("SummaryListings");
                });

            modelBuilder.Entity("InsideAirBNB.App.Models.SummaryReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("ListingId");

                    b.HasKey("Id");

                    b.ToTable("SummaryReviews");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("InsideAirBNB.App.Models.Calendar", b =>
                {
                    b.HasOne("InsideAirBNB.App.Models.Listing", "Listing")
                        .WithMany("Calendar")
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InsideAirBNB.App.Models.Listing", b =>
                {
                    b.HasOne("InsideAirBNB.App.Models.Host", "Host")
                        .WithMany("Listings")
                        .HasForeignKey("HostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InsideAirBNB.App.Models.RoomType", "RoomType")
                        .WithMany("Listings")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InsideAirBNB.App.Models.Neighbourhood", b =>
                {
                    b.HasOne("InsideAirBNB.App.Models.NeighbourhoodGroup", "NeighbourhoodGroup")
                        .WithMany("Neighbourhoods")
                        .HasForeignKey("NeighbourhoodGroupID");
                });

            modelBuilder.Entity("InsideAirBNB.App.Models.Review", b =>
                {
                    b.HasOne("InsideAirBNB.App.Models.Listing", "Listing")
                        .WithMany("Reviews")
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InsideAirBNB.App.Models.SummaryListing", b =>
                {
                    b.HasOne("InsideAirBNB.App.Models.RoomType", "RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("InsideAirBNB.App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("InsideAirBNB.App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InsideAirBNB.App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("InsideAirBNB.App.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
