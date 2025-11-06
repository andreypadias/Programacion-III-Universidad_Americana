using System.ComponentModel.DataAnnotations;

namespace UnoAmuchos.Models
{
    public class Proyecto
    {
        [Key]
        public int IdProyecto { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        // Propiedad de navegación para la relación uno a muchos

        public ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
    }
}
