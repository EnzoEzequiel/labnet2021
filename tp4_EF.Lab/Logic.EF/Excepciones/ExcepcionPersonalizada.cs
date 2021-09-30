using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.EF
{
    public class ExcepcionPersonalizada:Exception
    {
        public override string Message => "El id no fue encontrado y a devuelto NULL!!!";
        
    }
}
