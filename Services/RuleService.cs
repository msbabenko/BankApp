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
           //string custDTO = " ";
            string account = null;
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://20.81.77.63/api/");
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

        public double getServiceCharges(double balance)
        {
            double account = 0;
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://20.81.77.63/api/");
                    var postTask = client.GetAsync("Rules?balance=" +  balance);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadAsStringAsync();
                        data.Wait();
                        account = Convert.ToDouble(data.Result);

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
