using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemVenta.Model.Migrations
{
    public partial class _5abrilv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProducName",
                table: "Billings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProducName",
                table: "Billings");
        }
    }
}
