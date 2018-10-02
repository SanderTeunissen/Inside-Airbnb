using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace InsideAirBNB.App.Data.Migrations
{
    public partial class MoveHostDataIntoOwnObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    About = table.Column<string>(nullable: true),
                    AcceptanceRate = table.Column<string>(nullable: true),
                    HasProfilePic = table.Column<string>(nullable: true),
                    IdentityVerified = table.Column<string>(nullable: true),
                    IsSuperhost = table.Column<string>(nullable: true),
                    ListingsCount = table.Column<int>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Neighbourhood = table.Column<string>(nullable: true),
                    PictureUrl = table.Column<string>(nullable: true),
                    ResponseRate = table.Column<string>(nullable: true),
                    ResponseTime = table.Column<string>(nullable: true),
                    Since = table.Column<DateTime>(nullable: true),
                    ThumbnailUrl = table.Column<string>(nullable: true),
                    TotalListingsCount = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Verifications = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosts", x => x.Id);
                });

            migrationBuilder.Sql(@"
                SET IDENTITY_INSERT Hosts ON;
                INSERT INTO Hosts (Id, Name, About, AcceptanceRate, HasProfilePic, IdentityVerified, IsSuperhost, ListingsCount, Location, Neighbourhood, PictureUrl, ResponseRate, ResponseTime, Since, ThumbnailUrl, TotalListingsCount, Url, Verifications) 
                SELECT HostId, HostName, HostAbout, HostAcceptanceRate, HostHasProfilePic, HostIdentityVerified, HostIsSuperhost, HostListingsCount, HostLocation, HostNeighbourhood, HostPictureUrl, HostResponseRate, HostResponseTime, HostSince, HostThumbnailUrl, HostTotalListingsCount, HostUrl, HostVerifications 
                FROM (SELECT ROW_NUMBER()OVER(PARTITION BY HostId ORDER BY HostId) as RN, *
                FROM Listings) as x
                WHERE x.RN = 1;
                SET IDENTITY_INSERT Hosts OFF;
            ");

            migrationBuilder.DropColumn(
                name: "HostAbout",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HostAcceptanceRate",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HostHasProfilePic",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HostIdentityVerified",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HostIsSuperhost",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HostListingsCount",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HostLocation",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HostName",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HostNeighbourhood",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HostPictureUrl",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HostResponseRate",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HostResponseTime",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HostSince",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HostThumbnailUrl",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HostTotalListingsCount",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HostUrl",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HostVerifications",
                table: "Listings");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_HostId",
                table: "Listings",
                column: "HostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Hosts_HostId",
                table: "Listings",
                column: "HostId",
                principalTable: "Hosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HostAbout",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostAcceptanceRate",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostHasProfilePic",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostIdentityVerified",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostIsSuperhost",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HostListingsCount",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostLocation",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostName",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostNeighbourhood",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostPictureUrl",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostResponseRate",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostResponseTime",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HostSince",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostThumbnailUrl",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HostTotalListingsCount",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostUrl",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostVerifications",
                table: "Listings",
                nullable: true);

            migrationBuilder.Sql(@"
                UPDATE Listings 
                SET HostName = Name, HostAbout = About, HostAcceptanceRate = AcceptanceRate, HostHasProfilePic = HasProfilePic, HostIdentityVerified = IdentityVerified, HostIsSuperhost = IsSuperhost, HostListingsCount = ListingsCount, HostLocation = Location, HostNeighbourhood = Neighbourhood, HostPictureUrl = PictureUrl, HostResponseRate = ResponseRate, HostResponseTime = ResponseTime, HostSince = Since, HostThumbnailUrl = ThumbnailUrl, HostTotalListingsCount = TotalListingsCount, HostUrl = Url, HostVerifications = Verifications
                FROM Listings as l INNER JOIN Hosts as h ON l.HostId = h.Id
            ");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Hosts_HostId",
                table: "Listings");

            migrationBuilder.DropTable(
                name: "Hosts");

            migrationBuilder.DropIndex(
                name: "IX_Listings_HostId",
                table: "Listings");
        }
    }
}
