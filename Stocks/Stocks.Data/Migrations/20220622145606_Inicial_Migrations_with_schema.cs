using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stock.Data.Migrations
{
    public partial class Inicial_Migrations_with_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "query");

            migrationBuilder.CreateTable(
                name: "QueryMovements",
                schema: "query",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Origin = table.Column<int>(type: "int", nullable: false),
                    OriginId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueryMovements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QueryProductsMovement",
                schema: "query",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovementsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategory = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StorageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StorageDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueryProductsMovement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QueryProductsMovements_MovementsId_Movements_Id",
                        column: x => x.MovementsId,
                        principalSchema: "query",
                        principalTable: "QueryMovements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QueryProductsMovement_MovementsId",
                schema: "query",
                table: "QueryProductsMovement",
                column: "MovementsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QueryProductsMovement",
                schema: "query");

            migrationBuilder.DropTable(
                name: "QueryMovements",
                schema: "query");
        }
    }
}
