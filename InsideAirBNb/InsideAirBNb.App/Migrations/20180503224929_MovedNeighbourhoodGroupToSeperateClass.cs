using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsideAirBNB.App.Data.Migrations
{
    public partial class MovedNeighbourhoodGroupToSeperateClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NeighbourhoodGroupID",
                table: "Neighbourhoods",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NeighbourhoodGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeighbourhoodGroups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Neighbourhoods_NeighbourhoodGroupID",
                table: "Neighbourhoods",
                column: "NeighbourhoodGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Neighbourhoods_NeighbourhoodGroups_NeighbourhoodGroupID",
                table: "Neighbourhoods",
                column: "NeighbourhoodGroupID",
                principalTable: "NeighbourhoodGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql("IF EXISTS (SELECT * FROM Neighbourhoods WHERE NeighbourhoodGroup IS NOT NULL) BEGIN INSERT INTO dbo.NeighbourhoodGroups (Name) SELECT NeighbourhoodGroup FROM Neighbourhoods GROUP BY NeighbourhoodGroup END");

            migrationBuilder.Sql("UPDATE Neighbourhoods SET NeighbourhoodGroupID = (SELECT Id FROM NeighbourhoodGroups WHERE Name = NeighbourhoodGroup) WHERE NeighbourhoodGroup IS NOT NULL;");

            migrationBuilder.DropColumn(
                name: "NeighbourhoodGroup",
                table: "Neighbourhoods");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Neighbourhoods_NeighbourhoodGroups_NeighbourhoodGroupID",
                table: "Neighbourhoods");

            migrationBuilder.DropTable(
                name: "NeighbourhoodGroups");

            migrationBuilder.DropIndex(
                name: "IX_Neighbourhoods_NeighbourhoodGroupID",
                table: "Neighbourhoods");

            migrationBuilder.DropColumn(
                name: "NeighbourhoodGroupID",
                table: "Neighbourhoods");

            migrationBuilder.AddColumn<string>(
                name: "NeighbourhoodGroup",
                table: "Neighbourhoods",
                nullable: true);
        }
    }
}
