using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlquilerDeBicicletas.Migrations
{
    public partial class ImagenesYdescripcion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "descripcion",
                table: "TiposDeBici",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descripcion",
                table: "TiposDeBici");

            migrationBuilder.DropColumn(
                name: "imagen",
                table: "TiposDeBici");

            migrationBuilder.DropColumn(
                name: "imagen",
                table: "TiposDeAccesorio");
        }
    }
}
