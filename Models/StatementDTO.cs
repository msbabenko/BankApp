using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainGateway.Models
{
    public class StatementDTO
    {
        public int AccountId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
