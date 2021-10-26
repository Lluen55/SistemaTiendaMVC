using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTiendaMVC.Migrations
{
    public partial class migration04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompraProducto_Producto_ProductoId",
                table: "CompraProducto");

            migrationBuilder.DropIndex(
                name: "IX_CompraProducto_ProductoId",
                table: "CompraProducto");

            migrationBuilder.DropColumn(
                name: "CantidadProducto",
                table: "CompraProducto");

            migrationBuilder.DropColumn(
                name: "CostoTotal",
                table: "CompraProducto");

            migrationBuilder.DropColumn(
                name: "PrecioUnitarioCompra",
                table: "CompraProducto");

            migrationBuilder.DropColumn(
                name: "PrecioUnitarioVenta",
                table: "CompraProducto");

            migrationBuilder.RenameColumn(
                name: "CostoTotal",
                table: "VentaProducto",
                newName: "ImporteTotal");

            migrationBuilder.RenameColumn(
                name: "CantidadTotal",
                table: "VentaProducto",
                newName: "TotalProductos");

            migrationBuilder.RenameColumn(
                name: "CantidadProducto",
                table: "VentaProducto",
                newName: "CantidadPorProducto");

            migrationBuilder.RenameColumn(
                name: "RUC",
                table: "Proveedor",
                newName: "Ruc");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "CompraProducto",
                newName: "CantidadPorProducto");

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Proveedor",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Proveedor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Cliente",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "DetalleCompraProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompraProductoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    CantidadProducto = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitarioCompra = table.Column<double>(type: "float", nullable: false),
                    PrecioUnitarioVenta = table.Column<double>(type: "float", nullable: false),
                    CostoTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCompraProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleCompraProducto_CompraProducto_CompraProductoId",
                        column: x => x.CompraProductoId,
                        principalTable: "CompraProducto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleCompraProducto_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleVentaProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentasProductoId = table.Column<int>(type: "int", nullable: false),
                    CantidadPorProducto = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitarioVenta = table.Column<double>(type: "float", nullable: false),
                    ImporteTotalPorProducto = table.Column<double>(type: "float", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVentaProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleVentaProducto_VentaProducto_VentasProductoId",
                        column: x => x.VentasProductoId,
                        principalTable: "VentaProducto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompraProducto_CompraProductoId",
                table: "DetalleCompraProducto",
                column: "CompraProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompraProducto_ProductoId",
                table: "DetalleCompraProducto",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVentaProducto_VentasProductoId",
                table: "DetalleVentaProducto",
                column: "VentasProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleCompraProducto");

            migrationBuilder.DropTable(
                name: "DetalleVentaProducto");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "TotalProductos",
                table: "VentaProducto",
                newName: "CantidadTotal");

            migrationBuilder.RenameColumn(
                name: "ImporteTotal",
                table: "VentaProducto",
                newName: "CostoTotal");

            migrationBuilder.RenameColumn(
                name: "CantidadPorProducto",
                table: "VentaProducto",
                newName: "CantidadProducto");

            migrationBuilder.RenameColumn(
                name: "Ruc",
                table: "Proveedor",
                newName: "RUC");

            migrationBuilder.RenameColumn(
                name: "CantidadPorProducto",
                table: "CompraProducto",
                newName: "ProductoId");

            migrationBuilder.AddColumn<int>(
                name: "CantidadProducto",
                table: "CompraProducto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "CostoTotal",
                table: "CompraProducto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrecioUnitarioCompra",
                table: "CompraProducto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrecioUnitarioVenta",
                table: "CompraProducto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_CompraProducto_ProductoId",
                table: "CompraProducto",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompraProducto_Producto_ProductoId",
                table: "CompraProducto",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
