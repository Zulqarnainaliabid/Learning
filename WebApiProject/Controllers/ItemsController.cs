using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    public class ItemsController : ApiController
    {
        public IEnumerable<Item> Get()
        {
            using (ItemDataModel entities = new ItemDataModel())
            {
                return entities.Items.ToList();
            } 
        }

        public HttpResponseMessage Get(int id)
        {
            using (ItemDataModel entities = new ItemDataModel())
            {
                var entity = entities.Items.FirstOrDefault(e => e.ID == id);
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

        public HttpResponseMessage Post([FromBody] Item item)
        {
            try
            {
                using (ItemDataModel entities = new ItemDataModel())
                {
                    entities.Items.Add(item);
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
                    var entity = entities.Items.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        entities.Items.Remove(entity);
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

        // first changes;
        public HttpResponseMessage Put(int id, [FromBody]Item employee)
        {
            try
            {
                using (ItemDataModel entities = new ItemDataModel())
                {
                    var entity = entities.Items.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, 
                            "Employee with Id " + id.ToString() + " not found to update");
                    }
                    else  
                    {
                        entity.DateAdded = employee.DateAdded;
                        entity.DateUpdated = employee.DateUpdated;
                        entity.Discription = employee.Discription;
                        entity.Img = employee.Img;
                        entity.is_active = employee.is_active; 
                        entity.Name = employee.Name;
                        entity.Other = employee.Other;
                        entity.ShortName = employee.ShortName;
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
