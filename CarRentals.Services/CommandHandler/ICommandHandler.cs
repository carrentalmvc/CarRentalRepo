using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentals.Services.Command;

namespace CarRentals.Services.CommandHandler
{
   public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
       ICommandResult Execute(TCommand command);
    }
}
