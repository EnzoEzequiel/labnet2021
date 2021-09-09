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
            int ingresos = 0;
            Taxi taxisito;
            Omnibus ominisito;

            List<TransportePublico> listaVehiculos = new List<TransportePublico>();

            do
            {
            
                Console.WriteLine("Favor de Ingresar el tipo de vehiculo (taxi u omnibus) o 'listo' para finalizar: ");
                tipoVehiculo = Console.ReadLine();

                if (tipoVehiculo.ToLower() == "taxi")
                {
                    ingresos++;
                    Console.WriteLine("Ahora favor de ingresar la cantidad de pasajeros: ");
                    taxisito = new Taxi(int.Parse(Console.ReadLine()));
                    listaVehiculos.Add(taxisito);

                }
                else
                {
                    if (tipoVehiculo.ToLower() == "omnibus")
                    {
                        ingresos++;
                        Console.WriteLine("Ahora favor de ingresar la cantidad de pasajeros: ");
                        ominisito = new Omnibus(int.Parse(Console.ReadLine()));
                        listaVehiculos.Add(ominisito);
                    }
                    else
                    {
                        Console.WriteLine("Ingreso erroneo, favor de reintentar ingresar el tipo de vehiculo (taxi u omnibus) o 'listo' para finalizar:");
                        tipoVehiculo = Console.ReadLine();
                    }
                }
 
                
            } while (tipoVehiculo != "listo" && ingresos<10);

            Console.WriteLine("los vehiculos son: ");
            for (int i = 0; i < listaVehiculos.Count; i++)
            {
                Console.WriteLine("{0} {1}= {2}", listaVehiculos[i].ToString(), i + 1, listaVehiculos[i].Pasajeros);
            }

            Console.WriteLine("Ejecucion finalizada con "+ingresos+" ingresos");

            
            Console.ReadKey();

        }


    }
}

