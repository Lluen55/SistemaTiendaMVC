using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaTiendaMVC.Models
{
    public class DetalleVentaProducto
    {
        [Key] public int Id { get; set; }

        [Required] public int VentasProductoId { get; set; }

        [ForeignKey("VentasProductoId")] public VentaProducto VentasProducto { get; set; }

        [Required] public int ProductoId { get; set; }

        [ForeignKey("ProductoId")] public Producto Producto { get; set; }

        [Required] public int CantidadPorProducto { get; set; }

        [Required]
        [Range(1, 100000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Precio Unitario de Venta")]
        public double PrecioUnitarioVenta { get; set; }


        [Required]
        [Range(1, 100000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Importe Total")]
        public double ImporteTotalPorProducto { get; set; }

        [Required]
        [Display(Name = "Fecha de Venta")]
        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; }
    }
}