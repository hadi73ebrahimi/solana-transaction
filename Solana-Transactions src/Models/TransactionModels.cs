using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolanaTransactions.Transaction
{

    public class Rootobject
    {
        public string? jsonrpc { get; set; }
        public Result? result { get; set; }
        public int id { get; set; }
    }

    public class Result
    {
        public long blockTime { get; set; }
        public Meta? meta { get; set; }
        public long slot { get; set; }
        public Transaction? transaction { get; set; }
        public string? version { get; set; }
    }

    public class Meta
    {
        public int computeUnitsConsumed { get; set; }
        public object err { get; set; }
        public int fee { get; set; }
        public Innerinstruction[]? innerInstructions { get; set; }
        public Loadedaddresses? loadedAddresses { get; set; }
        public string[]? logMessages { get; set; }
        public ulong[]? postBalances { get; set; }
        public Posttokenbalance[]? postTokenBalances { get; set; }
        public ulong[]? preBalances { get; set; }
        public Pretokenbalance[]? preTokenBalances { get; set; }
        public object[]? rewards { get; set; }
        public Status? status { get; set; }
    }

    public class Loadedaddresses
    {
        public string[] _readonly { get; set; }
        public string[] writable { get; set; }
    }

    public class Status
    {
        public object Ok { get; set; }
    }

    public class Innerinstruction
    {
        public int index { get; set; }
        public Instruction[]? instructions { get; set; }
    }

    public class Instruction
    {
        public int[] accounts { get; set; }
        public string data { get; set; }
        public int programIdIndex { get; set; }
        public int stackHeight { get; set; }
    }

    public class Posttokenbalance
    {
        public int accountIndex { get; set; }
        public string mint { get; set; }
        public string? owner { get; set; }
        public string? programId { get; set; }
        public Uitokenamount? uiTokenAmount { get; set; }
    }

    public class Uitokenamount
    {
        public string? amount { get; set; }
        public int? decimals { get; set; }
        public float? uiAmount { get; set; }
        public string? uiAmountString { get; set; }
    }

    public class Pretokenbalance
    {
        public int accountIndex { get; set; }
        public string? mint { get; set; }
        public string? owner { get; set; }
        public string? programId { get; set; }
        public Uitokenamount1? uiTokenAmount { get; set; }
    }

    public class Uitokenamount1
    {
        public string? amount { get; set; }
        public int? decimals { get; set; }
        public float? uiAmount { get; set; }
        public string? uiAmountString { get; set; }
    }

    public class Transaction
    {
        public Message? message { get; set; }
        public string[]? signatures { get; set; }
    }

    public class Message
    {
        public string[]? accountKeys { get; set; }
        public Addresstablelookup[]? addressTableLookups { get; set; }
        public Header? header { get; set; }
        public Instruction1[]? instructions { get; set; }
        public string? recentBlockhash { get; set; }
    }

    public class Header
    {
        public int numReadonlySignedAccounts { get; set; }
        public int numReadonlyUnsignedAccounts { get; set; }
        public int numRequiredSignatures { get; set; }
    }

    public class Addresstablelookup
    {
        public string? accountKey { get; set; }
        public int[]? readonlyIndexes { get; set; }
        public int[]? writableIndexes { get; set; }
    }

    public class Instruction1
    {
        public int[]? accounts { get; set; }
        public string? data { get; set; }
        public int programIdIndex { get; set; }
        public object? stackHeight { get; set; }
    }

}
