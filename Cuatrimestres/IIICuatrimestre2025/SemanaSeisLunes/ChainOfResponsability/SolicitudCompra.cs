using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsability
{
    public class SolicitudCompra
    {
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string Solicitante { get; set; }

        public SolicitudCompra(string descripcion, decimal monto, string solicitante)
        {
            Descripcion = descripcion;
            Monto = monto;
            Solicitante = solicitante;

        }

    }
}
