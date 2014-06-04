using System;
using System.Security.Cryptography;
using System.Text;

namespace CrowfoundingHn.Common.Authentication
{
    public class PasswordEncryptor : IPasswordEncryptor
    {
        
        public static byte[] HashPassword(string password)
        {
            var provider = new SHA1CryptoServiceProvider();
            var encoding = new UnicodeEncoding();
            return provider.ComputeHash(encoding.GetBytes(password));
        }

        public EncryptedPassword EncryptPassword(string password)
        {
            byte[] encryptedPassword = HashPassword(password);
            string base64String = Convert.ToBase64String(encryptedPassword);
            return new EncryptedPassword(base64String);   
        }
    }
}