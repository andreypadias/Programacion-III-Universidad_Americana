using System.ComponentModel.DataAnnotations;

namespace TiposDeRelaciones.Models
{
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        //Propiedad de navegación
        public Pasaporte Pasaporte { get; set; } 

    }
}
