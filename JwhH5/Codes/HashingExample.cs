using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace JwhH5.Codes
{
    public class HashingExample
    {
        // MD5
        public string GetHashedText_MD5(string valueToHash)
        {
            // Konverter værdi til bytes
            byte[] valueAsBytes = ASCIIEncoding.ASCII.GetBytes(valueToHash);
            byte[] valueT = MD5.HashData(valueAsBytes);

            // Konverter til string
            string hashedValueAsString = Convert.ToBase64String(valueT);
            
            return hashedValueAsString;
        }

        // BCrypt
        public string GetEncryptedText_BCrypt(string valueToEncrypt)
        {
            string encryptedValue = BCrypt.Net.BCrypt.HashPassword(valueToEncrypt);

            return encryptedValue;
        }

        //public string GetDecryptedText_BCrypt(string textToDecrypt, string hashedText)
        //{
        //    bool decryptedText = BCrypt.Net.BCrypt.Verify(textToDecrypt, hashedText);

            
        //}

        //PBsoemthing
        //public string GetHashedText_PB(string asd)
        //{

        //}
    }
}
