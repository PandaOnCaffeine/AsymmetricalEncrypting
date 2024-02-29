using AsymmetricalEncrypting.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetricalEncrypting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Generate a public/private key using RSA  
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048);

            // Export PrivateKeyInfo As RSAParameters
            RSAParameters privateKeyInfo = RSA.ExportParameters(true);

            // Create RSAReceiver and RSASender
            RSAReceiver receiver = new RSAReceiver(privateKeyInfo); // RSAReceiver with PrivateKeyInfo as Parameter
            RSASender sender = new RSASender(); // RSASender with no Parameters

            receiver.PrintKeyInfo();
            sender.PrintKeyInfo(receiver.PublicKeyInfo());



            // Test Number One
            Console.WriteLine("\nTest 1");
            // Message and Print to Console
            string message1st = "Hello World";
            Console.WriteLine("PlainText Test 1: " + message1st);

            // Encrypted Message and Print to Console
            byte[] encryptedTest1 = sender.EncryptRSA(message1st, receiver.PublicKeyInfo());
            Console.WriteLine("\nEncrypted Test 1: " + BitConverter.ToString(encryptedTest1));

            // Decrypted Message and Print to Console
            string decryptedTest1 = receiver.DecryptRSA(encryptedTest1);
            Console.WriteLine("\nDecrypted Test 1: " + decryptedTest1);


            // Test Number Two
            Console.WriteLine("\nTest 2");
            // Message and Print to Console
            string message2nd = "Roses are Mostly Red";
            Console.WriteLine("PlainText Test 2: " + message2nd);

            // Encrypted Message and Print to Console
            byte[] encryptedTest2 = sender.EncryptRSA(message2nd, receiver.PublicKeyInfo());
            Console.WriteLine("\nEncrypted Test 2: " + BitConverter.ToString(encryptedTest2));

            // Decrypted Message and Print to Console
            string decryptedTest2 = receiver.DecryptRSA(encryptedTest2);
            Console.WriteLine("\nDecrypted Test 2: " + decryptedTest2);

            // Test Number Three
            Console.WriteLine("\nTest 3");

            // Make new key
            // To show example with another key
            receiver.GenerateNewKey();
            receiver.PrintKeyInfo();
            sender.PrintKeyInfo(receiver.PublicKeyInfo());

            // Message and Print to Console
            string message3rd = "Did it work?";
            Console.WriteLine("\nPlainText Test 3: " + message3rd);

            // Encrypted Message and Print to Console
            byte[] encryptedTest3 = sender.EncryptRSA(message3rd, receiver.PublicKeyInfo());
            Console.WriteLine("\nEncrypted Test 3: " + BitConverter.ToString(encryptedTest3));

            // Decrypted Message and Print to Console
            string decryptedTest3 = receiver.DecryptRSA(encryptedTest3);
            Console.WriteLine("\nDecrypted Test 3: " + decryptedTest3);

            Console.ReadLine();
        }
    }
}
