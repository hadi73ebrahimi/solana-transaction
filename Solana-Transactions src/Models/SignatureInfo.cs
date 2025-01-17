﻿using Solana_Transactions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolanaTransactions.Models
{
    public class SignatureInfo
    {
        public string signature { get; set; }
        public long blockTime { get; set; }
        public TransactionError err { get; set; }
        public ulong slot { get; set; }
    }
}
