using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.ConsoleTestApp
{
    class CheckForPalindrome
    {
        private dynamic _readonly_name = "Rennish Joseph";

        public static bool CheckforPalindrome(string a)
        {
            var retVal = false;
            if (!string.IsNullOrWhiteSpace(a))
            {
                retVal = a.SequenceEqual(a.Reverse());
            }

            return retVal;
        }

        
    }
}
