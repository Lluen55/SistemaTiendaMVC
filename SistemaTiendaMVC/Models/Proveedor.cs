using System.ComponentModel.DataAnnotations;

namespace SistemaTiendaMVC.Models
{
    public class Proveedor
    {
        [Key] public int Id { get; set; }

        [Required] public string RUC { get; set; }

        [Required]
        [Display(Name = "Razon Social")]
        public string RazonSocial { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string telefono { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
    }
}