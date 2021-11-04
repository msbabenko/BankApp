using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainGateway.Models
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string JwtToken { get; set; }
    }
}
