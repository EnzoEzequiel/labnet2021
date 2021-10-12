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
                return Request.CreateResponse(HttpStatusCode.OK, supplierLogic.GetAll());
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
                return Ok(supplierLogic.Encontrado(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] Suppliers shippers)
        {
            try
            {
                supplierLogic.Add(shippers);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody] Suppliers shippers)
        {
            try
            {
                supplierLogic.Update(shippers);
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
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}



