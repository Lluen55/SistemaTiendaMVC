using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaTiendaMVC.Models
{
    public class CompraProducto
    {
        [Key] public int Id { get; set; }

        [Required] public int ProveedorId { get; set; }

        [ForeignKey("ProveedorId")] public Proveedor Proveedor { get; set; }
        
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

        [Required]
        [Display(Name = "Fecha de Compra")]
        [DataType(DataType.Date)]
        public DateTime FechaCompra { get; set; }
        
        
        // [Required]
        // [Display(Name = "Tipo de Comprobante")]
        // public string TipoComprobante { get; set; }
        //
        // [Required]
        // [Display(Name = "Número de Comprobante")]
        // public string NumComprobante { get; set; }
    }
}