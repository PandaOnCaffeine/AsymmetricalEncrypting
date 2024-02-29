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
            // RSA Can't Encrypt Long Messages //
            // Test Messages

            //         //
            // Testing //
            //         //

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

            //              //
            // RSA Receiver //
            //              //

            // Generate RSA Object With a Key attached


            // Print KeyInfo


            // BitConverter.ToString Format for encrypted data, like F9-9A-98-6F-BC-9F.


            // Convert string to Byte[], Then Use private key to decrypt


            //            //
            // RSA Sender //
            //            //

            // Print KeyInfo


            // User input message/ Or use the test messages at the top


            // Use Private Key To Encrypt message says moodle. is it not using public key???


            // Print Encrypted Message


            //                    //
            // Testing of Program // 
            //                    //

            // Copy and input the public key data From Receiver to The Sender.


            // Encrypt a Message


            // Use Receiver to Decrypt the message


            // Print Result

            Console.ReadLine();
        }

        private static byte[] EncryptRSA(string message, RSAParameters publicKey)
        {
            using (RSA rsa = RSA.Create(2048 /* Key Size */))
            {



                byte[] dataToEncrypt = Encoding.UTF8.GetBytes(message);
                return dataToEncrypt;

                byte[] encryptedData = rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.OaepSHA256);


                // Print All Data
                Console.WriteLine("Plain Text: " + message);

                // Using Convert.ToBase64String
                //Console.WriteLine("Cipherbytes Convert: " + Convert.ToBase64String(dataToEncrypt));

                // Using BitConverter.ToString
                Console.WriteLine("Cipherbytes BitConvert: " + BitConverter.ToString(encryptedData, 0, encryptedData.Length)); // Show as F9-9A-98-6F-BC-9F.

                Console.WriteLine("Encrypted Data: " + Convert.ToBase64String(encryptedData));

                //Returns The Encrypted byte[]
                return encryptedData;
            }
        }

        private static string DecryptRSA(string message, string privateKey)
        {
            return "";
        }
    }
}
