using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTiendaMVC.Migrations
{
    public partial class migration02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompraProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    CantidadProducto = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitarioCompra = table.Column<double>(type: "float", nullable: false),
                    PrecioUnitarioVenta = table.Column<double>(type: "float", nullable: false),
                    CostoTotal = table.Column<double>(type: "float", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompraProducto_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompraProducto_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VentaProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    CantidadProducto = table.Column<int>(type: "int", nullable: false),
                    CantidadTotal = table.Column<int>(type: "int", nullable: false),
                    CostoTotal = table.Column<double>(type: "float", nullable: false),
                    ImporteRecibido = table.Column<double>(type: "float", nullable: false),
                    ImporteCambio = table.Column<double>(type: "float", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentaProducto_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompraProducto_ProductoId",
                table: "CompraProducto",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraProducto_ProveedorId",
                table: "CompraProducto",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaProducto_ClienteId",
                table: "VentaProducto",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraProducto");

            migrationBuilder.DropTable(
                name: "VentaProducto");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
