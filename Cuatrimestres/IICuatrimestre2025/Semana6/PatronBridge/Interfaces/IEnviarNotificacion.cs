using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronBridge.Interfaces
{
    public interface IEnviarNotificacion
    {
        void EnviarNotificacionInterfaz(string mensaje, string destinatario);
    }
}
