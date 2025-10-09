using PatronBridge.Implementador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronBridge.Abstraccion
{
    public abstract class Notificacion
    {
        //Atributo
        //Utilizo mi implementador como atributo
        protected IProveedorMensajeria proveedor;

        //Constructor
        protected Notificacion(IProveedorMensajeria proveedor)
        {
            this.proveedor = proveedor;
        }

        // Método abstracto que las subclases implementarán
        public abstract void Enviar(string destinatario);

        // Permite cambiar el proveedor en tiempo de ejecución
        public void CambiarProveedor(IProveedorMensajeria nuevoProveedor)
        {
            proveedor = nuevoProveedor;
        }
    }
}
