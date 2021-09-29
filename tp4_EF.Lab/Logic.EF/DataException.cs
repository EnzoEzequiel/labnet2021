using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.EF
{
    public class DataException : Exception
    {
        public override string Message => "El dato ingresado no esta permitido";
       

    }
}
