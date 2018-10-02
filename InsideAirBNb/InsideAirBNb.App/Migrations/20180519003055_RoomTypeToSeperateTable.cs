using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsideAirBNB.App.Data.Migrations
{
    public partial class RoomTypeToSeperateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Color = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.Sql("INSERT INTO RoomTypes (Name,Color) SELECT RoomType, '#7B7B7B' FROM Listings GROUP BY RoomType");

            migrationBuilder.AddColumn<int>(
                name: "RoomTypeId",
                table: "Listings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE Listings SET RoomTypeId = (SELECT Id FROM RoomTypes WHERE Name = RoomType)");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_RoomTypeId",
                table: "Listings",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_RoomTypes_RoomTypeId",
                table: "Listings",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.DropColumn(
                name: "RoomType",
                table: "Listings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomType",
                table: "Listings",
                nullable: true);

            migrationBuilder.Sql("UPDATE Listings SET RoomType = (SELECT Name FROM RoomTypes WHERE Id = RoomTypeId)");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_RoomTypes_RoomTypeId",
                table: "Listings");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "Listings");
        }
    }
}
