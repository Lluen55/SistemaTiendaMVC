using System.ComponentModel.DataAnnotations;

namespace SistemaTiendaMVC.Models
{
    public class Categoria
    {
        [Key] public int Id { get; set; }
        
        [Required]
        [MaxLength(60)]
        [Display(Name = "Nombre Categoría")]
        public string NombreCategoria { get; set; }

        [Required] public bool Estado { get; set; }
    }
}