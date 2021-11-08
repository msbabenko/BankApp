using MainGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MainGateway.Services
{
    public class AccountService
    {


        //public AccountDTO CreateAccount(AccountDTO customerId)
        //{
        //    AccountDTO account = null;
        //    string status = "SUCESS ";
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:49937/api/");
        //        var PostTask = client.PostAsJsonAsync<AccountDTO>("Account/CreateAccount", customerId);
        //        PostTask.Wait();
        //        var Result = PostTask.Result;
        //        if (Result.IsSuccessStatusCode)
        //        {
        //            var data = Result.Content.ReadFromJsonAsync<AccountDTO>();
        //            data.Wait();
        //           account = data.Result;
        //          //  status = data.Result;
        //            account.CustomerId = customerId.CustomerId;
        //        //   status = "SUCESS";


        //        }
        //    }
        //    return account;
        //}


        public string CreateAccount(AccountDTO customerId)
        {
            AccountDTO account = null;
            string status = "SUCESS ";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://account-ms.azurewebsites.net/api/");
                var PostTask = client.PostAsJsonAsync<AccountDTO>("Account/CreateAccount", customerId);
                PostTask.Wait();
                var Result = PostTask.Result;
                if (Result.IsSuccessStatusCode)
                {
                    var data = Result.Content.ReadAsStringAsync();
                    data.Wait();
                   // account = data.Result;
                      status = data.Result;
                   // account.CustomerId = customerId.CustomerId;
                    //   status = "SUCESS";


                }
            }
            return status;
        }
        public AccountDTO GetAccount(int accountId)
        {
            AccountDTO accountDTO = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://account-ms.azurewebsites.net/api/");
                    var postTask = client.GetAsync("Account/" + accountId);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<AccountDTO>();
                        data.Wait();
                        accountDTO = data.Result;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return accountDTO;
        }


        public IList<AccountDTO> GetCustomerAccounts(int customerId)
        {
            IList<AccountDTO> customeraccountDTO  = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://account-ms.azurewebsites.net/api/");
                    var postTask = client.GetAsync("Account/GetAccounts/" + customerId);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<IList<AccountDTO>>();
                        data.Wait();
                        customeraccountDTO = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return customeraccountDTO;
        }

        public IList<AccountStatementDTO> GetAccountStatement(StatementDTO statementDTO)
        {
            IList<AccountStatementDTO> customeraccountDTO = null;
           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://account-ms.azurewebsites.net/api/");
                var PostTask = client.PostAsJsonAsync<StatementDTO>("Account/getAccountStatement", statementDTO);
                PostTask.Wait();
                var Result = PostTask.Result;
                if (Result.IsSuccessStatusCode)
                {
                    var data = Result.Content.ReadFromJsonAsync<IList<AccountStatementDTO>>();
                    data.Wait();
                    customeraccountDTO = data.Result;
                }
            }
            return customeraccountDTO;
        }
    }
}
