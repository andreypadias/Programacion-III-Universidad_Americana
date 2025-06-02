using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDePagos
{
    public class Cliente
    {
        //Atributos = Propiedades o caracteristicas de estos futuros objetos

        //Cedula
        public string Cedula { get; set; }
        //Nombre
        public string Nombre { get; set; }
        //Telefono
        public string Telefono { get; set; }
        //Monto de Deuda
        public double  MontoDeuda { get; set; }

        //Constructor

        public Cliente(string cedula, string nombre, string telefono)
        {
            Cedula = cedula;
            Nombre = nombre;
            Telefono = telefono;
            MontoDeuda = 0;
        }


        //Metodos

        //Crear Deuda
        public void CrearDeuda(double monto)
        {
            if (monto > 0)
            {
                MontoDeuda += monto;
                Console.WriteLine("El monto de deuda del cliente {0} ha sido actualizado a: {1} colones.", Nombre, MontoDeuda);
            }
            else
            {
                Console.WriteLine("El monto de la deuda debe ser mayor que cero. \n Deuda no creada.");
            }
        }

        //Abonar deuda
        public void AbonarDeuda(double monto)
        {
            if (MontoDeuda<=0) 
            {
                Console.WriteLine("Este cliente no tiene deuda.");
                return;
            }

            if (monto > 0)
            {
                if (MontoDeuda-monto<0)
                {
                    Console.WriteLine("El monto a abonar no puede ser mayor que la deuda actual. \n Abono no realizado.");
                    return;
                }
                else 
                {
                    MontoDeuda -= monto;
                    Console.WriteLine("Monto abonado exitosamente. Ahora el cliente tiene un saldo de: {0}", MontoDeuda);
                }
                
            }
            else
            {
                Console.WriteLine("El monto a abonar debe ser mayor que cero.");
            }
        }

        //Ver Deuda del cliente
        public string VerDeuda()
        {
           return "El cliente " + Nombre + " tiene una deuda de " + MontoDeuda.ToString("C") + ".";
        }

    }


}
