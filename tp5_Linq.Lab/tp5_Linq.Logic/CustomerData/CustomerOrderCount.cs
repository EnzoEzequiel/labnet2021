using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp5_Linq.Logic.NewFolder1
{
    public class CustomerOrderCount
    {
        private string customerID;
        private int order;
        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
        public int Order
        {
            get { return order; }
            set { order = value; }
        }
    }
}
