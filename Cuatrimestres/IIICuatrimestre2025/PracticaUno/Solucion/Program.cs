// See https://aka.ms/new-console-template for more information
using Solucion;

try
{
    Console.WriteLine("Iniciando sistema de gestión de compras...");
    Console.WriteLine("Presione cualquier tecla para continuar.");
    Console.ReadKey();

    var sistema = new SistemaCompras();
    sistema.MostrarMenu();
}
catch (Exception ex)
{
    Console.WriteLine($"Error crítico: {ex.Message}");
    Console.WriteLine("Presione cualquier tecla para salir...");
    Console.ReadKey();
}