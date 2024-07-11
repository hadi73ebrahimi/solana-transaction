using Newtonsoft.Json;
using SolanaTransactions.Enums;
using SolanaTransactions.Models;
using SolanaTransactions.Transaction;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SolanaTransactions.Controllers
{
    public class SolanaTransactionsManager
    {
        private readonly HttpClient _httpClient;
        private Dictionary<string, TokenModel> _tokens = new Dictionary<string, TokenModel>();

        public EnDownloaderStatus CurrentStatus { get; private set; }

        public SolanaTransactionsManager(string rpcUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(rpcUrl) };
        }

        public async Task<Dictionary<string, TokenModel>> GetTransactions(string[] tokenAddresses)
        {
            CurrentStatus = EnDownloaderStatus.Started;
            InitTokens(tokenAddresses);
            await DownloadTransactionsAsync(tokenAddresses);
            CurrentStatus = EnDownloaderStatus.Finished;
            return _tokens;
        }

        private void InitTokens(string[] tokenAddresses)
        {
            foreach (var addre in tokenAddresses)
            {
                _tokens.Add(addre, new TokenModel());
            }
        }

        private async Task DownloadTransactionsAsync(string[] tokenAddresses)
        {
            foreach (var tokenAddress in tokenAddresses)
            {
                string lastSignature = null;
                while (true)
                {
                    var signatures = await GetSignaturesForAddressAsync(tokenAddress, limit: 1000, lastSignature);

                    if (signatures == null || signatures.Count == 0)
                        break;

                    foreach (var signature in signatures)
                    {
                        
                        while (true)
                        {

                            var transaction = await GetTransactionAsync(signature, 0);

                            var transactionmodel = JsonConvert.DeserializeObject<Rootobject>(transaction);

                            if (transactionmodel != null)
                            {
                                _tokens[tokenAddress].Transactions.Add(transactionmodel);
                            }
                            await Task.Delay(150);
                            break;
                        }

                    }

                    if (signatures.Count < 1000)
                        break;

                    lastSignature = signatures[^1];
                }
            }
        }

        private async Task<string> GetTransactionAsync(string signature, int maxSupportedTransactionVersion)
        {
            var requestContent = new
            {
                jsonrpc = "2.0",
                id = 1,
                method = "getTransaction",
                @params = new object[] { signature, new { encoding = "json", maxSupportedTransactionVersion } }
            };

            string responseContent;
            while (true)
            {
                try
                {
                    var response = await _httpClient.PostAsync("", new StringContent(JsonConvert.SerializeObject(requestContent), Encoding.UTF8, "application/json"));
                    response.EnsureSuccessStatusCode();
                    responseContent = await response.Content.ReadAsStringAsync();
                    break;

                }
                catch (Exception)
                {

                }
            }

            return responseContent;
        }

        private async Task<List<string>> GetSignaturesForAddressAsync(string tokenAddress, int limit, string lastSignature = null)
        {
            var requestContent = new
            {
                jsonrpc = "2.0",
                id = 1,
                method = "getSignaturesForAddress",
                @params = new object[]
                {
                tokenAddress,
                new Dictionary<string, object>
                {
                    { "limit", limit },
                    { "before", lastSignature }
                }
                }
            };

            var requestJson = JsonConvert.SerializeObject(requestContent);
            var httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("", httpContent);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<SolanaRpcResponse>(responseJson);

            var signatures = new List<string>();
            if (responseData != null && responseData.result != null)
            {
                foreach (var signatureInfo in responseData.result)
                {
                    signatures.Add(signatureInfo.signature);
                }
            }

            return signatures;
        }
    }
}

