using Microsoft.AspNetCore.Identity;

namespace Proyecto.Models
{
    public class Usuario:IdentityUser
    {
        public string Cedula { get; set; }

        public decimal Salario { get; set; }


    }
}
