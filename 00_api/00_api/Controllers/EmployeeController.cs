using EmployAccessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _00_api.Controllers
{
    public class EmployeeController : ApiController
    {
        // Here make the 
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            using(EmployeeDBEntities db = new EmployeeDBEntities())
            {
                return db.Employees.ToList();
            }
        }

        // http get id
        [HttpGet]
        public Employee Get(int id)
        {
            using(EmployeeDBEntities db = new EmployeeDBEntities())
            {
                var rid = db.Employees.FirstOrDefault(s => s.Id == id);
                    return rid;
            }
        }


        // post the data

        [HttpPost]
        public HttpResponseMessage Post([FromBody] Employee employee)
        {
            try
            {

            using (EmployeeDBEntities db = new EmployeeDBEntities())
            {
                db.Employees.Add(employee);
                db.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created); ;
                    message.Headers.Location = new Uri(Request.RequestUri + employee.Id.ToString());
                    return message;
            }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest.ToString());
            }
        }

        [HttpPut]
        public void Put(int id, [FromBody] Employee employee)
        {
            using (EmployeeDBEntities db = new EmployeeDBEntities())
            {
                // firstly take the id
                var takeId = db.Employees.FirstOrDefault(e => e.Id == id);
                takeId.Name = employee.Name;
                takeId.Age = employee.Age;
                takeId.Gender = employee.Gender;
                takeId.Salary = employee.Salary;

                db.SaveChanges();
            }
            
        }


        // for delete
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            using (EmployeeDBEntities db = new EmployeeDBEntities())
            {
                db.Employees.Remove(db.Employees.FirstOrDefault(d => d.Id == id));
                db.SaveChanges();


                if(db!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK.ToString());
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee Id is Not " +id.ToString()+ "Found");
                }

            }
        }
    }

}
