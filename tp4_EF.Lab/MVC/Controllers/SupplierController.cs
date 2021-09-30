using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.EF;
using Logic.EF;
using MVC.Models;

namespace MVC.Controllers
{
    public class SupplierController : Controller
    {
        SuppliersLogic logic = new SuppliersLogic();
        // GET: Supplier
        public ActionResult Index()
        {
            
            List<Entities.EF.Suppliers> suppliers = logic.GetAll();

            List<SupplierView> supplierView = suppliers.Select(s => new SupplierView
            {
                Id = s.SupplierID,
                NombreSupplier = s.ContactName,
                CompaniaSupplier=s.CompanyName

            }).ToList();
            return View(supplierView);
        }
        
        public ActionResult InsertUpdate(int? id)
        {

            SupplierView supplier = new SupplierView();
            if (id != null)
            {
                var sup = logic.Encontrar(id);
                supplier.CompaniaSupplier = sup.CompanyName;
                supplier.NombreSupplier = sup.ContactName;
            }
            return View(supplier);
        }
        
        [HttpPost]
        public ActionResult InsertUpdate(SupplierView supplierView)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("index", "Error");
                }
                else
                {
                    Suppliers supplierEntity = new Suppliers
                    {
                        SupplierID = supplierView.Id,
                        CompanyName = supplierView.CompaniaSupplier,
                        ContactName = supplierView.NombreSupplier

                    };
                    if (supplierView.Id == 0)
                    {
                        logic.Add(supplierEntity);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        logic.Update(supplierEntity);
                        return RedirectToAction("index");
                    }
                }
               
           }
           catch (Exception ex)
           {
               return RedirectToAction("index", "Error", new { mssg = ex.Message });
           }
        }

        [HttpGet]
        public bool Delete(int id)
        {
            try
            {
                logic.Delete(id);
                return true;
            }
            catch
            {
                Response.StatusCode = 422;
                return false;
            }
        }

    }
}