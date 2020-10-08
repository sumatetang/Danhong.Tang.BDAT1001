using Encoder_and_Encrypter.Models;
using System;
using System.Text;

namespace Encoder_and_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            var fullName = Console.ReadLine();
            var binary = Converter.StringToBinary(fullName);
            Console.WriteLine(binary);


            var ascii = Console.ReadLine();

            string binaryValue = Converter.StringToBinary(ascii);

            Console.WriteLine($"Text: {ascii}\nBinary: {binaryValue}");

            string textFromBinary = Converter.BinaryToString(binaryValue);

            Console.WriteLine($"Binary: {binaryValue}\nText: {textFromBinary}");


                       

            byte[] fullNameBytes = Encoding.ASCII.GetBytes(fullName);

            Console.WriteLine($"Text: {fullName}\nBytes: {fullNameBytes}");



            string unicodeString = fullName;
            int[] cipher = new[] { 1, 1, 2, 3, 5, 8, 13 }; //Fibonacci Sequence
            string cipherasString = String.Join(",", cipher.Select(x => x.ToString())); //FOr display

            int encryptionDepth = 20;

            Encrypter encrypter = new Encrypter(unicodeString, cipher, encryptionDepth);

            //Single Level Encrytion
            string nameEncryptWithCipher = Encrypter.EncryptWithCipher(unicodeString, cipher);
            Console.WriteLine($"Encrypted once using the cipher {{{cipherasString}}} {nameEncryptWithCipher}");

            string nameDecryptWithCipher = Encrypter.DecryptWithCipher(nameEncryptWithCipher, cipher);
            Console.WriteLine($"Decrypted once using the cipher {{{cipherasString}}} {nameDecryptWithCipher}");

            //Deep Encrytion
            string nameDeepEncryptWithCipher = Encrypter.DeepEncryptWithCipher(unicodeString, cipher, encryptionDepth);
            Console.WriteLine($"Deep Encrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepEncryptWithCipher}");

            string nameDeepDecryptWithCipher = Encrypter.DeepDecryptWithCipher(nameDeepEncryptWithCipher, cipher, encryptionDepth);
            Console.WriteLine($"Deep Decrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepDecryptWithCipher}");

            //Base64 Encoded
            Console.WriteLine($"Base64 encoded {unicodeString} {encrypter.Base64}");

            string base64toPlainText = Encrypter.Base64ToString(encrypter.Base64);
            Console.WriteLine($"Base64 decoded {encrypter.Base64} {base64toPlainText}");
        }
    }
}


