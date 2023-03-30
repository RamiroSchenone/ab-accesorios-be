using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ab_accesorios_be.Migrations
{
    /// <inheritdoc />
    public partial class medidasentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Medidas_MedidaId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_MedidaId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "MedidaId",
                table: "Productos");

            migrationBuilder.CreateIndex(
                name: "IX_Medidas_ProductoId",
                table: "Medidas",
                column: "ProductoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medidas_Productos_ProductoId",
                table: "Medidas",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medidas_Productos_ProductoId",
                table: "Medidas");

            migrationBuilder.DropIndex(
                name: "IX_Medidas_ProductoId",
                table: "Medidas");

            migrationBuilder.AddColumn<long>(
                name: "MedidaId",
                table: "Productos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MedidaId",
                table: "Productos",
                column: "MedidaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Medidas_MedidaId",
                table: "Productos",
                column: "MedidaId",
                principalTable: "Medidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
