using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace taller_mecanico_v2.Migrations
{
    /// <inheritdoc />
    public partial class Clientes: Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
