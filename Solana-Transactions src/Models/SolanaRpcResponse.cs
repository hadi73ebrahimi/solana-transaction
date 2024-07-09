using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solana_Transactions.Models
{
    public class SolanaRpcResponse
    {
        public string jsonrpc { get; set; }
        public int id { get; set; }
        public List<SignatureInfo> result { get; set; }
    }

}
