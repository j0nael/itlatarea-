using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace taller_mecanico_v2.Migrations
{
    /// <inheritdoc />
    public partial class Clientes_prueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Mecanico",
                table: "Mecanico");

            migrationBuilder.RenameTable(
                name: "Mecanico",
                newName: "Mecanicos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mecanicos",
                table: "Mecanicos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mecanicos",
                table: "Mecanicos");

            migrationBuilder.RenameTable(
                name: "Mecanicos",
                newName: "Mecanico");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mecanico",
                table: "Mecanico",
                column: "Id");
        }
    }
}
