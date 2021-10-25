using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTiendaMVC.Migrations
{
    public partial class migrationErrorVentaProductoCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "VentaProducto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VentaProducto_ProductoId",
                table: "VentaProducto",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaProducto_Producto_ProductoId",
                table: "VentaProducto",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentaProducto_Producto_ProductoId",
                table: "VentaProducto");

            migrationBuilder.DropIndex(
                name: "IX_VentaProducto_ProductoId",
                table: "VentaProducto");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "VentaProducto");
        }
    }
}
