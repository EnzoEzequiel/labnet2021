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
            int ingresos = 0;
            string respuesta = "si";
            Taxi taxi;
            Omnibus omnibus;

            List<TransportePublico> listaVehiculos = new List<TransportePublico>();

            while (respuesta != "no" && ingresos < 5)
            {
                ingresos++;
                Console.WriteLine("favor de ingresar la cantidad de pasajeros del omnibus {0}: ",ingresos);
                try
                {
                    
                    omnibus = new Omnibus(int.Parse(Console.ReadLine()));
                    while (omnibus.Pasajeros > 100 || omnibus.Pasajeros < 0)
                    {
                        Console.WriteLine("un Omnibus no puede llevar mas de 100 personas ni se pueden ingresar numeros negativos");
                        Console.WriteLine("Ahora favor de ingresar la cantidad de pasajeros del omnibus {0}: ", ingresos);
                        omnibus = new Omnibus(int.Parse(Console.ReadLine()));
                    }

                    listaVehiculos.Add(omnibus);
                    
                    Console.WriteLine("Ingresado con exito!!");
                    Console.ReadKey(); 
                    Console.Clear();
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("dato ingresado erroneo, desea continuar?  (si/no): ");
                    respuesta = Console.ReadLine();
                    ingresos--;
                }
            }
            while (respuesta != "no" && ingresos < 10)
            {

                ingresos++;
                Console.WriteLine("Ahora favor de ingresar la cantidad de pasajeros del taxi {0}: ",(ingresos-5));
                try
                {
                    
                    taxi = new Taxi(int.Parse(Console.ReadLine()));
                    while (taxi.Pasajeros > 4 || taxi.Pasajeros < 0)
                    {
                        Console.WriteLine("un taxi no puede llevar mas de 4 personas ni se pueden ingresar numeros negativos");
                        Console.WriteLine("Ahora favor de ingresar la cantidad de pasajeros del taxi {0}: ", (ingresos - 5));
                        taxi = new Taxi(int.Parse(Console.ReadLine()));
                    }

                    listaVehiculos.Add(taxi);
                    
                    Console.WriteLine("Ingresado con exito!!");
                    Console.ReadKey();
                    Console.Clear();
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("dato ingresado erroneo, desea continuar?  (si/no): ");
                    respuesta = Console.ReadLine();
                    ingresos--;
                }
            }



            Console.WriteLine(" ");
            Console.WriteLine("Los vehiculos son: ");
            Console.WriteLine(" ");
            for (int i = 0; i < listaVehiculos.Count; i++)
            {
                Console.WriteLine("{0} {1}: {2}", listaVehiculos[i].ToString(), i + 1, listaVehiculos[i].Pasajeros);
            }
            Console.WriteLine(" ");

            Console.WriteLine("Ejecucion finalizada con " + ingresos + " vehiculos");


            Console.ReadKey();




        }


    }
}

