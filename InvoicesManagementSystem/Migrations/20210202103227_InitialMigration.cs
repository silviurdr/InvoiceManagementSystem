using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoicesManagementSystem.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locatii",
                columns: table => new
                {
                    IdLocatie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locatii", x => x.IdLocatie);
                });

            migrationBuilder.CreateTable(
                name: "Facturi",
                columns: table => new
                {
                    IdFactura = table.Column<int>(type: "int", nullable: false),
                    IdLocatie = table.Column<int>(type: "int", nullable: false),
                    NumarFactura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataFactura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeClient = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturi", x => new { x.IdFactura, x.IdLocatie });
                    table.ForeignKey(
                        name: "FK_Facturi_Locatii_IdLocatie",
                        column: x => x.IdLocatie,
                        principalTable: "Locatii",
                        principalColumn: "IdLocatie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetaliiFacturi",
                columns: table => new
                {
                    IdDetaliiFactura = table.Column<int>(type: "int", nullable: false),
                    IdLocatie = table.Column<int>(type: "int", nullable: false),
                    NumeProdus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantitate = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PretUnitar = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Valoare = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IdFactura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetaliiFacturi", x => new { x.IdDetaliiFactura, x.IdLocatie });
                    table.ForeignKey(
                        name: "FK_DetaliiFacturi_Facturi_IdFactura_IdLocatie",
                        columns: x => new { x.IdFactura, x.IdLocatie },
                        principalTable: "Facturi",
                        principalColumns: new[] { "IdFactura", "IdLocatie" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetaliiFacturi_Locatii_IdLocatie",
                        column: x => x.IdLocatie,
                        principalTable: "Locatii",
                        principalColumn: "IdLocatie",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetaliiFacturi_IdFactura_IdLocatie",
                table: "DetaliiFacturi",
                columns: new[] { "IdFactura", "IdLocatie" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetaliiFacturi_IdLocatie",
                table: "DetaliiFacturi",
                column: "IdLocatie");

            migrationBuilder.CreateIndex(
                name: "IX_Facturi_IdLocatie",
                table: "Facturi",
                column: "IdLocatie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetaliiFacturi");

            migrationBuilder.DropTable(
                name: "Facturi");

            migrationBuilder.DropTable(
                name: "Locatii");
        }
    }
}
