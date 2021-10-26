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
        
        [Required] public int CantidadPorProducto { get; set; }

        [Required]
        [Display(Name = "Fecha de Registro")]
        //[DataType(DataType.DateTime)]
        public DateTime FechaCompra { get; set; }
    }
}