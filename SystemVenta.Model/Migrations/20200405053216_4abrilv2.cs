using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemVenta.Model.Migrations
{
    public partial class _4abrilv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Providers_ProviderId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "PrividerId",
                table: "Entries");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderId",
                table: "Entries",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Providers_ProviderId",
                table: "Entries",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Providers_ProviderId",
                table: "Entries");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderId",
                table: "Entries",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PrividerId",
                table: "Entries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Providers_ProviderId",
                table: "Entries",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
