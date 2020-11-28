using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PlutoCourses.Services
{
    public class Sha256Service : IHashingService
    {
        private readonly SHA256 sHA256;

        public Sha256Service()
        {
            sHA256 = SHA256.Create();
        }

        public string Hash(string plainTxt)
        {
            byte[] hashInBytes = sHA256.ComputeHash(Encoding.Default.GetBytes(plainTxt));
            return Encoding.Default.GetString(hashInBytes);
        }
    }
}