using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace taller_mecanico_v2.Migrations
{
    /// <inheritdoc />
    public partial class repuestos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehiculos",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Vehiculos");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Vehiculos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PlacaVehiculo",
                table: "Reparaciones",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehiculos",
                table: "Vehiculos",
                column: "Placa");

            migrationBuilder.CreateTable(
                name: "Repuestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<double>(type: "float", nullable: false),
                    PrecioPorMayor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repuestos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IdCliente",
                table: "Vehiculos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Reparaciones_IdMecanico",
                table: "Reparaciones",
                column: "IdMecanico");

            migrationBuilder.CreateIndex(
                name: "IX_Reparaciones_PlacaVehiculo",
                table: "Reparaciones",
                column: "PlacaVehiculo");

            migrationBuilder.AddForeignKey(
                name: "FK_Reparaciones_Mecanicos_IdMecanico",
                table: "Reparaciones",
                column: "IdMecanico",
                principalTable: "Mecanicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reparaciones_Vehiculos_PlacaVehiculo",
                table: "Reparaciones",
                column: "PlacaVehiculo",
                principalTable: "Vehiculos",
                principalColumn: "Placa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Clientes_IdCliente",
                table: "Vehiculos",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reparaciones_Mecanicos_IdMecanico",
                table: "Reparaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Reparaciones_Vehiculos_PlacaVehiculo",
                table: "Reparaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Clientes_IdCliente",
                table: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Repuestos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehiculos",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_IdCliente",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Reparaciones_IdMecanico",
                table: "Reparaciones");

            migrationBuilder.DropIndex(
                name: "IX_Reparaciones_PlacaVehiculo",
                table: "Reparaciones");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Vehiculos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "PlacaVehiculo",
                table: "Reparaciones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehiculos",
                table: "Vehiculos",
                column: "Id");
        }
    }
}
