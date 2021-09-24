using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp5_Linq.Entities;
using tp5_Linq.Logic.NewFolder1;

namespace tp5_Linq.Logic
{
    public class CustomerQueries : BaseLogic
    {
        public Customers GetCustomer(string id)
        {
            var customer = context.Customers.Find(id.ToUpper());
            if (customer == null)
            {
                throw new ExcepcionPersonalizada();
            }
            return customer;

        }
        public List<Customers> FromWashington()
        {
            var customers = context.Customers.Where(c => c.Region == "WA");
            return customers.ToList();
        }
        public List<CustomerNames> Names()
        {
            var customers = from customer in context.Customers
                            select new CustomerNames()
                            {
                                NameLower = customer.ContactName.ToLower(),
                                NameUpper = customer.ContactName.ToUpper()
                            };
            return customers.ToList();
        }
        public List<CustomerJoin> JoinOrdersDate()
        {
            var customerOrders = from order in context.Orders
                                 join customer in context.Customers on
                                    order.CustomerID equals customer.CustomerID
                                 where customer.Region == "WA" && order.OrderDate > new DateTime(1997, 1, 1)
                                 select new CustomerJoin()
                                 {
                                     CustomerName = customer.ContactName,
                                     OrderDate = (DateTime)order.OrderDate
                                 };
            return customerOrders.ToList();
        }
        public List<Customers> WashingtonTop3()
        {
            var customers = (from customer in context.Customers
                             where customer.Region == "WA"
                             select customer)
                          .Take(3);
            return customers.ToList();
        }
        public List<CustomerOrderCount> JoinOrdersCount()
        {
            var customerOrders = from customers in context.Customers
                                 join orders in context.Orders on
                                    customers.CustomerID equals orders.CustomerID
                                 group customers by customers.CustomerID into cantidad
                                 select new CustomerOrderCount()
                                 {
                                     CustomerID = cantidad.Key,
                                     Order = cantidad.Count()
                                 };
            return customerOrders.ToList();
        }
    }
}
