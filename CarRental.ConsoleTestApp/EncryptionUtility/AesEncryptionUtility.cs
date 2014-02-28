using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.ConsoleTestApp
{
    /// <summary>
    /// This class is used for encrypting the encryption key and password(salt).These are stored as base64 encoded string in the config file
    /// These are encrypted and decrypted using the built in ProtectedData class.Run the console app(Provide a key and password thats atleast 8 bytes long) and copy the encryptionKey and encPassword in the web/app config file.
    ///You may want to modify the code so that it automatically update the web/App configs in production environment.The generated base64 encoded strings will vary from amchine to machine.This sould be done separatey in each servers
    /// </summary>
    class AesEncryptionUtility
    {
        public static string CreateBase64EncodedEncKey(string key)
        {

            var encKey = ProtectedData.Protect(Encoding.ASCII.GetBytes(key), null, DataProtectionScope.LocalMachine);

            var base64KeyString = Convert.ToBase64String(encKey);

            return base64KeyString;
            
        }

        public static string CreateBase64EncodedEncPassword(string password)
        {

            var encPassword = ProtectedData.Protect(Encoding.ASCII.GetBytes(password), null, DataProtectionScope.LocalMachine);

            var base64PasswordString = Convert.ToBase64String(encPassword);

            return base64PasswordString;
        }
    }
}
