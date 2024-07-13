using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solana_Transactions.Models
{
    public class TransactionError
    {
        [JsonProperty("InstructionError")]
        public List<object> InstructionError { get; set; }
    }
}
