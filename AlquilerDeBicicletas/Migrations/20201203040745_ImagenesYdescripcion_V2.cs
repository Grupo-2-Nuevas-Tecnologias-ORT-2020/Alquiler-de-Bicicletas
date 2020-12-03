using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlquilerDeBicicletas.Migrations
{
    public partial class ImagenesYdescripcion_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagen",
                table: "TiposDeBici");

            migrationBuilder.DropColumn(
                name: "imagen",
                table: "TiposDeAccesorio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "imagen",
                table: "TiposDeBici",
                type: "image",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "imagen",
                table: "TiposDeAccesorio",
                type: "image",
                nullable: true);
        }
    }
}
