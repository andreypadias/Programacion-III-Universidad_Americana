// See https://aka.ms/new-console-template for more information
using ProyectoSemanaUno.Data;

Inventario inventario = new Inventario();
List<Pedido> pedidos = new List<Pedido>();
bool salir = false;

while (!salir) 
{
	try
	{
        Console.WriteLine("\n--- Menú Principal ---");
        Console.WriteLine("1. Inventario");
        Console.WriteLine("2. Pedidos");
        Console.WriteLine("3. Salir");
        Console.Write("Seleccione una opción: ");
        int opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                bool menuInventario = false;
                while (!menuInventario) 
                {
                    Console.WriteLine("Administracion de Inventario");
                    Console.WriteLine("1. Agregar Producto");
                    Console.WriteLine("2. Editar Producto");
                    Console.WriteLine("3. Eliminar Producto");
                    Console.WriteLine("4. Mostrar Inventario");
                    Console.WriteLine("5. Salir");
                    int opcionInventario = int.Parse(Console.ReadLine());

                    switch (opcionInventario)
                    {
                        default: break;
                    }
                }
                



                break;
            case 2:
                break;
            case 3:
                Console.WriteLine("Saliendo del sistema.");
                salir = true;
                break;
            default:
                Console.WriteLine("Por favor escoger una opcion entre 1 y 3.");
                break;
        }

       

    }
	catch (Exception ex)
	{

        Console.WriteLine($"Error: {ex.Message}");
    }
}





