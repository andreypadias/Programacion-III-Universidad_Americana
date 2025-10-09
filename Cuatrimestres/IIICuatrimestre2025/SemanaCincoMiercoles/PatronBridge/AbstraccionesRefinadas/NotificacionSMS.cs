using PatronBridge.Abstraccion;
using PatronBridge.Implementador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronBridge.AbstraccionesRefinadas
{
    public class NotificacionSMS : Notificacion
    {
        public NotificacionSMS(IProveedorMensajeria proveedor) : base(proveedor)
        {
        }

        public override void Enviar(string destinatario)
        {
            Console.WriteLine("Enviando SMS - Utilizando el proovedor +"+proveedor);
        }
    }
}
