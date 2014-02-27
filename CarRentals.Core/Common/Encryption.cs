using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CarRentals.Core.Common
{
    /// <summary>
    /// This class is used for Encryption and Decryption using AES256 symmetric encryption
    ///http://msdn.microsoft.com/en-us/library/system.security.cryptography.aesmanaged(v=vs.110).aspx
    /// </summary>
    public class Encryption
    {
        private byte[] key;
        private byte[] iv;

        public Encryption(byte[] key ,string password)
        {

            //this.key = new rfc
        }
        

        public static byte[] Encrypt(string plainText)
        {
            byte[] encrypted = null;

            if (!string.IsNullOrWhiteSpace(plainText))
            {
                using (var aesManaged = new AesManaged())
                {
                    var key = aesManaged.Key;
                    var iv = aesManaged.IV;
                    //create an encryptor to perfom the stream transform
                    ICryptoTransform encryptor = aesManaged.CreateEncryptor(key,iv);
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

        public static string Decrypt(byte[] encrypted)
        {
            string plainText = null;
            using (var aesManaged = new AesManaged())
            {
                var key = aesManaged.Key;
                var iv = aesManaged.IV;
                ICryptoTransform descryptor = aesManaged.CreateDecryptor(key,iv);
                using (var msDecrypt = new MemoryStream(encrypted))
                {
                    using (var cryptoStream = new CryptoStream(msDecrypt, descryptor, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                        {
                            plainText = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return plainText;
        }
    }
}