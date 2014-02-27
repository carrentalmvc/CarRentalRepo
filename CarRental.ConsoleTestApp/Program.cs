using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using CarRentals.Core.Common;
using System.Security.Cryptography;
using System.Configuration;
using System.IO;

namespace CarRental.ConsoleTestApp
{
    /// <summary>
    /// This project is basically used to do all the testing
    /// </summary>
    public class Program 
    {
        private static void Main(string[] args)
        {

            //var key = "Care Rental Application Key kept";
            //var size = Encoding.ASCII.GetByteCount(key);
            //var key = "CarRentalPassword";
            //var encKey = ProtectedData.Protect(Encoding.ASCII.GetBytes(key),null,DataProtectionScope.LocalMachine); 
   
            //var base64String = Convert.ToBase64String(encKey);

            //Unprotect
            var encKey = ProtectedData.Unprotect(Convert.FromBase64String(ConfigurationManager.AppSettings["encKey"].ToString()), null, DataProtectionScope.LocalMachine);

            var plainText = "P@ssword100";

            var encryptedData = Encrypt(plainText, encKey);
           

           
            Console.ReadLine();

        }

        public static byte[] Encrypt(string plainText ,byte[] key)
        {
            byte[] encrypted = null;

            if (!string.IsNullOrWhiteSpace(plainText))
            {
                using (var aesManaged = new AesManaged())
                {
                    aesManaged.Key = key;                    
                    aesManaged.IV = key;
                    aesManaged.Padding = PaddingMode.PKCS7;
                    //create an encryptor to perfom the stream transform
                    ICryptoTransform encryptor = aesManaged.CreateEncryptor(aesManaged.Key, aesManaged.IV);
                    //Create the streams used for encryption
                    using (var mStream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(mStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (var streamWriter = new StreamWriter(cryptoStream))
                            {
                                streamWriter.Write(plainText);
                            }
                            encrypted = mStream.ToArray();
                        }

                    }
                }
            }

            return encrypted;
        }

        

       
        
    }

   
}