using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp1_POO_vehiculos
{
    public abstract class TransportePublico
    {
        private int pasajeros;

        public TransportePublico(int pasajeros)
        {
            this.pasajeros = pasajeros;
        }

        public int Pasajeros
        {
            get { return pasajeros; }
        }

        public abstract void Avanzar();

        public abstract void Detenerse();

        
    }
}
