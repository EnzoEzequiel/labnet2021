using Entities.EF;
using Logic.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.EF.Models;

namespace WebAPI.EF.Controllers
{
    public class SuppliersController : ApiController
    {
        private SuppliersLogic supplierLogic;
        public SuppliersController()
        {
            supplierLogic = new SuppliersLogic();
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                List<SupplierApiView> suppliersViews = new List<SupplierApiView>();
                List<Suppliers> suppliers = supplierLogic.GetAll();
                suppliersViews = suppliers.Select(s => new SupplierApiView
                {
                    Id = s.SupplierID,
                    Nombre = s.ContactName,
                    NombreCompania = s.CompanyName

                }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, suppliersViews);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var supplierView = new SupplierApiView();
                var supplier = supplierLogic.Encontrar(id);
                if (supplier != null)
                {
                    supplierView.Id = supplier.SupplierID;
                    supplierView.Nombre = supplier.ContactName;
                    supplierView.NombreCompania = supplier.CompanyName;
                    return Ok(supplierView);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] SupplierApiView supplierView)
        {
            try
            {
                var supplier = new Suppliers();
                supplier.ContactName = supplierView.Nombre;
                supplier.CompanyName = supplierView.NombreCompania;
                supplierLogic.Add(supplier);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody] SupplierApiView supplierView)
        {
            try
            {
                var supplier = new Suppliers();
                supplier.SupplierID = supplierView.Id;
                supplier.ContactName = supplierView.Nombre;
                supplier.CompanyName = supplierView.NombreCompania;
                supplierLogic.Update(supplier);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                supplierLogic.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (ExcepcionPersonalizada ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}



