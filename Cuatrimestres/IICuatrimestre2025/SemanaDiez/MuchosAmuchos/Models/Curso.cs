using System.ComponentModel.DataAnnotations;

namespace MuchosAmuchos.Models
{
    public class Curso
    {
        [Key]
        public int IdCurso { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public ICollection<CursoEstudiante> CursosEstudiantes { get; set; }
    }
}
