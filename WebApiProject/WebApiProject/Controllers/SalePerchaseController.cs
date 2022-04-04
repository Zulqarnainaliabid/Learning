using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    public class SalePerchaseController : ApiController
    {
        public IEnumerable<SalePerchase> Get()
        {
            using (ItemDataModel entities = new ItemDataModel())
            {
                return entities.SalePerchases.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (ItemDataModel entities = new ItemDataModel())
            {
                var entity = entities.SalePerchases.FirstOrDefault(e => e.ID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                        "Employee Width id = " + id.ToString() + "Not Found");
                }
            }
        }

        public HttpResponseMessage Post([FromBody] SalePerchase item)
        {
            try
            {
                using (ItemDataModel entities = new ItemDataModel())
                {
                    entities.SalePerchases.Add(item);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, item);
                    message.Headers.Location = new Uri(Request.RequestUri + item.ID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (ItemDataModel entities = new ItemDataModel())
                {
                    var entity = entities.SalePerchases.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        entities.SalePerchases.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        public HttpResponseMessage Put(int id, [FromBody]SalePerchase employee)
        {
            try
            {
                using (ItemDataModel entities = new ItemDataModel())
                {
                    var entity = entities.SalePerchases.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id " + id.ToString() + " not found to update");
                    }
                    else
                    {
                        entity.DateAdded = employee.DateAdded;
                        entity.DateUpdate = employee.DateUpdate;
                        entity.Perchase = employee.Perchase;
                        entity.Price = employee.Price;
                        entity.Sale = employee.Sale;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
}
}
