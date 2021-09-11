using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logica
{
    public class NegativeException : Exception
    {
        private string customMsg;
        public NegativeException(string customMsg) : base("mensaje de NegativeException")
        {
            this.customMsg = customMsg;
        }
        public override string Message => ($"{customMsg} : {base.Message}");

    }
    
}
