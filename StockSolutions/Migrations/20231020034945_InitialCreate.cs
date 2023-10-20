﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockSolutions.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chemical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Formula = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chemical", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bottle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChemicalId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<float>(type: "REAL", nullable: false),
                    AmountUnits = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bottle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bottle_Chemical_ChemicalId",
                        column: x => x.ChemicalId,
                        principalTable: "Chemical",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bottle_ChemicalId",
                table: "Bottle",
                column: "ChemicalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bottle");

            migrationBuilder.DropTable(
                name: "Chemical");
        }
    }
}
