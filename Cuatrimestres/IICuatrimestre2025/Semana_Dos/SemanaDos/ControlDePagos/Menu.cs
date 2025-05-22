using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDePagos
{
    public class Menu
    {
        private List<Cliente> _clientes;

        public Menu(List<Cliente> clientes)
        {
            _clientes = clientes;
        }

        public void MostrarMenu() 
        {
            bool opcionMenu = true;
            do
            {
                try
                {
                    Console.WriteLine("****Menu de control de clientes****");
                    Console.WriteLine("1 - Crear cliente");
                    Console.WriteLine("2 - Consultar deuda cliente");
                    Console.WriteLine("3 - Ver todos los clientes");
                    Console.WriteLine("4 - Abonar deuda");
                    Console.WriteLine("5 - Salir");
                    Console.WriteLine("Seleccione una opcion");

                    string opcion = Console.ReadLine();
                    switch (opcion)
                    {
                        case "1":
                            clientes.Add(AgregarUsuario());
                            break;
                        case "2":
                            

                            break;
                        case "3":
                            
                            break;
                        case "4":
                            
                            break;
                        case "5":
                           
                            break;

                        default:
                            
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al mostrar el menu: " + ex.Message);
                }
            }
            while (opcionMenu);
            
            
        }

        public Cliente AgregarUsuario() 
        {
            try
            {
                Console.WriteLine("Creando Cliente");
                Console.WriteLine("Ingrese la cedula del cliente");
                string cedula = Console.ReadLine();
                Console.WriteLine("Ingrese el nombre del cliente");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el telefono del cliente");
                string telefono = Console.ReadLine();
                Cliente cliente = new Cliente(cedula, nombre, telefono);
                Console.WriteLine("Cliente creado con exito");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("El error {0} ha ocurrido: ", ex.Message);
                
            }
            
            return cliente;
        }
    }
}
