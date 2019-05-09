using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreEFAPI.Models;
using DotNetCoreEFAPI.Models.Repository;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreEFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDataRepository<Employee> _dataRepository;

        public EmployeeController(IDataRepository<Employee> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        /// <summary>
        /// Gets all employees
        /// </summary>
        /// <returns></returns>
        // GET: api/Employee
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            IEnumerable<Employee> employees = _dataRepository.GetAll();
            return Ok(employees);
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _dataRepository.Get(id);

                if (employee == null)
                {
                    return NotFound("The Employee record couldn't be found.");
                }
                return Ok(employee);
            }
            return BadRequest(ModelState);
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee == null)
                {
                    return BadRequest("Employee is null.");
                }

                _dataRepository.Add(employee);
                return CreatedAtRoute(
                      "Get",
                      new { Id = employee.EmployeeId },
                      employee);

            }
            return BadRequest(ModelState);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee == null)
                {
                    return BadRequest("Employee is null.");
                }

                Employee employeeToUpdate = _dataRepository.Get(id);
                if (employeeToUpdate == null)
                {
                    return NotFound("The Employee record couldn't be found.");
                }

                _dataRepository.Update(employeeToUpdate, employee);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _dataRepository.Get(id);
                if (employee == null)
                {
                    return NotFound("The Employee record couldn't be found.");
                }

                _dataRepository.Delete(employee);
                return NoContent();
            }
            return BadRequest(ModelState);
        }
    }
}