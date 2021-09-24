using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp5_Linq.Logic;

namespace tp5_Linq.Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoriesQueries categoriesQueries = new CategoriesQueries();
            CustomerQueries customersQueries = new CustomerQueries();
            ProductsQueries productsQueries = new ProductsQueries();
            bool finalizar = false;
            try
            {
                while (!finalizar)
                {
                    Console.WriteLine("Favor de seleccionar el numero de la consulta o 0 para finalizar.");
                    Console.WriteLine("1-Query para devolver objeto customer");
                    Console.WriteLine("2-Query para devolver todos los productos sin stock");
                    Console.WriteLine("3-Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad");
                    Console.WriteLine("4-Query para devolver todos los customers de la Región WA");
                    Console.WriteLine("5-Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");
                    Console.WriteLine("6-Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.");
                    Console.WriteLine("7-Query para devolver Join entre Customers y Orders donde los customers sean de la  Región WA y la fecha de orden sea mayor a 1 / 1 / 1997.");
                    Console.WriteLine("8-Query para devolver los primeros 3 Customers de la  Región WA");
                    Console.WriteLine("9-Query para devolver lista de productos ordenados por nombre");
                    Console.WriteLine("10-Query para devolver lista de productos ordenados por unit in stock de mayor a menor.");
                    Console.WriteLine("11-Query para devolver las distintas categorías asociadas a los productos");
                    Console.WriteLine("12-Query para devolver el primer elemento de una lista de productos");
                    Console.WriteLine("13-Query para devolver los customer con la cantidad de ordenes asociadas");
                    string opcion = Console.ReadLine();
                    switch (opcion)
                    {
                        case "0":
                            finalizar = true;
                            break;
                        case "1":
                            var customer = customersQueries.GetCustomer("AROUT");
                            Console.WriteLine(customer.ContactName);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "2":
                            productsQueries.OutOfStock().ForEach(p => Console.WriteLine($"{p.ProductName} | {p.UnitsInStock}"));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "3":
                            productsQueries.UnitPriceGreater().ForEach(p => Console.WriteLine($"{p.ProductName} | {p.UnitsInStock} | {p.UnitPrice}"));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "4":
                            customersQueries.FromWashington().ForEach(c => Console.WriteLine($"{c.ContactName} | {c.Region}"));
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "5":
                            var product = productsQueries.FirstElement();
                            
                            
                            if (product == null)
                            {
                                throw new ExcepcionPersonalizada();
                            }
                            else
                            {
                                Console.WriteLine(product.ProductName);
                            }
                            
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "6":
                            customersQueries.Names().ForEach(c => Console.WriteLine($"{c.NameUpper} | {c.NameLower}"));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "7":
                            customersQueries.JoinOrdersDate().ForEach(c => Console.WriteLine($"{c.CustomerName} | {c.OrderDate.ToShortDateString()}"));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "8":
                            customersQueries.WashingtonTop3().ForEach(c => Console.WriteLine(c.ContactName));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "9":
                            productsQueries.OrderByName().ForEach(p => Console.WriteLine(p.ProductName));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "10":
                            productsQueries.OrderByUnitStock().ForEach(p => Console.WriteLine($"{p.ProductName} | {p.UnitsInStock}"));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "11":
                            categoriesQueries.DistinctCategories().ForEach(c => Console.WriteLine(c.CategoryName));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "12":
                            Console.WriteLine(productsQueries.GetFirst().ProductName);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "13":
                            customersQueries.JoinOrdersCount().ForEach(c => Console.WriteLine($"{c.CustomerID} | {c.Order}"));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("!Error, intentelo nuevamente...");
                            break;
                    }
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
