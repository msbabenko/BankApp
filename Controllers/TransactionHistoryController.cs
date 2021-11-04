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
    public class TransactionHistoryController : ControllerBase
    {
        private  readonly TransactionMSService _service;

        public TransactionHistoryController(TransactionMSService transactionService)
        {
            _service = transactionService;
        }
        // GET: api/<TransactionHistoryController>
        [HttpGet("getTransactions/{Accountid}")]
        public async Task<ActionResult<IList<TransactionHistoryDTO>>> Get(int Accountid)
        {
            return _service.getTransactions(Accountid);
        }


        // POST api/<TransactionHistoryController>
        [Route("Deposit")]
        [HttpPost]
        public async Task<ActionResult<string>> Deposit([FromBody] DepositDTO value)
        {
            return _service.DepositMoney(value);
        }

        [Route("Withdraw")]
        [HttpPost]
        public async Task<ActionResult<string>> Withdraw([FromBody] DepositDTO value)
        {
            return _service.WithdrawMoney(value);
        }


        [Route("Transfer")]
        [HttpPost]
        public async Task<ActionResult<StatusDTO>> Transfer([FromBody] TransferDTO value)
        {
            return _service.Transfer(value);
        }

    }
}
