using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentals.Core.Common;
namespace CarRentals.Services.Validations
{
   public interface IValidationHandler<T> where T : class
    {
       IEnumerable<ValidationResult> Validate(T entity);
    }
}
