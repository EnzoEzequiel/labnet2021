using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp1_POO_vehiculos
{
    class Omnibus : TransportePublico , IReservable
    {

        public Omnibus(int pasajeros) : base(pasajeros)
        {

        }

        public override void Avanzar()
        {
            Console.WriteLine("el omnibus esta avanzando con muchos pasajeros.");
        }

        public override void Detenerse()
        {
            Console.WriteLine("el omnibus se esta deteniendo. ");
        }

        public void reservar()
        {
            Console.WriteLine("El omnibus a sido reservado para una fecha especifica de salida.");
        }

        public override string ToString()
        {
            return "Omnibus";
        }
    }
}
