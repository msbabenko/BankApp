using MainGateway.Models;
using MainGateway.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MainGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeServices _emloyeeservices;

        public EmployeeController(EmployeeServices employeeServices)
        {
            _emloyeeservices = employeeServices;
        }
        //// GET: api/<EmployeeController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<EmployeeController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> Post([FromBody] EmployeeDTO loginDto)
        {
            EmployeeDTO loginDto1 = _emloyeeservices.Register(loginDto);
            if (loginDto1 != null)
            {
                return Ok(loginDto1);
            }
            return BadRequest("ID Already Exists");
        }
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> Login([FromBody] EmployeeDTO loginDto)
        {
            EmployeeDTO dto = _emloyeeservices.Login(loginDto);
            if (dto != null)
            {
                return dto;
            }
            return BadRequest("Invalid User");
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{Employeeid}")]
        public void Put(int Employeeid, [FromBody] string value)
        {
        }

      
    }
}
