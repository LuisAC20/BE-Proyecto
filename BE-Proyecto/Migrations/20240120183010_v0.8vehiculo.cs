using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_Proyecto.Migrations
{
    public partial class v08vehiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Vehiculos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Placa",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Vehiculos");
        }
    }
}
