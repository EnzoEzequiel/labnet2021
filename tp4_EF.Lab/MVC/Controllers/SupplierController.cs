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

            }).ToList();
            return View(supplierView);
        }

        public ActionResult Insert()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Insert(SupplierView supplierView)
        {
            try
            {
                Suppliers supplierEntity = new Suppliers
                {
                    
                    ContactName = supplierView.NombreSupplier
                    
                };

                logic.Add(supplierEntity);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }

        }

        public ActionResult Delete(int id)
        {
            logic.Delete(id);

            return RedirectToAction("Index");
        }

    }
}