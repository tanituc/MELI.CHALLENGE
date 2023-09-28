using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge.Data.Migrations
{
    public partial class ModifyEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmmount",
                table: "Payments");

            migrationBuilder.AddColumn<double>(
                name: "Ammount",
                table: "Payments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AmmountUSD",
                table: "Payments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ammount",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "AmmountUSD",
                table: "Payments");

            migrationBuilder.AddColumn<float>(
                name: "TotalAmmount",
                table: "Payments",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
