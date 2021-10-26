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

        [Required] public int TotalProductos { get; set; }
        
        [Required] public int CantidadPorProducto { get; set; }

        [Required]
        [Range(1, 100000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Importe Total")]
        public double ImporteTotal { get; set; }

        [Required]
        [Range(1, 100000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Monto de Pago")]
        public double ImporteRecibido { get; set; }

        [Required]
        [Range(1, 100000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Cambio")]
        public double ImporteCambio { get; set; }

        [Required]
        [Display(Name = "Fecha de Venta")]
        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; }
        
    }
}