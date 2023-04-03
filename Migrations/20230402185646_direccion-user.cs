using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ab_accesorios_be.Migrations
{
    /// <inheritdoc />
    public partial class direccionuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DireccionCalle",
                table: "Usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DireccionNumero",
                table: "Usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DireccionCalle",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DireccionNumero",
                table: "Usuarios");
        }
    }
}
