using MainGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MainGateway.Services
{
    public class TransactionMSService
    {
        //public string DepositMoney(DepositDTO depositDTO)
        //{

        //    string status = "";
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:19422/api/");
        //        var postTask = client.PostAsJsonAsync<DepositDTO>("Transaction/Deposit", depositDTO);
        //        postTask.Wait();
        //        var result = postTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var data = result.Content.ReadFromJsonAsync<StatusDTO>();
        //            data.Wait();
        //            status = data.Result.status;

        //        }
        //    }

        //    return status;




        //}


        public string DepositMoney(DepositDTO depositDTO)
        {
            try { 
         
                string status = "";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://transaction-ms.azurewebsites.net/api/");
                    var postTask = client.PostAsJsonAsync<DepositDTO>("TransactionHistory/Deposit", depositDTO);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadAsStringAsync();
                        data.Wait();
                        status = data.Result;

                    }

                }
                return status;
            }
            catch (Exception)
            {

                return "SERRVER DOWN";
            }



        }



        //public TransactionStatusDTO DepositMoney(DepositDTO depositDTO)
        //{
        //    TransactionStatusDTO transactionStatusDTO = null;
        //    string status = " ";
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:19422/api/");
        //        var PostTask = client.PostAsJsonAsync<DepositDTO>("Deposit", depositDTO);
        //        PostTask.Wait();
        //        var Result = PostTask.Result;
        //        if (Result.IsSuccessStatusCode)
        //        {
        //            var data = Result.Content.ReadFromJsonAsync<TransactionStatusDTO>();
        //            data.Wait();
        //            transactionStatusDTO = data.Result;

        //            status = "SUCESS";


        //        }
        //    }
        //    return transactionStatusDTO;
        //}

        public string WithdrawMoney(DepositDTO depositDTO)
        {
            try
            {
                string status = "";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://transaction-ms.azurewebsites.net/api/");
                    var postTask = client.PostAsJsonAsync<DepositDTO>("TransactionHistory/Withdraw", depositDTO);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadAsStringAsync();
                        data.Wait();
                        status = data.Result;

                    }
                }
              
                return status;
            }
            catch (Exception)
            {

                return "SERRVER DOWN";
            }

        }

        public StatusDTO Transfer(TransferDTO transferDTO)
        {
            StatusDTO statusDTO = new();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://transaction-ms.azurewebsites.net/api/");
                    var postTask = client.PostAsJsonAsync<TransferDTO>("TransactionHistory/Transfer", transferDTO);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<StatusDTO>();
                        data.Wait();
                        statusDTO = data.Result;

                    }
                }
            }
            catch (Exception)
            {

                return null;
            }


            return statusDTO;
        }
        public List<TransactionHistoryDTO> getTransactions(int customerId)
        {
            List<TransactionHistoryDTO> cust = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://transaction-ms.azurewebsites.net/api/");
                    // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var getTask = client.GetAsync("TransactionHistory/getTransactions/" + customerId);
                    getTask.Wait();
                    var result = getTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<List<TransactionHistoryDTO>>();
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
