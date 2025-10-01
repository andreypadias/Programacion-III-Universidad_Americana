using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NumeroFiscal { get; set; }
        public string Contacto { get; set; }

        public Proveedor(int id, string nombre, string numeroFiscal, string contacto)
        {
            Id = id;
            Nombre = nombre;
            NumeroFiscal = numeroFiscal;
            Contacto = contacto;
        }

        public override string ToString()
        {
            return $"[{Id}] {Nombre} - Fiscal: {NumeroFiscal} - Contacto: {Contacto}";
        }
    }
}
