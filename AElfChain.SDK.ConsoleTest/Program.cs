using System;
using Newtonsoft.Json;

namespace AElfChain.SDK.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var chainClient = AElfChainClient.GetClient("http://192.168.197.43:8100");

            //chain status
            var chainStatus = chainClient.GetChainStatusAsync().Result;
            Console.WriteLine($"ChainId: {chainStatus.ChainId}");
            Console.WriteLine($"GensisContractAddress: {chainStatus.GenesisContractAddress}");
            
            //serialize
            var chainStatusJsonResult = JsonConvert.SerializeObject(chainStatus);
            Console.WriteLine(chainStatusJsonResult);
            
            //get block by height
            var block = chainClient.GetBlockByHeightAsync(10, true).Result;
            Console.WriteLine($"BlockHash: {block.BlockHash}");
            Console.WriteLine($"BlockHeader SignerPubkey: {block.Header.SignerPubkey}");
            Console.WriteLine($"BlockBody Transactions: {block.Body.Transactions.Count}");
            
            //serialize
            var blockJsonResult = JsonConvert.SerializeObject(block);
            Console.WriteLine(blockJsonResult);

            //query block transactions
            var blockHeight = chainClient.GetBlockHeightAsync().Result;
            for (var i = 1; i < blockHeight; i++)
            {
                var blockInfo = chainClient.GetBlockByHeightAsync(i, true).Result;
                var transactions = blockInfo.Body.Transactions;
                Console.WriteLine($"Block height: {i}, transaction count: {transactions.Count}");
                transactions.ForEach(Console.WriteLine);
            }
        }
    }
}