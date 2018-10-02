using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InsideAirBNB.App.Migrations
{
    public partial class AddPictureUrlToSummaryListing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "SummaryListings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.Sql("UPDATE SummaryListings SET PictureUrl = (select PictureUrl from Listings WHERE Listings.Id = SummaryListings.Id)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "SummaryListings");
        }
    }
}
