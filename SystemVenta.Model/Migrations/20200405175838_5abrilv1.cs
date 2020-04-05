using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemVenta.Model.Migrations
{
    public partial class _5abrilv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Billings",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Billings");
        }
    }
}
