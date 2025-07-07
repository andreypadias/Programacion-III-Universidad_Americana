// See https://aka.ms/new-console-template for more information
using FactoryMethod;

Console.WriteLine("Hello, World!");

FabricaCuentaBancaria fabrica = new FabricaCuentaBancaria();

ICuentaBancaria cuentaAhorro1 = fabrica.CrearCuenta();