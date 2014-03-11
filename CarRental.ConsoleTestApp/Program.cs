﻿using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml;
using CarRentals.Core.Common;
using CarRentals.Core.Common.Logging;
using log4net;

namespace CarRental.ConsoleTestApp
{
    /// <summary>
    /// This project is basically used to do all the testing
    /// </summary>
   
    public class Program
    {
        private static  log4net.ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static void Main(string[] args)
        {
            ;
            //These are samples.
            //var key = "CarRentalKey";
            //var password = "P@ssword900";

            //var keyBase64 = AesEncryptionUtility.CreateBase64EncodedEncKey(key);

            //var passwordBase64 = AesEncryptionUtility.CreateBase64EncodedEncPassword(password);

            ////Unprotect
            //var keyUnprotectedBytes = ProtectedData.Unprotect(Convert.FromBase64String(ConfigurationManager.AppSettings["encKey"].ToString()), null, DataProtectionScope.LocalMachine);

            //var plainText = "P@ssword100";

            //var encryptedData = Encrypt(plainText, encKey);
            //log4net.Config.XmlConfigurator.Configure();
            //ILogger _logger = null;

            //try
            //{
            //   _logger = LoggerFactory.GetLogger();

            //   string str = null;
            //   str.EndsWith("Rennish");
            //}
            //catch (Exception ex)
            //{
            //    _logger.Log("Console", LogLevel.ERROR, ex.Message, CustomEvenetId.ConsoleTestAppErros.ToString());
            //}           

            try
            {
                var validateXml = new XmlUtility().ValidateXml(@"C:\ASPNET\CarRentalMVCAnilRennish\CarRentalRepo\CarRental.ConsoleTestApp\Xml\Person.xml");
            }
            catch ( Exception ex)
            {

                _logger.Error(ex.Message);
                throw;

            }


            Console.WriteLine("Successfully validated Xml..");


            Console.ReadLine();
        }

        public static byte[] Encrypt(string plainText, byte[] key)
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