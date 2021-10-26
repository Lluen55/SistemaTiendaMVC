using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaTiendaMVC.Models
{
    public class Proveedor
    {
        [Key] public int Id { get; set; }

        [Display(Name = "RUC")]
        [Required] public string Ruc { get; set; }

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
        public string Telefono { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        
        [Required] public bool Estado { get; set; }
        
        [Required]
        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }
    }
}