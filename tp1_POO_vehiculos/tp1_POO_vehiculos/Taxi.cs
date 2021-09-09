using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp1_POO_vehiculos
{
    class Taxi : TransportePublico
    {
        public Taxi(int pasajeros) : base(pasajeros)
        {

        }

        public override void Avanzar()
        {
            Console.WriteLine("el taxi esta avanzando .");
        }

        public override void Detenerse()
        {
            Console.WriteLine("el taxi se esta deteniendo. ");
        }

        public override string ToString()
        {
            return "Taxi";
        }
    }
}
