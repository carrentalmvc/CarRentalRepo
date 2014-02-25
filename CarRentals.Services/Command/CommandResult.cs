using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.Services.Command
{
   public class CommandResult : ICommandResult
    {
       public CommandResult(bool result)
       {
           this.Success = result;
       }

       public bool Success
       {
           get;
           protected set;
       }

       
    }
}
