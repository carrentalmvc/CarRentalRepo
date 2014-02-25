using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentals.Core.Common;
using CarRentals.Services.Command;

namespace CarRentals.Services.Validations
{
   public interface IValidationHandler<TCommand> where TCommand : ICommand
    {
       IEnumerable<ValidationResult> Validate(TCommand command);
    }
}
