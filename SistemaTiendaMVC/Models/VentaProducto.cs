using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaTiendaMVC.Models
{
    public class VentaProducto
    {
        [Key] public int Id { get; set; }

        [Required] public int ClienteId { get; set; }

        [ForeignKey("ClienteId")] public Cliente Cliente { get; set; }

        [Required] public int ProductoId { get; set; }

        [ForeignKey("ProductoId")] public Producto Producto { get; set; }

        [Required] public int CantidadProducto { get; set; }

        [Required] public int CantidadTotal { get; set; }

        [Required]
        [Range(1, 100000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Costo Total")]
        public double CostoTotal { get; set; }

        [Required]
        [Range(1, 100000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Precio Unitario de Compra")]
        public double ImporteRecibido { get; set; }

        [Required]
        [Range(1, 100000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Precio Unitario de Venta")]
        public double ImporteCambio { get; set; }

        [Required]
        [Display(Name = "Fecha de Venta")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }
        
        
        // [Required]
        // [Display(Name = "Tipo de Comprobante")]
        // public string TipoComprobante { get; set; }
        //
        // [Required]
        // [Display(Name = "Número de Comprobante")]
        // public string NumComprobante { get; set; }
    }
}