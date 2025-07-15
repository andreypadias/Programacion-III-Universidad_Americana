using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuchosAmuchos.Models
{
    public class CursoEstudiante
    {
        [Key]
        public int Id { get; set; }
        public int IdEstudiante { get; set; }
        // Propiedad de navegación
        [ForeignKey("IdEstudiante")]
        public Estudiante Estudiante { get; set; }

        public int IdCurso { get; set; }
        // Propiedad de navegación
        [ForeignKey("IdCurso")]
        public Curso Curso { get; set; }




    }
}
