using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlquilerDeBicicletas.Migrations.AlquilerDeBicicletas
{
    public partial class ModeloDeDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "contrasena",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "TiposDeAccesorio",
                columns: table => new
                {
                    tipoDeAccesorioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    precioBase = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDeAccesorio", x => x.tipoDeAccesorioID);
                });

            migrationBuilder.CreateTable(
                name: "TiposDeBici",
                columns: table => new
                {
                    tipoDeBiciID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    precioBase = table.Column<double>(nullable: false),
                    descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDeBici", x => x.tipoDeBiciID);
                });

            migrationBuilder.CreateTable(
                name: "Accesorios",
                columns: table => new
                {
                    accesorioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fechaDeIngreso = table.Column<DateTime>(nullable: false),
                    color = table.Column<string>(nullable: true),
                    tipoDeAccesorioID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesorios", x => x.accesorioID);
                    table.ForeignKey(
                        name: "FK_Accesorios_TiposDeAccesorio_tipoDeAccesorioID",
                        column: x => x.tipoDeAccesorioID,
                        principalTable: "TiposDeAccesorio",
                        principalColumn: "tipoDeAccesorioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bicicletas",
                columns: table => new
                {
                    bicicletaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fechaDeIngreso = table.Column<DateTime>(nullable: false),
                    color = table.Column<string>(nullable: true),
                    tipoDeBiciID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicicletas", x => x.bicicletaID);
                    table.ForeignKey(
                        name: "FK_Bicicletas_TiposDeBici_tipoDeBiciID",
                        column: x => x.tipoDeBiciID,
                        principalTable: "TiposDeBici",
                        principalColumn: "tipoDeBiciID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alquileres",
                columns: table => new
                {
                    alquilerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    estadoAlquiler = table.Column<int>(nullable: false),
                    fechaDesde = table.Column<DateTime>(nullable: false),
                    fechaHasta = table.Column<DateTime>(nullable: false),
                    cambioFecha = table.Column<bool>(nullable: false),
                    horasBase = table.Column<int>(nullable: false),
                    fechaEntregaFinal = table.Column<DateTime>(nullable: false),
                    horasExtras = table.Column<int>(nullable: false),
                    totalAPagarBase = table.Column<double>(nullable: false),
                    totalAPagarExtra = table.Column<double>(nullable: false),
                    AlquilerDeBicicletasUsers_ID = table.Column<string>(nullable: true),
                    AlquilerDeBicicletasUsersId = table.Column<string>(nullable: true),
                    bicicletaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquileres", x => x.alquilerID);
                    table.ForeignKey(
                        name: "FK_Alquileres_AspNetUsers_AlquilerDeBicicletasUsersId",
                        column: x => x.AlquilerDeBicicletasUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alquileres_Bicicletas_bicicletaID",
                        column: x => x.bicicletaID,
                        principalTable: "Bicicletas",
                        principalColumn: "bicicletaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlquilerAccesorio",
                columns: table => new
                {
                    alquilerID = table.Column<int>(nullable: false),
                    accesorioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlquilerAccesorio", x => new { x.alquilerID, x.accesorioID });
                    table.UniqueConstraint("AK_AlquilerAccesorio_alquilerID", x => x.alquilerID);
                    table.ForeignKey(
                        name: "FK_AlquilerAccesorio_Accesorios_accesorioID",
                        column: x => x.accesorioID,
                        principalTable: "Accesorios",
                        principalColumn: "accesorioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlquilerAccesorio_Alquileres_alquilerID",
                        column: x => x.alquilerID,
                        principalTable: "Alquileres",
                        principalColumn: "alquilerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    pagoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fechaDePago = table.Column<DateTime>(nullable: false),
                    monto = table.Column<double>(nullable: false),
                    formaDePago = table.Column<int>(nullable: false),
                    esPagoBase = table.Column<bool>(nullable: false),
                    alquilerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.pagoID);
                    table.ForeignKey(
                        name: "FK_Pagos_Alquileres_alquilerID",
                        column: x => x.alquilerID,
                        principalTable: "Alquileres",
                        principalColumn: "alquilerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accesorios_tipoDeAccesorioID",
                table: "Accesorios",
                column: "tipoDeAccesorioID");

            migrationBuilder.CreateIndex(
                name: "IX_AlquilerAccesorio_accesorioID",
                table: "AlquilerAccesorio",
                column: "accesorioID");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_AlquilerDeBicicletasUsersId",
                table: "Alquileres",
                column: "AlquilerDeBicicletasUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_bicicletaID",
                table: "Alquileres",
                column: "bicicletaID");

            migrationBuilder.CreateIndex(
                name: "IX_Bicicletas_tipoDeBiciID",
                table: "Bicicletas",
                column: "tipoDeBiciID");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_alquilerID",
                table: "Pagos",
                column: "alquilerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlquilerAccesorio");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Accesorios");

            migrationBuilder.DropTable(
                name: "Alquileres");

            migrationBuilder.DropTable(
                name: "TiposDeAccesorio");

            migrationBuilder.DropTable(
                name: "Bicicletas");

            migrationBuilder.DropTable(
                name: "TiposDeBici");

            migrationBuilder.AddColumn<string>(
                name: "contrasena",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
