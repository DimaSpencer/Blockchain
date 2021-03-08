using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain
{
    public class Chain
    {
        public List<Block> Blocks { get; }
        public Block GenesisBlock { get; }
        public Chain(string firstData)
        {
            //create genesis block
            Blocks = new List<Block>();
            GenesisBlock = new Block(firstData, "5db1fee4b5703808c48078a76768b155b421b210c0761cd6a5d223f4d99f1eaa");
            Blocks.Add(GenesisBlock);
        }
        public void CreateBlock(string data)
        {
            string lastHash = Blocks[^1].Hash;
            Block block = new Block(data, lastHash);
            Blocks.Add(block);
        }
    }
}
