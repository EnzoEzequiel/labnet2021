using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logic
    {
        
        public void ThrowException()
        {
            throw new InvalidOperationException();
        }
        public void ThrowExceptionCustomized(string message, int numerito)
        {
            if (numerito < 0)
            {
                throw new NegativeException(message);
            }
            
        }

    }
}
