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
    [Authorize]
    [EnableCors("MyPolicy")]


    public class AccountController : ControllerBase
    {
        private  readonly AccountService _accountservice;

        public AccountController(AccountService accountService)
        {
            _accountservice = accountService;
        }
        // GET: api/<AccountController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

      
        [HttpGet("{accountId}")]
        public async Task<AccountDTO> Get(int accountId)
        {
            return _accountservice.GetAccount(accountId);
        }

        [HttpGet("GetAccounts/{customerid}")]
        public async Task<IList<AccountDTO>> Getb(int customerid)
        {
            return _accountservice.GetCustomerAccounts(customerid);
        }

        // POST api/<AccountController>
        //[Route("/CreateAccount")]
        //[HttpPost]
        //public async Task<AccountDTO> Post([FromBody] AccountDTO customerId)
        //{
        //    return _accountservice.CreateAccount(customerId);

        //}

        // PUT api/<AccountController>/5
        [Route("getAccountStatement")]
        [HttpPost]
        public async Task<IList<AccountStatementDTO>> AccountStatement(StatementDTO statementDTO)
        {
            return _accountservice.GetAccountStatement(statementDTO);
        }
        [Route("CreateAccount")]
        [HttpPost]
        public async Task<string> Post([FromBody] AccountDTO customerId)
        {
            return _accountservice.CreateAccount(customerId);

        }



    }
}
