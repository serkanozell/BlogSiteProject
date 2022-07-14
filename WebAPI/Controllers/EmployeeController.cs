using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataAccessLayer;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEmployeeList()
        {
            using var c = new Context();

            var list = c.Employees.ToList();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            using var c = new Context();

            var entity = c.Add(employee);
            c.SaveChanges();

            return Ok("Added!!");
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            using var context = new Context();
            var entity = context.Employees.Find(id);
            if (entity is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(entity);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            using var context = new Context();
            //var entity = context.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
            var entity = context.Employees.Find(id);
            if (entity is null)
            {
                return NotFound();
            }
            else
            {
                context.Remove(entity);
                context.SaveChanges();
                return Ok("Deleted!!");
            }
        }

        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            using var context = new Context();
            var entity = context.Find<Employee>(employee.EmployeeID);
            if (entity is null)
            {
                return NotFound();
            }
            else
            {
                entity.EmployeeName = employee.EmployeeName;
                context.Update(entity);
                context.SaveChanges();
                return Ok("Updated!!");
            }
        }
    }
}
