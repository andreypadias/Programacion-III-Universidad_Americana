using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SistemaBasico.Models
{
    public class Usuario:IdentityUser
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Cedula { get; set; }

        public DateOnly FechaNacimiento { get; set; }
    }
}
