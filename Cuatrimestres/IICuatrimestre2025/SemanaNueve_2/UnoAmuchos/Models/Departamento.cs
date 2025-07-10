using System.ComponentModel.DataAnnotations;

namespace UnoAmuchos.Models
{
    public class Departamento
    {
        [Key]
        public int IdDepartamento { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        //Propiedad de navegación
        public ICollection<Empleado> Empleados { get; set; }


    }
}
