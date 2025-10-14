using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsability
{
    public abstract class Aprobador
    {
        protected Aprobador SiguienteAprobador;

        protected decimal LimiteAprobacion;

        protected string Cargo;

        protected Aprobador(string cargo, decimal limiteAprobacion)
        {
            Cargo = cargo;
            LimiteAprobacion = limiteAprobacion;
        }

        public void EstablecerSiguiente(Aprobador siguienteAprobador)
        {
            SiguienteAprobador = siguienteAprobador;
        }

        public abstract void ProcesarSolicitud(SolicitudCompra solicitud);
    }
}
