using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronBridge.Implementador
{

    //Implementator o Implementador
    //A nivel de negocio, es la tecnologia que voy a usar para enviar la notificacion
    public interface IProveedorMensajeria
    {
        void EnviarMensaje(string destinatario, string mensaje);
    }
}
