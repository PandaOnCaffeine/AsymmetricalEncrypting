using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetricalEncrypting.Classes
{
    public class RSASender
    {
        public byte[] EncryptRSA(string message, RSAParameters publicKeyInfo)
        {
            // Create RSA Instance with the PublicKeyInfo
            using (RSA rsa = RSA.Create(publicKeyInfo))
            {
                // Change message From String To Bytes[]
                byte[] dataToEncrypt = Encoding.UTF8.GetBytes(message);

                // Encrypt Message With OaepSHA256
                byte[] encrypted = rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.OaepSHA256);

                // Return Encrypted Byte[]
                return encrypted;
            }
        }
        public void PrintKeyInfo(RSAParameters publicKeyInfo)
        {
            // Print PublicKeyInfo
            Console.WriteLine($"\n\nRSASender:");
            Console.WriteLine($"Public Key Info:");
            Console.WriteLine($"Modulus: \n" + BitConverter.ToString(publicKeyInfo.Modulus));
            Console.WriteLine($"\nExponent: \n" + BitConverter.ToString(publicKeyInfo.Exponent));
        }
    }
}
