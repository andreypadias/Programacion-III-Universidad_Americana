using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiposDeRelaciones.Models
{
    public class Pasaporte
    {
        //Propiedades -- Atributos
        [Key]
        public int IdPasaporte { get; set; }

        public string Numero { get; set; }

        public string Pais { get; set; }

        public DateTime FechaEmision { get; set; }

        public DateTime FechaExpiracion { get; set; }

        //Propiedad de navegación
        [ForeignKey("Persona")]
        public int IdPersona { get; set; }
        public Persona Persona { get; set; }
    }
}
