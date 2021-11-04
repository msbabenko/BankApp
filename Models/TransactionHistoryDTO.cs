using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainGateway.Models
{
    public class TransactionHistoryDTO
    {
        public int TransactionId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public int? FromAccount { get; set; }
        public int? ToAccount { get; set; }
        public double? Amount { get; set; }
        public string TransactionStatus { get; set; }
    }
}
