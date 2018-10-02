using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsideAirBNB.App.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ListingUrl = table.Column<string>(nullable: true),
                    ScrapeId = table.Column<double>(nullable: false),
                    LastScraped = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Space = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ExperiencesOffered = table.Column<string>(nullable: true),
                    NeighborhoodOverview = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Transit = table.Column<string>(nullable: true),
                    Access = table.Column<string>(nullable: true),
                    Interaction = table.Column<string>(nullable: true),
                    HouseRules = table.Column<string>(nullable: true),
                    ThumbnailUrl = table.Column<string>(nullable: true),
                    MediumUrl = table.Column<string>(nullable: true),
                    PictureUrl = table.Column<string>(nullable: true),
                    XlPictureUrl = table.Column<string>(nullable: true),
                    HostId = table.Column<int>(nullable: false),
                    HostUrl = table.Column<string>(nullable: true),
                    HostName = table.Column<string>(nullable: true),
                    HostSince = table.Column<DateTime>(nullable: true),
                    HostLocation = table.Column<string>(nullable: true),
                    HostAbout = table.Column<string>(nullable: true),
                    HostResponseTime = table.Column<string>(nullable: true),
                    HostResponseRate = table.Column<string>(nullable: true),
                    HostAcceptanceRate = table.Column<string>(nullable: true),
                    HostIsSuperhost = table.Column<string>(nullable: true),
                    HostThumbnailUrl = table.Column<string>(nullable: true),
                    HostPictureUrl = table.Column<string>(nullable: true),
                    HostNeighbourhood = table.Column<string>(nullable: true),
                    HostListingsCount = table.Column<int>(nullable: true),
                    HostTotalListingsCount = table.Column<int>(nullable: true),
                    HostVerifications = table.Column<string>(nullable: true),
                    HostHasProfilePic = table.Column<string>(nullable: true),
                    HostIdentityVerified = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Neighbourhood = table.Column<string>(nullable: true),
                    NeighbourhoodCleansed = table.Column<string>(nullable: true),
                    NeighbourhoodGroupCleansed = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    Market = table.Column<string>(nullable: true),
                    SmartLocation = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    IsLocationExact = table.Column<string>(nullable: true),
                    PropertyType = table.Column<string>(nullable: true),
                    RoomType = table.Column<string>(nullable: true),
                    Accommodates = table.Column<int>(nullable: true),
                    Bathrooms = table.Column<double>(nullable: true),
                    Bedrooms = table.Column<int>(nullable: true),
                    Beds = table.Column<int>(nullable: true),
                    BedType = table.Column<string>(nullable: true),
                    Amenities = table.Column<string>(nullable: true),
                    SquareFeet = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    WeeklyPrice = table.Column<string>(nullable: true),
                    MonthlyPrice = table.Column<string>(nullable: true),
                    SecurityDeposit = table.Column<string>(nullable: true),
                    CleaningFee = table.Column<string>(nullable: true),
                    GuestsIncluded = table.Column<int>(nullable: true),
                    ExtraPeople = table.Column<string>(nullable: true),
                    MinimumNights = table.Column<int>(nullable: true),
                    MaximumNights = table.Column<int>(nullable: true),
                    CalendarUpdated = table.Column<string>(nullable: true),
                    HasAvailability = table.Column<string>(nullable: true),
                    Availability30 = table.Column<int>(nullable: true),
                    Availability60 = table.Column<int>(nullable: true),
                    Availability90 = table.Column<int>(nullable: true),
                    Availability365 = table.Column<int>(nullable: true),
                    CalendarLastScraped = table.Column<DateTime>(nullable: true),
                    NumberOfReviews = table.Column<int>(nullable: true),
                    FirstReview = table.Column<DateTime>(nullable: true),
                    LastReview = table.Column<DateTime>(nullable: true),
                    ReviewScoresRating = table.Column<int>(nullable: true),
                    ReviewScoresAccuracy = table.Column<int>(nullable: true),
                    ReviewScoresCleanliness = table.Column<int>(nullable: true),
                    ReviewScoresCheckin = table.Column<int>(nullable: true),
                    ReviewScoresCommunication = table.Column<int>(nullable: true),
                    ReviewScoresLocation = table.Column<int>(nullable: true),
                    ReviewScoresValue = table.Column<int>(nullable: true),
                    RequiresLicense = table.Column<string>(nullable: true),
                    License = table.Column<string>(nullable: true),
                    JurisdictionNames = table.Column<string>(nullable: true),
                    InstantBookable = table.Column<string>(nullable: true),
                    IsBusinessTravelReady = table.Column<string>(nullable: true),
                    CancellationPolicy = table.Column<string>(nullable: true),
                    RequireGuestProfilePicture = table.Column<string>(nullable: true),
                    RequireGuestPhoneVerification = table.Column<string>(nullable: true),
                    CalculatedHostListingsCount = table.Column<int>(nullable: false),
                    ReviewsPerMonth = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Neighbourhoods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NeighbourhoodGroup = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighbourhoods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SummaryListings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    HostId = table.Column<int>(nullable: false),
                    HostName = table.Column<string>(nullable: true),
                    NeighbourhoodGroup = table.Column<string>(nullable: true),
                    Neighbourhood = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    RoomType = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: true),
                    MinimumNights = table.Column<int>(nullable: true),
                    NumberOfReviews = table.Column<int>(nullable: true),
                    LastReview = table.Column<DateTime>(nullable: true),
                    ReviewsPerMonth = table.Column<double>(nullable: true),
                    CalculatedHostListingsCount = table.Column<int>(nullable: true),
                    Availability365 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryListings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SummaryReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ListingId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryReviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ListingId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Available = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendars_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ListingId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ReviewerId = table.Column<int>(nullable: false),
                    ReviewerName = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_ListingId",
                table: "Calendars",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ListingId",
                table: "Reviews",
                column: "ListingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "Neighbourhoods");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "SummaryListings");

            migrationBuilder.DropTable(
                name: "SummaryReviews");

            migrationBuilder.DropTable(
                name: "Listings");
        }
    }
}
