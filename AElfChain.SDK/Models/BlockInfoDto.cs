using System;
using System.Collections.Generic;

namespace AElfChain.SDK.Models
{
    public class BlockDto
    {
        public string BlockHash { get; set; }

        public BlockHeaderDto Header { get; set; }

        public BlockBodyDto Body { get; set; }
    }

    public class BlockBodyDto
    {
        public int TransactionsCount { get; set; }

        public List<string> Transactions { get; set; }
    }

    public class BlockHeaderDto
    {
        public string PreviousBlockHash { get; set; }

        public string MerkleTreeRootOfTransactions { get; set; }

        public string MerkleTreeRootOfWorldState { get; set; }

        public string Extra { get; set; }

        public long Height { get; set; }

        public DateTime Time { get; set; }

        public string ChainId { get; set; }

        public string Bloom { get; set; }

        public string SignerPubkey { get; set; }
    }
}