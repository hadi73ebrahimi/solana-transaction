using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solana_Transactions.Models
{
    public class SignatureInfo
    {
        public string signature { get; set; }
        public long blockTime { get; set; }
        public string err { get; set; }
        public ulong slot { get; set; }
    }
}
