using PatronBridge.Abstraccion;
using PatronBridge.Implementador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronBridge.AbstraccionesRefinadas
{
    public class NotificacionEmail : Notificacion
    {
        public NotificacionEmail(IProveedorMensajeria proveedor) : base(proveedor)
        {
        }

        public override void Enviar(string destinatario)
        {
            Console.WriteLine("Enviando Email - Utilizando el proovedor +" + proveedor);
        }
    }
}
