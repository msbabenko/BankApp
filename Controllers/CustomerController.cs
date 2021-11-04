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

    public class CustomerController : ControllerBase
    {
        private readonly CustomerServices _customerservices;

        public CustomerController(CustomerServices customerServices)
        {
            _customerservices = customerServices;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<CustomerDTO> Get()
        {
            var orders = _customerservices.GetAllCustomerDetails();
            return orders;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{Customerid}")]
       
        public async Task<CustomerDTO> Get(int Customerid)
        {
            return _customerservices.GetCustomer(Customerid);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> Post([FromBody] CustomerDTO loginDto)
        {
            CustomerDTO loginDto1 = _customerservices.Register(loginDto);
            if (loginDto1 != null)
            {
                return Ok(loginDto1);
            }
            return BadRequest("ID Already Exists");
        }

        // PUT api/<CustomerController>/5
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> Login([FromBody] CustomerDTO loginDto)
        {
            CustomerDTO dto = _customerservices.Login(loginDto);
            if (dto != null)
            {
                return dto;
            }
            return BadRequest("Invalid User");
        }

        [Route("Update")]
        [HttpPost]
        public ActionResult<CustomerDTO> Update([FromBody] CustomerDTO customer)
        {
            var CustomerDTO = _customerservices.Update(customer);
            if (CustomerDTO != null)
                return Ok(CustomerDTO);
            return BadRequest("Please Enter Valid CustomerID");

        }
    }
}
