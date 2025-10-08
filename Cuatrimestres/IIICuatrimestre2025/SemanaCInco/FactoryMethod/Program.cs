// See https://aka.ms/new-console-template for more information

using FactoryMethod;

FabricaCuentaBancaria fabrica = new FabricaCuentaBancaria();

List<ICuentaBancaria> cuentas = new List<ICuentaBancaria>();

Console.WriteLine("Que cuenta quiere crear?");

string tipoCuenta = Console.ReadLine();



fabrica.CrearCuenta(tipoCuenta, "123-456", 1000m);