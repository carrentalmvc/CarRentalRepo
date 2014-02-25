using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.Core.Common
{
    /// <summary>
    /// Decsribes the result of a potential change through a business service.
    /// </summary>
   public  class ValidationResult
    {
       public ValidationResult()
       {

       }

       public ValidationResult(string memebrName ,string message)
       {
           this.MemberName = memebrName;
           this.Message = message;
       }

       public string MemberName { get; set; }

       public string Message { get; set; }
    }
}
