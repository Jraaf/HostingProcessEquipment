using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AreaFloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Equipments");
            migrationBuilder.AddColumn<double>(
                name: "Area",
                table: "Equipments",
                type: "float",
                nullable: true);
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Facilities");
            migrationBuilder.AddColumn<double>(
                name: "Area",
                table: "Facilities",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Facilities");
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Equipments");
        }

    }
}
