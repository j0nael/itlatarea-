using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace taller_mecanico_v2.Migrations
{
    /// <inheritdoc />
    public partial class creaciondecampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Vendedores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Vendedores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Vendedores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Vendedores");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Vendedores");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Vendedores");
        }
    }
}
