// See https://aka.ms/new-console-template for more information
using SolanaTransactions;
using SolanaTransactions.Controllers;

var rpc = "https://api.mainnet-beta.solana.com";
var targettokens = new[] 
{ "2VXegPqYCciT5G7Zttqz3q2D9MW1QmRLerkp2fsSpump",
    "gabeGcknKqGVSfUvXJcggFdHPApDnAKYSPVqfxqpump" };

Console.WriteLine("> Started");
var transactionmanager = new SolanaTransactionsManager(rpc);
var transactionsdata = await transactionmanager.GetTransactions(targettokens);

foreach (var item in transactionsdata)
{
    Console.WriteLine("> Token: "+item.Key);
    foreach (var transactions in item.Value.Transactions)
    {
        Console.WriteLine(transactions.result.transaction.signatures);
    }
}
Console.ReadLine();



