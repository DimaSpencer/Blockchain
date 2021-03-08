using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blockchain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain.Tests
{
    [TestClass()]
    public class ChainTests
    {
        [TestMethod()]
        public void ChainTest()
        {
            string data = "Hello world";

            Chain chain = new Chain(data); 
            chain.CreateBlock(data);

            int blocksCount = chain.Blocks.Count;
            Assert.AreEqual(2, blocksCount);
            Assert.AreEqual(data, chain.Blocks[blocksCount - 1].Data);
        }
    }
}