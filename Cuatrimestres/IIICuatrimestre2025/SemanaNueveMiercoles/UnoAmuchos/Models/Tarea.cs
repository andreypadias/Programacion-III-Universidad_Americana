using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnoAmuchos.Models
{
    public class Tarea
    {
        [Key]
        public int IdTarea { get; set; }

        public string TituloTarea { get; set; }

        public string Descripcion { get; set; }

        // Clave foránea para la relación uno a muchos
        [ForeignKey("Proyecto")]
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}
