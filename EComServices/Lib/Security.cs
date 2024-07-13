using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EComServices.Lib
{
    public class Security
    {
        public static string CreateSalt(int size)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        public static byte[] Hash(string value, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] _value = Encoding.UTF8.GetBytes(value);
                byte[] _salt = Encoding.UTF8.GetBytes(salt);
                byte[] _saltValue = _value.Concat(_salt).ToArray();
                return sha256.ComputeHash(_saltValue);
            }
        }
        public static bool ConfirmPassword(string password, byte[] userPasswordHash, string userSalt)
        {
            byte[] passwordHash = Hash(password, userSalt);
            return userPasswordHash.SequenceEqual(passwordHash);
        }
    }
}
