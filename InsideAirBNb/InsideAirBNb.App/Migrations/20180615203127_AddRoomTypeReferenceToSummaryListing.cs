using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InsideAirBNB.App.Migrations
{
    public partial class AddRoomTypeReferenceToSummaryListing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomTypeId",
                table: "SummaryListings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE SummaryListings SET RoomTypeId = (SELECT Id FROM RoomTypes WHERE Name = RoomType)");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryListings_RoomTypeId",
                table: "SummaryListings",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryListings_RoomTypes_RoomTypeId",
                table: "SummaryListings",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.DropColumn(
                name: "RoomType",
                table: "SummaryListings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomType",
                table: "SummaryListings",
                nullable: true);

            migrationBuilder.Sql("UPDATE SummaryListings SET RoomType = (SELECT Name FROM RoomTypes WHERE Id = RoomTypeId)");

            migrationBuilder.DropForeignKey(
                name: "FK_SummaryListings_RoomTypes_RoomTypeId",
                table: "SummaryListings");

            migrationBuilder.DropIndex(
                name: "IX_SummaryListings_RoomTypeId",
                table: "SummaryListings");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "SummaryListings");
        }
    }
}
