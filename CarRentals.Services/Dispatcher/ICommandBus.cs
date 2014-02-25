using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentals.Core.Common;
using CarRentals.Services.Command;

namespace CarRentals.Services.Dispatcher
{
    /// <summary>
    /// Implementation dispathces the command to the Handler after Validtaion ???
    /// Every command object will be submitted to a commandbus
    /// </summary>
  public interface ICommandBus
    {
      ICommandResult Submit<TCommand>(TCommand command) where TCommand : ICommand;

      IEnumerable<ValidationResult> Validate<TCommand>(TCommand command) where TCommand : ICommand;

    }
}
