using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (OrganizationDBModel entities = new OrganizationDBModel())
            {
                return entities.Employees.ToList();
            }
        }

        public Employee Get(int id)
        {
            using (OrganizationDBModel entities = new OrganizationDBModel())
            {
                return entities.Employees.FirstOrDefault(e => e.ID == id);

            }
        }
    }
}
