using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainGateway.Models
{
    public class AccountStatementDTO
    {
        public int TransactionId { get; set; }
        public int? AccountId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string Descriptions { get; set; }
        public DateTime? ValueDate { get; set; }
        public double? Amount { get; set; }
        public string TransactionType { get; set; }
        public string TransactionStatus { get; set; }
        public double? ClosingBalance { get; set; }
    }
}
