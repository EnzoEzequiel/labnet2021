using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp1_POO_vehiculos
{
    class Program
    {
        static void Main(string[] args)
        {
            string tipoVehiculo = "nada";

            Taxi taxisito;
            Omnibus ominisito;

            do
            {
                try
                {
                    Console.WriteLine("Favor de Ingresar el tipo de vehiculo (taxi u omnibus) o 'listo' para finalizar: ");
                    tipoVehiculo = Console.ReadLine();

                    if (tipoVehiculo.ToLower() == "taxi")
                    {
                        Console.WriteLine("Ahora favor de ingresar la cantidad de pasajeros: ");
                        taxisito = new Taxi(int.Parse(Console.ReadLine()));

                    }
                    else
                    {
                        if (tipoVehiculo.ToLower() == "omnibus")
                        {
                            Console.WriteLine("Ahora favor de ingresar la cantidad de pasajeros: ");
                            ominisito = new ominisito(int.Parse(Console.ReadLine()));
                        }
                        else
                        {
                        }
                    }

                    /*
                    switch (tipoVehiculo)
                    {
                        case "taxi":
                            Console.WriteLine("Ahora favor de ingresar la cantidad de pasajeros: ");
                            pasajerosTaxi =int.Parse(Console.ReadLine());
                          
                            
                            Console.ReadKey();
                            Console.Clear();
                           
                            break;

                        case "omnibus":
                            Console.WriteLine("Ahora favor de ingresar la cantidad de pasajeros: ");
                            pasajerosOmnibus = int.Parse(Console.ReadLine());
                            Console.ReadKey();
                            Console.Clear();
                           
                            break;
                        default:
                            Console.WriteLine("Ingrese tipo de vehiculo (taxi u omnibus). ");
                            Console.ReadKey();
                            Console.Clear();
                         
                            break;
                    }*/
                }
                catch (FormatException)
                {
                    Console.WriteLine("Dato erroneo, intentelo nuevamente.");
                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                    Console.ReadKey();
                    Console.Clear();

                }
            } while (tipoVehiculo != "listo");

            Console.WriteLine("Ejecucion finalizada.");
            Console.ReadKey();

        }


    }
}
}
