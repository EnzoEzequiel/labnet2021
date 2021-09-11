using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public static class MyExtension
    {
        public static string MensajeExtension(this Exception e)
        {
            //extension para devolver el mensaje 
            return ($"{e.Message} : {e.GetType()}");
        }

    }
}
