using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaTiendaMVC.Models
{
    public class DetalleCompraProducto
    {
        [Key] public int Id { get; set; }
        
        [Required] public int CompraProductoId { get; set; }

        [ForeignKey("CompraProductoId")] public CompraProducto CompraProducto { get; set; }
        
        [Required] public int ProductoId { get; set; }

        [ForeignKey("ProductoId")] public Producto Producto { get; set; }
        
        [Required] public int CantidadProducto { get; set; }
        
        [Required]
        [Range(1, 100000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Precio Unitario de Compra")]
        public double PrecioUnitarioCompra { get; set; }
        
        [Required]
        [Range(1, 100000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Precio Unitario de Venta")]
        public double PrecioUnitarioVenta { get; set; }

        [Required]
        [Range(1, 100000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Costo Total")]
        public double CostoTotal { get; set; }
    }
}