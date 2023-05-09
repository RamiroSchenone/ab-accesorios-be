using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ab_accesorios_be.Migrations
{
    /// <inheritdoc />
    public partial class archivos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Marcas_MarcaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosDomicilio_Usuarios_UsuarioId",
                table: "UsuariosDomicilio");

            migrationBuilder.DropTable(
                name: "Medidas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuariosDomicilio",
                table: "UsuariosDomicilio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marcas",
                table: "Marcas");

            migrationBuilder.RenameTable(
                name: "UsuariosDomicilio",
                newName: "ab_UsuariosDomicilio");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "ab_Usuarios");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "ab_Productos");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "ab_MenuItems");

            migrationBuilder.RenameTable(
                name: "Marcas",
                newName: "ab_Marcas");

            migrationBuilder.RenameIndex(
                name: "IX_UsuariosDomicilio_UsuarioId",
                table: "ab_UsuariosDomicilio",
                newName: "IX_ab_UsuariosDomicilio_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_MarcaId",
                table: "ab_Productos",
                newName: "IX_ab_Productos_MarcaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ab_UsuariosDomicilio",
                table: "ab_UsuariosDomicilio",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ab_Usuarios",
                table: "ab_Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ab_Productos",
                table: "ab_Productos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ab_MenuItems",
                table: "ab_MenuItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ab_Marcas",
                table: "ab_Marcas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ab_Archivos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FilePath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DownloadName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ab_Archivos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ab_MedidasProducto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Alto = table.Column<float>(type: "float", nullable: false),
                    Ancho = table.Column<float>(type: "float", nullable: false),
                    Profundidad = table.Column<float>(type: "float", nullable: false),
                    ProductoId = table.Column<long>(type: "bigint", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ab_MedidasProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ab_MedidasProducto_ab_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "ab_Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ab_MedidasProducto_ProductoId",
                table: "ab_MedidasProducto",
                column: "ProductoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ab_Productos_ab_Marcas_MarcaId",
                table: "ab_Productos",
                column: "MarcaId",
                principalTable: "ab_Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ab_UsuariosDomicilio_ab_Usuarios_UsuarioId",
                table: "ab_UsuariosDomicilio",
                column: "UsuarioId",
                principalTable: "ab_Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ab_Productos_ab_Marcas_MarcaId",
                table: "ab_Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_ab_UsuariosDomicilio_ab_Usuarios_UsuarioId",
                table: "ab_UsuariosDomicilio");

            migrationBuilder.DropTable(
                name: "ab_Archivos");

            migrationBuilder.DropTable(
                name: "ab_MedidasProducto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ab_UsuariosDomicilio",
                table: "ab_UsuariosDomicilio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ab_Usuarios",
                table: "ab_Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ab_Productos",
                table: "ab_Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ab_MenuItems",
                table: "ab_MenuItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ab_Marcas",
                table: "ab_Marcas");

            migrationBuilder.RenameTable(
                name: "ab_UsuariosDomicilio",
                newName: "UsuariosDomicilio");

            migrationBuilder.RenameTable(
                name: "ab_Usuarios",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "ab_Productos",
                newName: "Productos");

            migrationBuilder.RenameTable(
                name: "ab_MenuItems",
                newName: "Menus");

            migrationBuilder.RenameTable(
                name: "ab_Marcas",
                newName: "Marcas");

            migrationBuilder.RenameIndex(
                name: "IX_ab_UsuariosDomicilio_UsuarioId",
                table: "UsuariosDomicilio",
                newName: "IX_UsuariosDomicilio_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_ab_Productos_MarcaId",
                table: "Productos",
                newName: "IX_Productos_MarcaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuariosDomicilio",
                table: "UsuariosDomicilio",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marcas",
                table: "Marcas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Medidas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductoId = table.Column<long>(type: "bigint", nullable: false),
                    Alto = table.Column<float>(type: "float", nullable: false),
                    Ancho = table.Column<float>(type: "float", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Profundidad = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medidas_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Medidas_ProductoId",
                table: "Medidas",
                column: "ProductoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Marcas_MarcaId",
                table: "Productos",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosDomicilio_Usuarios_UsuarioId",
                table: "UsuariosDomicilio",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
