using Microsoft.EntityFrameworkCore;
using SistemaTiendaMVC.Models;

namespace SistemaTiendaMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<SistemaTiendaMVC.Models.Categoria> Categoria { get; set; }
        public DbSet<SistemaTiendaMVC.Models.Producto> Producto { get; set; }
        public DbSet<SistemaTiendaMVC.Models.Proveedor> Proveedor { get; set; }
        public DbSet<SistemaTiendaMVC.Models.Cliente> Cliente { get; set; }
        public DbSet<SistemaTiendaMVC.Models.CompraProducto> CompraProducto { get; set; }
        public DbSet<SistemaTiendaMVC.Models.VentaProducto> VentaProducto { get; set; }
        public DbSet<SistemaTiendaMVC.Models.DetalleCompraProducto> DetalleCompraProducto { get; set; }
        public DbSet<SistemaTiendaMVC.Models.DetalleVentaProducto> DetalleVentaProducto { get; set; }

        
    }
}