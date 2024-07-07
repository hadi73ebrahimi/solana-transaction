using Solana_Transactions.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solana_Transactions.Models
{
    public class TokenModel
    {
        public ulong TotalSupply { get; set; }
        public List<Rootobject> Transactions { get; set; } = new List<Rootobject>();
    }
}
