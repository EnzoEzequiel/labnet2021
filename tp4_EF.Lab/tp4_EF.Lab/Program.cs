using Entities.EF;
using Logic.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp4_EF.Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            SuppliersLogic supplierLogic = new SuppliersLogic();
            TerritoriesLogic territorieLogic = new TerritoriesLogic();
            bool finalizar = false;
            while (!finalizar)
            {
                Console.WriteLine("Bienvenido!!!, seleccione una entidad o 3 para finalizar: ");
                Console.WriteLine("1-territories.");
                Console.WriteLine("2-suppliers.");
                Console.WriteLine("3-FINALIZAR.");
                string eleccion = Console.ReadLine();
                Console.Clear();
                try
                {
                    switch (eleccion)
                    {
                        case "1":
                            Console.WriteLine("Usted a seleccionado territories, favor de elegir la accion a realizar: ");
                            Console.WriteLine("1-Listar");
                            Console.WriteLine("2-Buscar elemento con id");
                            Console.WriteLine("3-Volver al menu de entidades.");
                            Console.WriteLine("4-Finalizar");
                            int opcionTerritorios = int.Parse(Console.ReadLine());
                            try
                            {
                                switch (opcionTerritorios)
                                {

                                    case 1:
                                        ListarTerritorios(territorieLogic);
                                        break;

                                    case 2:
                                        Console.Write("\nFavor de ingresar el id del territory a encontrar: ");
                                        var territory = territorieLogic.Encontrar(Console.ReadLine());
                                        Console.WriteLine($"ID: {territory.TerritoryID} | Descripcion: {territory.TerritoryDescription}");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;

                                    case 3:
                                        break;

                                    case 4:
                                        finalizar = true;
                                        break;

                                    default:
                                        Console.WriteLine("Error, ingrese nuevamente el numero");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                }
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine("se detecto una excepcion => {0} : {1}", ex.Message, ex.GetType());
                            }
                            break;
                          
                        case "2":
                            Console.WriteLine("Usted a seleccionado suppliers, favor de elegir la accion a realizar: ");
                            Console.WriteLine("1-Alta.");
                            Console.WriteLine("2-Baja");
                            Console.WriteLine("3-Modificacion");
                            Console.WriteLine("4-Listar");
                            Console.WriteLine("5-Buscar elemento con id");
                            Console.WriteLine("6-Volver al menu de entidades.");
                            Console.WriteLine("7-Finalizar");
                            int opcionSuppliers = int.Parse(Console.ReadLine());
                            try
                            {
                                switch (opcionSuppliers)
                                {
                                    case 1:
                                        Console.Write("\nIngrese nombre de la compañia: ");
                                        string companyName = Console.ReadLine();
                                        Console.Write("\nIngrese la direccion de la compañia: ");
                                        string address = Console.ReadLine();
                                        Console.Write("\nIngrese el pais de la compañia: ");
                                        string country = Console.ReadLine();
                                        var nuevoSupplier = new Suppliers()
                                        {
                                            CompanyName = companyName,
                                            Address = address,
                                            Country = country
                                        };
                                        supplierLogic.Add(nuevoSupplier);
                                        Console.WriteLine("El supplier fue adherido correctamente.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;

                                    case 2:
                                        Console.Write("\nFavor de ingresar el ID a eliminar: ");
                                        supplierLogic.Delete(int.Parse(Console.ReadLine()));
                                        Console.WriteLine("El supplier se ha eliminado correctamente");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;

                                    case 3:
                                        Console.Write("\nIngrese id de la compañia: ");
                                        int id = int.Parse(Console.ReadLine());
                                        Console.Write("\nIngrese nombre de la compañia: ");
                                        string nombreCompania = Console.ReadLine();
                                        Console.Write("\nIngrese la direccion de la compañia: ");
                                        string direccion = Console.ReadLine();
                                        Console.Write("\nIngrese el pais de la compañia: ");
                                        string pais = Console.ReadLine();
                                        supplierLogic.Update(new Suppliers
                                        {
                                            SupplierID = id,
                                            CompanyName = nombreCompania,
                                            Address = direccion,
                                            Country = pais
                                        });
                                        Console.WriteLine("El supplier se ha actualizado correctamente");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;

                                    case 4:
                                        ListarSuppliers(supplierLogic);
                                        break;

                                    case 5:
                                        Console.Write("\nFavor de ingresar el id del supplier a encontrar: ");
                                        var supplier = supplierLogic.Encontrar(int.Parse(Console.ReadLine()));
                                        Console.WriteLine($"ID: {supplier.SupplierID} | Nombre de compania: {supplier.CompanyName} | Pais: {supplier.Country} | Direccion de compania: {supplier.Address}");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;

                                    case 6:
                                        break;

                                    case 7:
                                        finalizar = true;
                                        break;

                                    default:
                                        Console.WriteLine("Error, ingrese nuevamente el numero");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                }
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine("se detecto una excepcion => {0} : {1}", ex.Message, ex.GetType());
                            }
                            break;
                        case "3":
                            finalizar = true; 
                            break;
                        default:
                            Console.WriteLine("Error, ingrese nuevamente un numero");
                            break;

                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (Exception ex)
                {
                    Console.WriteLine("se detecto una excepcion => {0} : {1}", ex.Message, ex.GetType());
                }

            }
            Console.WriteLine();
            Console.WriteLine("Aplicacion finalizada.");
        }
        static void ListarSuppliers(SuppliersLogic supplierLogic)
        {
            foreach (var supplier in supplierLogic.GetAll())
            {
                Console.WriteLine($"ID: {supplier.SupplierID} | Nombre de compania: {supplier.CompanyName} | Pais: {supplier.Country} | Direccion de compania: {supplier.Address}");
            }
        }
        

        static void ListarTerritorios(TerritoriesLogic territoriesLogic)
        {
            foreach (var territorie in territoriesLogic.GetAll())
            {
                Console.WriteLine($"ID: {territorie.TerritoryID} | Descripcion: {territorie.TerritoryDescription}");
            }
        }

    }
    
}
