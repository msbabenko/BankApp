using MainGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MainGateway.Services
{
    public class CustomerServices
    {
        private  readonly ITokenServices _tokenservice;
        private readonly AccountService _accountService;

        public CustomerServices(ITokenServices tokenServices, AccountService accountService)
        {
            _tokenservice = tokenServices;
            _accountService = accountService;
        }
        public CustomerDTO Register(CustomerDTO customerDTO)
        {
            CustomerDTO customer = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://52.226.236.115/api/");  //http://localhost:32389/api/ https://customer-ms.azurewebsites.net/api/
                var PostTask = client.PostAsJsonAsync<CustomerDTO>("Customer", customerDTO);
                PostTask.Wait();
                var Result = PostTask.Result;
                if (Result.IsSuccessStatusCode)
                {
                    var data = Result.Content.ReadFromJsonAsync<CustomerDTO>();
                    data.Wait();
                    customer = data.Result;
                    customer.JwtToken = _tokenservice.CreateToken(customer.Email);
                    
                    if (customer.CustomerID == 0) return customer;
                    AccountDTO account = new AccountDTO()
                    {
                        CustomerId = customer.CustomerID,
                       // AccountType = "SAVINGS",
                        Balance = 0
                    };

                    _accountService.CreateAccount(account);
                   // account.AccountType = "CURRENT";
                   // _accountService.CreateAccount(account);
                }
            }
            return customer;
        }
        public CustomerDTO Login(CustomerDTO customerDTO)
        {
            CustomerDTO customer = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://52.226.236.115/api/");
                var PostTask = client.PostAsJsonAsync<CustomerDTO>("Customer/Login", customerDTO);
                PostTask.Wait();
                var Result = PostTask.Result;
                if (Result.IsSuccessStatusCode)
                {
                    var data = Result.Content.ReadFromJsonAsync<CustomerDTO>();
                    data.Wait();
                    customer = data.Result;
                    customer.JwtToken = _tokenservice.CreateToken(customer.Email);
                }
            }
            return customer;
        }
        public CustomerDTO Update(int id, CustomerDTO customerDTO)
        {
            CustomerDTO customer = null;
            using (var client = new HttpClient()) 
            {
                client.BaseAddress = new Uri("http://52.226.236.115/api/"); // http://localhost:32389/ //https://customer-ms.azurewebsites.net/api/
                var PutTask = client.PutAsJsonAsync<CustomerDTO>("Customer/" + id, customerDTO);
                PutTask.Wait();
                var Result = PutTask.Result;
                if (Result.IsSuccessStatusCode)
                {
                    var data = Result.Content.ReadFromJsonAsync<CustomerDTO>();
                    data.Wait();
                    customer = data.Result;
                  
                }
            }
            return customer;
        }

        public CustomerDTO GetCustomer(int id)
        {
            CustomerDTO custDTO = null;

            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://52.226.236.115/api/");
                    var postTask = client.GetAsync("Customer/" + id);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<CustomerDTO>();
                        data.Wait();
                        custDTO = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return custDTO;
        }

        public ICollection<CustomerDTO> GetAllCustomerDetails()
        {
            List<CustomerDTO> cust = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://52.226.236.115/api/");
                    // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var getTask = client.GetAsync("Customer");
                    getTask.Wait();
                    var result = getTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync< List<CustomerDTO>>();
                        data.Wait();
                        cust = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return cust;
        }

    }
}
