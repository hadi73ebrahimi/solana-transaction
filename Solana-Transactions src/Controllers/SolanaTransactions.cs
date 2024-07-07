using Solana_Transactions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solana_Transactions.Controllers
{
    public class SolanaTransactions
    {
        private readonly HttpClient _httpClient;
        private Dictionary<string, TokenModel> _tokens = new Dictionary<string, TokenModel>();


        public SolanaTransactions(string rpcUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(rpcUrl) };
        }

        public async Task GetTransactions(string[] tokenAddresses)
        {
            CurrentState = EnExplorerstatus.Started;
            await InitializeTokensAsync(tokenAddresses);
            await DownloadTransactionsAsync(tokenAddresses);
            CurrentState = EnExplorerstatus.Finished;
        }
    }
}
