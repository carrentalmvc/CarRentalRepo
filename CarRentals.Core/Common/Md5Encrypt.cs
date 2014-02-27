using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.Core.Common
{
   public class Md5Encrypt
    {
       public static string Md5EncryptPassword(string txtPassword)
       {
           var encoding = new ASCIIEncoding();
           var bytes = encoding.GetBytes(txtPassword);
           var hashed = MD5.Create().ComputeHash(bytes);
           return Encoding.UTF8.GetString(hashed);
       }
    }
}
