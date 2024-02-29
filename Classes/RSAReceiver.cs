using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetricalEncrypting.Classes
{
    public class RSAReceiver
    {
        private RSAParameters _privateKeyInfo;
        public RSAReceiver(RSAParameters privateKeyInfo)
        {
            _privateKeyInfo = privateKeyInfo;
        }
        public string DecryptRSA(byte[] encrypted)
        {
            // Create RSA Instance with PrivateKeyInfo
            using (RSA rsa = RSA.Create(_privateKeyInfo))
            {
                // Decrypt Message With OaepSHA256
                byte[] decrypted = rsa.Decrypt(encrypted, RSAEncryptionPadding.OaepSHA256);

                // Return Decrypted Message As a String
                return Encoding.UTF8.GetString(decrypted); 
            }
        }
        public RSAParameters PublicKeyInfo()
        {
            // Create RSA Instance with PrivateKeyInfo
            using (RSA rsa = RSA.Create(_privateKeyInfo))
            {
                // Export PublicKeyInfo From PrivateKeyInfo
                RSAParameters publicKeyInfo = rsa.ExportParameters(false);

                // Return PublicKeyInfo As RSAParameters
                return publicKeyInfo;
            }
        }
        public void PrintKeyInfo()
        {
            // Print PrivateKeyInfo
            Console.WriteLine($"RSAReceiver:");
            Console.WriteLine($"Private Key Info: ");
            Console.WriteLine($"Modulus: \n" + BitConverter.ToString(_privateKeyInfo.Modulus));
            Console.WriteLine($"\nExponent: \n" + BitConverter.ToString(_privateKeyInfo.Exponent));
            Console.WriteLine($"\nP: \n" + BitConverter.ToString(_privateKeyInfo.P));
            Console.WriteLine($"\nQ: \n" + BitConverter.ToString(_privateKeyInfo.Q));
            Console.WriteLine($"\nDP: \n" + BitConverter.ToString(_privateKeyInfo.DP));
            Console.WriteLine($"\nDQ: \n" + BitConverter.ToString(_privateKeyInfo.DQ));
        }
        public void GenerateNewKey()
        {
            // Generate a private key using RSA  
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048);

            // Export PrivateKeyInfo As RSAParameters
            RSAParameters privateKeyInfo = RSA.ExportParameters(true);

            // Set RSAReceiver's KeyInfo to new KeyInfo
            _privateKeyInfo = privateKeyInfo;
        }
    }
}
