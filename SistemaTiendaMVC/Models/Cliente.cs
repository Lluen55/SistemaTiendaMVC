using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaTiendaMVC.Models
{
    public class Cliente
    {
        [Key] public int Id { get; set; }

        [Required]
        [Display(Name = "Tipo de Documento")]
        public string TipoDocumento { get; set; }

        [Required]
        [Display(Name = "Número de Documento")]
        public string NumDocumento { get; set; }

        [Required]
        [Display(Name = "Nombres y Apellidos")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string telefono { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}