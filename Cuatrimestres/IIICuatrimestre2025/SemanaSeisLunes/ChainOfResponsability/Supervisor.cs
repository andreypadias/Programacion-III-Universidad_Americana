using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsability
{
    public class Supervisor : Aprobador
    {
        public Supervisor() : base("Supervisor", 1000)
        {

        }

        public override void ProcesarSolicitud(SolicitudCompra solicitud)
        {
            // Si el monto está dentro de su límite, aprueba
            if (solicitud.Monto <= LimiteAprobacion)
            {
                Console.WriteLine($"✓ {Cargo} aprobó la solicitud:");
                Console.WriteLine($"  - Solicitante: {solicitud.Solicitante}");
                Console.WriteLine($"  - Descripción: {solicitud.Descripcion}");
                Console.WriteLine($"  - Monto: ${solicitud.Monto:N2}");
                Console.WriteLine();
            }
            // Si excede su límite, pasa la solicitud al siguiente en la cadena
            else if (SiguienteAprobador != null)
            {
                Console.WriteLine($"→ {Cargo} no tiene autoridad suficiente (Límite: ${LimiteAprobacion:N2})");
                Console.WriteLine($"  Escalando al siguiente nivel...\n");
                SiguienteAprobador.ProcesarSolicitud(solicitud);
            }
            else
            {
                Console.WriteLine($"✗ Solicitud rechazada: No hay más aprobadores en la cadena.");
            }
        }
    }
}
