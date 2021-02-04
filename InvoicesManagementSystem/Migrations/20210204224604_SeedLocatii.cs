using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceManagementSystem.Migrations
{
    public partial class SeedLocatii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locatii",
                columns: new[] { "IdLocatie", "Adresa", "Nume" },
                values: new object[] { 1, "Strada Muresenilor", "Brasov" });

            migrationBuilder.InsertData(
                table: "Locatii",
                columns: new[] { "IdLocatie", "Adresa", "Nume" },
                values: new object[] { 2, "Strada Balcescu", "Bucuresti" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locatii",
                keyColumn: "IdLocatie",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locatii",
                keyColumn: "IdLocatie",
                keyValue: 2);
        }
    }
}
