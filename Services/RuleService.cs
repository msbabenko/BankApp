using MainGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MainGateway.Services
{
    public class RuleService
    {
        public string evaluateMinBal(int accountId,float balance)
        {
           string custDTO = " ";
            string account = null;
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("https://rules-ms.azurewebsites.net/api/");
                    var postTask = client.GetAsync("Rules/accountId?accountId=" + accountId+ "&balance="+balance);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadAsStringAsync();
                        data.Wait();
                        account = data.Result;

                      // custDTO = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return account;
        }

        public string getServiceCharges(double balance)
        {
            string account = null;
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("https://rules-ms.azurewebsites.net/api/");
                    var postTask = client.GetAsync("Rules?balance=" +  balance);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadAsStringAsync();
                        data.Wait();
                        account = data.Result;

                        // custDTO = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return account;
        }

    }
}
