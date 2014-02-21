using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.Util
{
   public  class QueryStringEncoding
    {
       public async Task<string> EncodeQueryString(string queryString)
       {

           var plainTextbytes = System.Text.Encoding.UTF8.GetBytes(queryString);
           return Convert.ToBase64String(plainTextbytes);



       }
    }
}
