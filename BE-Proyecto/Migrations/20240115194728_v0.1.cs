using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_Proyecto.Migrations
{
    public partial class v01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "Cotizaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipo",
                table: "Cotizaciones");
        }
    }
}
