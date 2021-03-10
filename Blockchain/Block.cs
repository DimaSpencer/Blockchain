using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Blockchain
{
    public class Block : IBlock
    {
        public static int _idGenerator = 1;
        public int Id { get; private set; }
        public string Data { get; private set; }
        public string Hash { get; private set; }
        public string PreviousHash { get; private set; }
        public DateTime TimeOfCreation { get; private set; }
        public Block() { }
        public Block(string data, string previousHash)
        {
            #region CheckInputData
            if (string.IsNullOrEmpty(data))
                throw new ArgumentException("Невалидное значение Data", nameof(data));
            if (string.IsNullOrEmpty(previousHash))
                throw new ArgumentException("Невалидное значение PreviousHash", nameof(previousHash));
            #endregion
            Id = _idGenerator++;
            Data = data;
            Hash = GenerateHash(data, previousHash);
            PreviousHash = previousHash;
            TimeOfCreation = DateTime.UtcNow;
        }
        private string GenerateHash(string data, string previousHash)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(data + previousHash));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
                builder.Append(hashedBytes[i].ToString("x2"));
            return builder.ToString();
        }
    }
}
