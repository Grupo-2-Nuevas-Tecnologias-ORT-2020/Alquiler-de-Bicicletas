using Microsoft.EntityFrameworkCore.Migrations;

namespace AlquilerDeBicicletas.Migrations.AlquilerDeBicicletas
{
    public partial class RetoquePersonalData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "eMailAdress",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "eMailAdress",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
