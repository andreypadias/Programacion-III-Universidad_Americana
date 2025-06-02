using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDePagos
{
    public class Menu
    {
        private List<Cliente> _clientes = new List<Cliente>();


        public void MostrarMenu() 
        {
            bool opcionMenu = false;
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
                            AgregarUsuario();
                            break;
                        case "2":
                            ConsultarDeudaCliente();
                            break;
                        case "3":
                            VerTodosClientes();
                            break;
                        case "4":
                            AbonarDeuda();
                            break;
                        case "5":
                            opcionMenu = Salir();
                            break;

                        default:
                            Console.WriteLine("Seleccione una opcion valida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al mostrar el menu: " + ex.Message);
                }
            }
            while (!opcionMenu);
            
            
        }

        public void AgregarUsuario()
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

                if (string.IsNullOrWhiteSpace(cedula) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(telefono))
                {
                    Console.WriteLine("Error: Todos los campos son obligatorios. No se pudo crear el cliente.");

                }
                else 
                {
                    Cliente cliente = new Cliente(cedula, nombre, telefono);
                   
                    Console.WriteLine("Cliente {0} creado con éxito", cliente.Nombre);

                    Console.WriteLine("Desea agregar deuda a este cliente?");
                    string respuesta = Console.ReadLine().ToLower();

                    if (respuesta == "si")
                    {
                        Console.WriteLine("Indique el monto de la deuda inicial en colones:");
                        double montoDeuda = double.Parse(Console.ReadLine());
                        cliente.CrearDeuda(montoDeuda);
                    }
                    else 
                    {
                        Console.WriteLine("Cliente creado sin deuda.");
                    }

                    _clientes.Add(cliente);
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine("El siguiente error ha ocurrido: {0}", ex.Message);
            }
            
            
        }

        public void ConsultarDeudaCliente() 
        {
            Console.WriteLine("***Consulta de Deuda***\n Ingrese la cedula del cliente:");
            string cedulaConsulta = Console.ReadLine();

            Cliente clienteConsulta = _clientes.Find(c => c.Cedula == cedulaConsulta);

            if (clienteConsulta != null)
            {
                Console.WriteLine(clienteConsulta.VerDeuda());
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        public void VerTodosClientes() 
        {
            foreach (Cliente cliente in _clientes)
            {
                Console.WriteLine(cliente.VerDeuda()); 
            }
        }

        public void AbonarDeuda()
        {
            Console.WriteLine("***Abono de deuda***\n Ingrese la cedula del cliente:");
            string cedulaConsulta = Console.ReadLine();

            Cliente clienteConsulta = _clientes.Find(c => c.Cedula == cedulaConsulta);

            if (clienteConsulta != null)
            {
                Console.WriteLine("Inserte el monto a abonar:");
                double abono = double.Parse(Console.ReadLine());
                clienteConsulta.AbonarDeuda(abono);
                

            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }

        }


        public bool Salir() 
        {
            Console.WriteLine("Desea salir del sistema? Si o no?");
            string respuesta = Console.ReadLine().ToLower();
            if (respuesta == "si")
            {
                Console.WriteLine("Saliendo del sistema!");
                return true;
            }
            else { return false; }
        }
    }
}
