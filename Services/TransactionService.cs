using MainGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MainGateway.Services
{
    public class TransactionService
    {
        public TransactionStatusDTO DepositMoney(DepositDTO depositDTO)
        {
            TransactionStatusDTO transactionStatusDTO = null;
            string status = " ";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://account-ms.azurewebsites.net/api/");
                var PostTask = client.PostAsJsonAsync<DepositDTO>("Transaction/Deposit", depositDTO);
                PostTask.Wait();
                var Result = PostTask.Result;
                if (Result.IsSuccessStatusCode)
                {
                    var data = Result.Content.ReadFromJsonAsync<TransactionStatusDTO>();
                    data.Wait();
                    transactionStatusDTO = data.Result;
                  
                    status = "SUCESS";


                }
            }
            return transactionStatusDTO;
        }

        public TransactionStatusDTO WithdrawMoney(DepositDTO depositDTO)
        {
            TransactionStatusDTO transactionStatusDTO = null;
            string status = " ";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://account-ms.azurewebsites.net/api/");
                var PostTask = client.PostAsJsonAsync<DepositDTO>("Transaction/Withdraw", depositDTO);
                PostTask.Wait();
                var Result = PostTask.Result;
                if (Result.IsSuccessStatusCode)
                {
                    var data = Result.Content.ReadFromJsonAsync<TransactionStatusDTO>();
                    data.Wait();
                    transactionStatusDTO = data.Result;

                    status = "SUCESS";


                }
            }
            return transactionStatusDTO;
        }


        public TransactionStatusDTO Transfer(TransferDTO transferDTO)
        {
            TransactionStatusDTO transactionStatusDTO = null;
            string status = " ";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://account-ms.azurewebsites.net/api/");
                var PostTask = client.PostAsJsonAsync<TransferDTO>("Transaction/Transfer", transferDTO);
                PostTask.Wait();
                var Result = PostTask.Result;
                if (Result.IsSuccessStatusCode)
                {
                    var data = Result.Content.ReadFromJsonAsync<TransactionStatusDTO>();
                    data.Wait();
                    transactionStatusDTO = data.Result;

                    status = "SUCESS";


                }
            }
            return transactionStatusDTO;
        }
    }
}
