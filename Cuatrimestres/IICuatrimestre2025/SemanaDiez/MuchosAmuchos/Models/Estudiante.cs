using System.ComponentModel.DataAnnotations;

namespace MuchosAmuchos.Models
{
    public class Estudiante
    {
        [Key]
        public int IdEstudiante { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        //Propiedad de navegación
        public ICollection<CursoEstudiante> CursosEstudiantes { get; set; }

    }
}
