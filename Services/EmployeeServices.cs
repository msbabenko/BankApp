using MainGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MainGateway.Services
{
    public class EmployeeServices
    {
        private readonly ITokenServices _tokenService;

        public EmployeeServices(ITokenServices tokenServices)
        {
            _tokenService = tokenServices;
        }
        public EmployeeDTO Register(EmployeeDTO employeeDTO)
        {
            EmployeeDTO employee = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://employee-ms.azurewebsites.net/api/");
                var PostTask = client.PostAsJsonAsync<EmployeeDTO>("Employee", employeeDTO);
                PostTask.Wait();
                var Result = PostTask.Result;
                if (Result.IsSuccessStatusCode)
                {
                    var data = Result.Content.ReadFromJsonAsync<EmployeeDTO>();
                    data.Wait();
                    employee = data.Result;
                    employee.JwtToken = _tokenService.CreateToken(employee.Email);
                }
            }
            return employee;
        }

        public EmployeeDTO Login(EmployeeDTO employeeDTO)
        {
            EmployeeDTO employee = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://employee-ms.azurewebsites.net/api/");
                var PostTask = client.PostAsJsonAsync<EmployeeDTO>("Employee/Login", employeeDTO);
                PostTask.Wait();
                var Result = PostTask.Result;
                if (Result.IsSuccessStatusCode)
                {
                    var data = Result.Content.ReadFromJsonAsync<EmployeeDTO>();
                    data.Wait();
                    employee = data.Result;
                    employee.JwtToken = _tokenService.CreateToken(employee.Email);
                }
            }
            return employee;
        }
    }
}
