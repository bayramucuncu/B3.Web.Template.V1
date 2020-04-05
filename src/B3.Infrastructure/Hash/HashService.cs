using System;
using System.Security.Cryptography;
using System.Text;

namespace B3.Infrastructure.Hash
{
    public abstract class HashService : IHashService
    {
        private readonly HashAlgorithm _hashAlgorithm;

        protected HashService(HashAlgorithm hashAlgorithm)
        {
            _hashAlgorithm = hashAlgorithm;
        }

        public string Generate(string data)
        {
            var originalBytes = Encoding.UTF8.GetBytes(data);
            var encodedBytes = _hashAlgorithm.ComputeHash(buffer: originalBytes);

            return BitConverter.ToString(encodedBytes).Replace("-", "");
        }
    }

    public class Sha1HashService : HashService
    {
        public Sha1HashService() : base(new SHA1CryptoServiceProvider())
        {
        }
    }

    public class Md5HashService : HashService
    {
        public Md5HashService() : base(new MD5CryptoServiceProvider())
        {
        }
    }

    public interface IHashService
    {
        string Generate(string data);
    }
}