using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace IGU
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic custom = new Logic();

            

            Console.WriteLine("Ejercicio 1: ");
            Console.WriteLine("Favor de ingresar un valor: ");
            Punto1();


            Console.WriteLine("Ejercicio 2: ");
            Punto2();
            Console.ReadKey();


            Console.WriteLine("Ejercicio 3: ");
            try
            {
                custom.ThrowException();
            }
            catch (Exception x)
            {
                Console.WriteLine(x.MensajeExtension());
            }
            Console.ReadKey();

            Console.WriteLine("Ejercicio 4: ");
            try
            {
                
                custom.ThrowExceptionCustomized("Mensaje de excepcion: ", -1);
            }
            catch (NegativeException e)
            {
                MessageBox.Show(e.Message);
            }
            Console.ReadKey();


            Console.WriteLine("Programa finalizado.");

            Console.ReadKey();
        }


        public static void Punto1()
        {
            try
            {
                Division div = new Division();
                div.DivisionPorCero(int.Parse(Console.ReadLine()));
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("La operación a finalizado.");
            }
        }

        public static void Punto2()
        {
            
            try
            {
                Division div = new Division();
                Console.WriteLine("Ingrese divisor: ");
                int divisor = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese dividendo: ");
                int dividendo = int.Parse(Console.ReadLine());
                int resultado = div.DivisionIngresado(dividendo, divisor);
                Console.WriteLine("El resultado de la división es: {0}", resultado);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!: {0}", ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Solo Chuck Norris divide por cero!: {0}", ex.Message);
            }
        }


    }
 
}
