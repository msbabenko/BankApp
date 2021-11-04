using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainGateway.Services
{
   public interface ITokenServices
    {
        public string CreateToken(string Email);
    }
}
