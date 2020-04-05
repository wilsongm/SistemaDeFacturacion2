using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemVenta.Model.Migrations
{
    public partial class _4abrilv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Stocks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Entries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Entries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProviderName",
                table: "Entries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "ProviderName",
                table: "Entries");
        }
    }
}
