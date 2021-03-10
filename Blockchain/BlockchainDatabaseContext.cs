using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain
{
    class BlockchainDatabaseContext : DbContext
    {
        public DbSet<Block> Blocks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BlockchainDb;Trusted_Connection=True;");
        }
    }
}
