using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CarRentals.Core.Common
{
    /// <summary>
    /// This class is used for Encryption and Decryption using AES256 symmetric encryption
    ///http://msdn.microsoft.com/en-us/library/system.security.cryptography.aesmanaged(v=vs.110).aspx and
    ///
    ///http://blogs.msdn.com/b/shawnfa/archive/2006/10/09/the-differences-between-rijndael-and-aes.aspx(This explains about the Keysize and Blocksize)
    /// </summary>
    public class Encryption
    {
        private byte[] _key = null;
        private byte[] _iv = null;
        private Rfc2898DeriveBytes _derivedKey;

        public Encryption(byte[] key ,string password)
        {

            this._derivedKey = new Rfc2898DeriveBytes(password, key);
        }

        private  byte[] GetKey(AesManaged aesManaged)
        {
            if (_key == null)
            {
                _key = _derivedKey.GetBytes(aesManaged.BlockSize / 8);
            }

            return _key;
        }

        private byte[] GetIV(AesManaged aesManaged)
        {
            if (_iv == null)
            {
                _iv = _derivedKey.GetBytes(aesManaged.BlockSize / 8);
            }

            return _iv;
        }   
        
        /// <summary>
        /// In AES,key size can be either 128,192 or 256 and Blocksize should always be 128.
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public  byte[] Encrypt(string plainText)
        {
            byte[] encrypted = null;

            if (!string.IsNullOrWhiteSpace(plainText))
            {
                using (var aesManaged = new AesManaged())
                {
                    aesManaged.Key = GetKey(aesManaged);
                    aesManaged.IV = GetIV(aesManaged);
                    aesManaged.BlockSize = 128;
                    aesManaged.Padding = PaddingMode.PKCS7;
                    
                    //create an encryptor to perfom the stream transform
                    ICryptoTransform encryptor = aesManaged.CreateEncryptor(aesManaged.Key,aesManaged.IV);
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

        public  string Decrypt(byte[] encrypted)
        {
            string plainText = null;           
                    
            using (var aesManaged = new AesManaged())
            {
                aesManaged.Key = GetKey(aesManaged);
                aesManaged.IV = GetIV(aesManaged);
                aesManaged.BlockSize = 128;
                ICryptoTransform descryptor = aesManaged.CreateDecryptor(aesManaged.Key, aesManaged.IV);
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