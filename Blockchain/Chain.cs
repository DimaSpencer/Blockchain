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
        //у нас должна быть возможность подключения к уже имеющийся цепи блоков
        public Chain()
        {
            var blocksFromDatabase = LoadChainFromDatabase();

            if (blocksFromDatabase.Count > 0)
            {
                Blocks = blocksFromDatabase;
            }
            else
            {
                //create genesis block
                Blocks = new List<Block>();
                GenesisBlock = new Block("Hello from Ukraine", previousHash: "null");
                Blocks.Add(GenesisBlock);
                SaveBlockToDatabase(GenesisBlock);
            }
        }
        public void CreateBlock(string data)
        {
            string lastHash = Blocks[^1].Hash;
            Block block = new Block(data, lastHash);
            Blocks.Add(block);
            SaveBlockToDatabase(block);
        }
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
        private void SaveBlockToDatabase(Block block)
        {
            using var database = new BlockchainDatabaseContext();
            database.Blocks.Add(block);
            database.SaveChanges();
        }
        private List<Block> LoadChainFromDatabase()
        {
            using var database = new BlockchainDatabaseContext();
            var resultBlocks = new List<Block>();
            resultBlocks.AddRange(database.Blocks);
            return resultBlocks;
        }
    }
}
