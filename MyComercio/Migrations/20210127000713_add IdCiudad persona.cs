using Microsoft.EntityFrameworkCore.Migrations;

namespace MyComercio.Migrations
{
    public partial class addIdCiudadpersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCiudad",
                table: "Persona",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCiudad",
                table: "Persona");
        }
    }
}
