using SolanaTransactions.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolanaTransactions.Models
{
    public class TokenModel
    {
        public List<Rootobject> Transactions { get; set; } = new List<Rootobject>();
    }
}
