using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaTiendaMVC.Models
{
    public class Producto
    {
        [Key] public int Id { get; set; }

        [Required] public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")] public Categoria Categoria { get; set; }

        [Required]
        [Display(Name = "Nombre Producto")]
        public string NombreProducto { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [Range(1, 100000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double PrecioVenta { get; set; }

        [Required] public int Stock { get; set; }

        [Required] public bool Estado { get; set; }
    }
}