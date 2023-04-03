using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ab_accesorios_be.Migrations
{
    /// <inheritdoc />
    public partial class fixusuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NroDocumento",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "Telefono",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "NroDocumento",
                table: "Usuarios",
                type: "int",
                maxLength: 8,
                nullable: false,
                defaultValue: 0);
        }
    }
}
