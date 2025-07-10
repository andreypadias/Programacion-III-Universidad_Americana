using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnoAmuchos.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }

        public string Nombre { get; set; }

        public string Foto { get; set; }

        //Llave Foranea o Foreing Key o FK

        public int IdDepartamento { get; set; }

        //propiedad de navegación
        [ForeignKey("IdDepartamento")]
        public Departamento Departamento { get; set; }


    }
}
