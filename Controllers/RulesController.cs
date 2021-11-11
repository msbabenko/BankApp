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
   // [Authorize]
    [EnableCors("MyPolicy")]
    public class RulesController : ControllerBase
    {
        private readonly RuleService _ruleService;

        public RulesController(RuleService ruleService)
        {
            _ruleService = ruleService;
        }
        // GET: api/<RulesController>


        [HttpGet("Accountid")]
        public string evaluateMinBal(int Accountid, [FromQuery] float balance)
        {
            return _ruleService.evaluateMinBal(Accountid, balance);

        }
        [Route("/getServiceCharges")]
        // POST api/<RulesController>
        [HttpGet]
        public double getServiceCharges([FromQuery] double balance)
        {
           double value = _ruleService.getServiceCharges(balance);
            if(value==0)
            {
                return 0;
            }
            else
            {
                return value;
            }
          
        }
        // PUT api/<RulesController>/5
       
    }
}
