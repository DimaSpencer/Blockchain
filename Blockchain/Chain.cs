using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockchain
{
    public class Chain
    {
        public List<Block> Blocks { get; }
        public Block GenesisBlock { get; }
        public Chain(string genesisBlockData)
        {
            //create genesis block
            Blocks = new List<Block>();
            GenesisBlock = new Block(genesisBlockData, "5db1fee4b5703808c48078a76768b155b421b210c0761cd6a5d223f4d99f1eaa");
            Blocks.Add(GenesisBlock);
        }
        public void CreateBlock(string data)
        {
            string lastHash = Blocks[^1].Hash;
            Block block = new Block(data, lastHash);
            Blocks.Add(block);
        }
        /// <summary>
        /// Метод проверки корректности цепочки.
        /// </summary>
        /// <returns></returns>
        public bool CheckChain()
        {
            string previousHash = Blocks[0].Hash;
            foreach (var block in Blocks.Skip(1))
            {
                var hash = block.PreviousHash;
                if (previousHash != hash)
                {
                    return false;
                }
                previousHash = block.Hash;
            }
            return true;
        }
    }
}
