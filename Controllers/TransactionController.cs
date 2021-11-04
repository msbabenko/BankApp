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
    public class TransactionController : ControllerBase
    {
        private  readonly TransactionService _service;

        public TransactionController(TransactionService transactionService)
        {
            _service = transactionService;
        }
       
       

        // POST api/<TransactionController>
        [Route("Deposit")]
        [HttpPost]
        public async Task<ActionResult<TransactionStatusDTO>> Deposit([FromBody] DepositDTO value)
        {
            return _service.DepositMoney(value);
        }

        [Route("Withdraw")]
        [HttpPost]
        public async Task<ActionResult<TransactionStatusDTO>> Withdraw([FromBody] DepositDTO value)
        {
            return _service.WithdrawMoney(value);
        }

        [Route("Transfer")]
        [HttpPost]
        public async Task<ActionResult<TransactionStatusDTO>> Transfer([FromBody] TransferDTO value)
        {
            return _service.Transfer(value);
        }
    }
}
