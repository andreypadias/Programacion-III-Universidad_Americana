using PatronBridge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronBridge.Abstractions
{
    public abstract class Notificacion
    {

        protected IEnviarNotificacion _enviarNotificacion;

        public Notificacion(IEnviarNotificacion enviarNotificacion)
        {
            _enviarNotificacion = enviarNotificacion;
        }

        public abstract void EnviarNotificacion(string mensaje, string destinatario);
    }
}
