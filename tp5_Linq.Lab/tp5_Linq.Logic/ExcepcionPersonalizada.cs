using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp5_Linq.Logic
{
    public class ExcepcionPersonalizada : Exception
    {
        public override string Message => "El id no fue encontrado y a devuelto NULL!!!";

    }
}
